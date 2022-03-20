﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Excel.Constants;
using Core.Excel.Converters;
using Core.Excel.Interfaces;
using Data.Models;
using OfficeOpenXml;
using OfficeOpenXml.Style;

namespace Core.Excel
{
    /// <summary>
    /// Реализация IExcelExporter.
    /// </summary>
    public class ExcelExporter : IExcelExporter
    {
        private readonly ExportCell exportCell;
        private readonly AcademicTitleToNameExcelConverter academicTitleToNameExcelConverter;
        private readonly RateExcelConverter rateExcelConverter;
        private readonly TeacherInitialsExcelConverter teacherInitialsExcelConverter;
        private readonly GroupsNamesToInfoExcelConverter groupsNamesToInfoExcelConverter;
        private Color colorCell = Color.Blue;

        /// <summary>
        /// ctor.
        /// </summary>
        public ExcelExporter()
        {
            ///TODO перенести в файл конфига (чтобы не было исключения про лицензию)
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            exportCell = new ExportCell();
            academicTitleToNameExcelConverter = new AcademicTitleToNameExcelConverter();
            rateExcelConverter = new RateExcelConverter();
            teacherInitialsExcelConverter = new TeacherInitialsExcelConverter();
            groupsNamesToInfoExcelConverter = new GroupsNamesToInfoExcelConverter();
        }

        /// <inheritdoc/>
        public void ExportTeacherLoadDiscipline(string path,
            CalculationSheet calculationSheet,
            List<Teacher> teachers,
            List<TeacherLoadDiscipline> teacherLoadDisciplines)
        {
            var newFile = new FileInfo(path);
            using (ExcelPackage excelPackage = new ExcelPackage(newFile))
            {
                excelPackage.Workbook.Properties.Created = DateTime.Now;

                ExcelWorksheet mainWorksheet = excelPackage.Workbook.Worksheets.Add("Итого");

                List<ExcelWorksheet> teacherWorksheets = new List<ExcelWorksheet>();
                foreach (Teacher teacher in teachers)
                {
                    var worksheet = excelPackage.Workbook.Worksheets.Add(teacher.LastName);
                    teacherWorksheets.Add(worksheet);

                    LoadHeaderInfo(worksheet, calculationSheet);
                    LoadTeacherInfo(worksheet, teacher);
                    LoadHeaderTeacherLoadDiscipline(worksheet);
                    LoadTeacherLoadDisciplineInfo(worksheet, teacherLoadDisciplines.Where(x => x.Teacher == teacher).ToList());
                }
                //foreach (ExcelWorksheet excelWorksheet in teacherWorksheets)
                //{
                //    LoadHeaderInfo(excelWorksheet, calculationSheet);
                //}

                excelPackage.Workbook.Styles.UpdateXml();
                excelPackage.Save();
            }
        }

        private void LoadHeaderInfo(ExcelWorksheet excelWorksheet, CalculationSheet calculationSheet)
        {
            excelWorksheet.Cells[exportCell.NamePzuStart.row,
                exportCell.NamePzuStart.column,
                exportCell.NamePzuEnd.row,
                exportCell.NamePzuEnd.column].Merge = true;

            excelWorksheet.Cells[exportCell.DistributionTeacherLoadStart.row,
                exportCell.DistributionTeacherLoadStart.column,
                exportCell.DistributionTeacherLoadEnd.row,
                exportCell.DistributionTeacherLoadEnd.column].Merge = true;

            excelWorksheet.Cells[exportCell.NamePzuStart.row, exportCell.NamePzuStart.column].Value = "Пензенский Государственный Университет";
            excelWorksheet.Cells[exportCell.NamePzuStart.row, exportCell.NamePzuStart.column].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

            excelWorksheet.Cells[exportCell.DistributionTeacherLoadStart.row, exportCell.DistributionTeacherLoadStart.column].Value = "Распределение учебной нагрузки";
            excelWorksheet.Cells[exportCell.DistributionTeacherLoadStart.row, exportCell.DistributionTeacherLoadStart.column].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

            excelWorksheet.Cells[exportCell.Department.row, exportCell.Department.column].Value = "Кафедра";
            excelWorksheet.Cells[exportCell.Department.row, exportCell.Department.column + 1].Value = calculationSheet.Department;

            excelWorksheet.Cells[exportCell.AcademicYear.row, exportCell.AcademicYear.column].Value = "Учебный год";
            excelWorksheet.Cells[exportCell.AcademicYear.row, exportCell.AcademicYear.column + 1].Value = calculationSheet.AcademicYear;

            excelWorksheet.Cells[exportCell.СfYearLoad.row, exportCell.СfYearLoad.column].Value = "ср.год.нагрузка";
            //TODO вынести Value в класс
            excelWorksheet.Cells[exportCell.СfYearLoad.row, exportCell.СfYearLoad.column + 1].Value = 850;
            excelWorksheet.Cells[exportCell.СfYearLoad.row, exportCell.СfYearLoad.column + 1].Style.Font.Color.SetColor(colorCell);
        }

        private void LoadTeacherInfo(ExcelWorksheet excelWorksheet, Teacher teacher)
        {
            excelWorksheet.Cells[exportCell.Initials.row,
                exportCell.Initials.column + 1,
                exportCell.Initials.row,
                exportCell.Initials.column + 2].Merge = true;
            excelWorksheet.Cells[exportCell.AcademicTitle.row,
                exportCell.AcademicTitle.column,
                exportCell.AcademicTitle.row,
                exportCell.AcademicTitle.column + 1].Merge = true;

            excelWorksheet.Cells[exportCell.Approve.row, exportCell.Approve.column].Value = "УТВЕРЖДАЮ";
            excelWorksheet.Cells[exportCell.Prorector.row, exportCell.Prorector.column].Value = "Проректор по учебной работе";

            excelWorksheet.Cells[exportCell.Initials.row, exportCell.Initials.column].Value = "Ф.И.О";
            excelWorksheet.Cells[exportCell.Initials.row, exportCell.Initials.column].Style.Font.Color.SetColor(colorCell);
            excelWorksheet.Cells[exportCell.Initials.row, exportCell.Initials.column + 1].Value = teacherInitialsExcelConverter.Convert(teacher);
            excelWorksheet.Cells[exportCell.Initials.row, exportCell.Initials.column].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

            excelWorksheet.Cells[exportCell.AcademicTitle.row, exportCell.AcademicTitle.column].Value = "должность";
            excelWorksheet.Cells[exportCell.AcademicTitle.row, exportCell.AcademicTitle.column].Style.Font.Color.SetColor(colorCell);
            excelWorksheet.Cells[exportCell.AcademicTitle.row, exportCell.AcademicTitle.column + 2].Value = academicTitleToNameExcelConverter.Convert(teacher.AcademicTitle);

            excelWorksheet.Cells[exportCell.Rate.row, exportCell.Rate.column].Value = "ставка";
            excelWorksheet.Cells[exportCell.Rate.row, exportCell.Rate.column].Style.Font.Color.SetColor(colorCell);
            excelWorksheet.Cells[exportCell.Rate.row, exportCell.Rate.column + 1].Value = rateExcelConverter.Convert(teacher.Rate);
        }

        private void LoadHeaderTeacherLoadDiscipline(ExcelWorksheet excelWorksheet)
        {
            int row = exportCell.HeaderTeacherLoadDiscipline.row;
            int column = exportCell.HeaderTeacherLoadDiscipline.column;

            excelWorksheet.Cells[row, column].Value = "Дисциплины";
            excelWorksheet.Cells[row, column + 1].Value = "Семестр";
            excelWorksheet.Cells[row, column + 2].Value = "Группы";
            excelWorksheet.Cells[row, column + 3].Value = "Студенты (бюд)";
            excelWorksheet.Cells[row, column + 4].Value = "Студенты (дог)";
            excelWorksheet.Cells[row, column + 5].Value = "Лекции";
            excelWorksheet.Cells[row, column + 6].Value = "Лабораторные";
            excelWorksheet.Cells[row, column + 7].Value = "Практические";
            excelWorksheet.Cells[row, column + 8].Value = "КП / КР";
            excelWorksheet.Cells[row, column + 9].Value = "контр./раб. (ЗФ)";
            excelWorksheet.Cells[row, column + 10].Value = "Экзамены";
            excelWorksheet.Cells[row, column + 11].Value = "Зачеты";
            excelWorksheet.Cells[row, column + 12].Value = "консультации";
            excelWorksheet.Cells[row, column + 13].Value = "Прочая нагрузка по ВПО";
            excelWorksheet.Cells[row, column + 14].Value = "Подготовка аспирантов, интернов, ординаторов";
            excelWorksheet.Cells[row, column + 15].Value = "Всего  осенний семестр";
            excelWorksheet.Cells[row, column + 16].Value = "Всего весенний семестр";
            excelWorksheet.Cells[row, column + 17].Value = "Всего за год нагрузка";

            using (ExcelRange range = excelWorksheet.Cells[row, column + 3, row, column + 17])
            {
                range.Style.TextRotation = 90;
                range.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
            }
        }

        private void LoadTeacherLoadDisciplineInfo(ExcelWorksheet excelWorksheet, List<TeacherLoadDiscipline> teacherLoadDisciplines)
        {
            int row = exportCell.TeacherLoadDiscipline.row;
            int column = exportCell.TeacherLoadDiscipline.column;

            foreach (TeacherLoadDiscipline variable in teacherLoadDisciplines)
            {
                excelWorksheet.Cells[row, column].Value = variable.NameDiscipine;
                excelWorksheet.Cells[row, column + 1].Value = variable.Semester;
                excelWorksheet.Cells[row, column + 2].Value = groupsNamesToInfoExcelConverter.Convert(variable.Groups);
                excelWorksheet.Cells[row, column + 3].Value = variable.StudentsBudget;
                excelWorksheet.Cells[row, column + 4].Value = variable.StudentsContract;
                excelWorksheet.Cells[row, column + 5].Value = variable.HoursLecture;
                excelWorksheet.Cells[row, column + 6].Value = variable.HoursLaboratoryWork;
                excelWorksheet.Cells[row, column + 7].Value = variable.HoursPracticum;
                excelWorksheet.Cells[row, column + 8].Value = variable.HoursKpKr;
                excelWorksheet.Cells[row, column + 9].Value = variable.HoursСontrolWork;
                excelWorksheet.Cells[row, column + 10].Value = variable.HoursExam;
                excelWorksheet.Cells[row, column + 11].Value = variable.HoursTest;
                excelWorksheet.Cells[row, column + 12].Value = variable.HoursConsultation;
                excelWorksheet.Cells[row, column + 13].Value = variable.HoursOtherLoadVpo;
                excelWorksheet.Cells[row, column + 14].Value = variable.HoursTraining;

                excelWorksheet.Cells[row, column + 15].Formula = $"IF(ISODD({excelWorksheet.Cells[row, column + 1].Address});SUM({excelWorksheet.Cells[row, column + 5].Address}:{excelWorksheet.Cells[row, column + 14].Address});0)";
                excelWorksheet.Cells[row, column + 16].Formula = $"IF(ISEVEN({excelWorksheet.Cells[row, column + 1].Address});SUM({excelWorksheet.Cells[row, column + 5].Address}:{excelWorksheet.Cells[row, column + 14].Address});0)";
                excelWorksheet.Cells[row, column + 17].Formula = $"SUM({excelWorksheet.Cells[row, column + 15].Address}:{excelWorksheet.Cells[row, column + 16].Address})";

                row++;
            }

            using (ExcelRange range = excelWorksheet.Cells[exportCell.HeaderTeacherLoadDiscipline.row, exportCell.HeaderTeacherLoadDiscipline.column, row - 1, column + 17])
            {
                range.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                range.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                range.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                range.Style.Border.Right.Style = ExcelBorderStyle.Thin;
            }

            LoadTotalInfo(excelWorksheet, exportCell.TeacherLoadDiscipline.row, row - 1);

            LoadBottomInfo(excelWorksheet, row);
        }

        private void LoadTotalInfo(ExcelWorksheet excelWorksheet, int startRow, int endRow)
        {
            excelWorksheet.Cells[exportCell.Total.row,
                 exportCell.Total.column,
                 exportCell.Total.row,
                 exportCell.Total.column + 1].Merge = true;
            excelWorksheet.Cells[exportCell.Total.row, exportCell.Total.column].Value = "ИТОГО:";

            int row = exportCell.TotalStartFormula.row;
            int column = exportCell.TotalStartFormula.column;

            excelWorksheet.Cells[row, column].Formula = CreateSumFormula(excelWorksheet, startRow, column, endRow, column);
            excelWorksheet.Cells[row, column + 1].Formula = CreateSumFormula(excelWorksheet, startRow, column + 1, endRow, column + 1);
            excelWorksheet.Cells[row, column + 2].Formula = CreateSumFormula(excelWorksheet, startRow, column + 2, endRow, column + 2);
            excelWorksheet.Cells[row, column + 3].Formula = CreateSumFormula(excelWorksheet, startRow, column + 3, endRow, column + 3);
            excelWorksheet.Cells[row, column + 4].Formula = CreateSumFormula(excelWorksheet, startRow, column + 4, endRow, column + 4);
            excelWorksheet.Cells[row, column + 5].Formula = CreateSumFormula(excelWorksheet, startRow, column + 5, endRow, column + 5);
            excelWorksheet.Cells[row, column + 6].Formula = CreateSumFormula(excelWorksheet, startRow, column + 6, endRow, column + 6);
            excelWorksheet.Cells[row, column + 7].Formula = CreateSumFormula(excelWorksheet, startRow, column + 7, endRow, column + 7);
            excelWorksheet.Cells[row, column + 8].Formula = CreateSumFormula(excelWorksheet, startRow, column + 8, endRow, column + 8);
            excelWorksheet.Cells[row, column + 9].Formula = CreateSumFormula(excelWorksheet, startRow, column + 9, endRow, column + 9);
            excelWorksheet.Cells[row, column + 10].Formula = CreateSumFormula(excelWorksheet, startRow, column + 10, endRow, column + 10);
            excelWorksheet.Cells[row, column + 11].Formula = CreateSumFormula(excelWorksheet, startRow, column + 11, endRow, column + 11);
            excelWorksheet.Cells[row, column + 12].Formula = CreateSumFormula(excelWorksheet, startRow, column + 12, endRow, column + 12);
            excelWorksheet.Cells[row, column + 13].Formula = CreateSumFormula(excelWorksheet, startRow, column + 13, endRow, column + 13);
            excelWorksheet.Cells[row, column + 14].Formula = CreateSumFormula(excelWorksheet, startRow, column + 14, endRow, column + 14);

            using (ExcelRange range = excelWorksheet.Cells[exportCell.Total.row, exportCell.Total.column, exportCell.Total.row, exportCell.Total.column + 16])
            {
                range.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                range.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                range.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                range.Style.Border.Right.Style = ExcelBorderStyle.Thin;
            }
        }
        private string CreateSumFormula(ExcelWorksheet excelWorksheet, int startRow, int startColumn, int endRow, int endColumn)
        {
            return $"SUM({excelWorksheet.Cells[startRow, startColumn].Address}:{excelWorksheet.Cells[endRow, endColumn].Address})";
        }

        private void LoadBottomInfo(ExcelWorksheet excelWorksheet, int sartRow)
        {
            excelWorksheet.Cells[sartRow, 1].Value = "зав. кафедрой";
            excelWorksheet.Cells[sartRow, 5].Value = "декан факультета";
            excelWorksheet.Cells[sartRow, 13].Value = "начальник УМУ";

            excelWorksheet.Cells[sartRow+2, 1].Value = "почас:";
        }
    }
}

using System;
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
    public partial class ExcelExporter : IExcelExporter
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
                LoadHeaderInfo(mainWorksheet, calculationSheet);
                LoadHeaderListTeacherInfo(mainWorksheet);

                foreach (Teacher teacher in teachers)
                {
                    var worksheet = excelPackage.Workbook.Worksheets.Add(teacher.LastName);

                    LoadHeaderInfo(worksheet, calculationSheet);
                    LoadTeacherInfo(worksheet, teacher);
                    LoadHeaderTeacherLoadDiscipline(worksheet);
                    LoadTeacherLoadDisciplineInfo(worksheet, teacherLoadDisciplines.Where(x => x.Teacher == teacher).ToList());
                }

                LoadHeaderListTeacherInfo(mainWorksheet, teachers);

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

        private void LoadHeaderListTeacherInfo(ExcelWorksheet excelWorksheet)
        {
            int row = exportCell.MainSheetStartHeaderListTeacher.row;
            int column = exportCell.MainSheetStartHeaderListTeacher.column;

            excelWorksheet.Cells[row, column].Value = "Ф.И.О.";
            excelWorksheet.Cells[row, column + 1].Value = "декан";
            excelWorksheet.Cells[row, column + 2].Value = "зав.каф.";
            excelWorksheet.Cells[row, column + 3].Value = "проф.";
            excelWorksheet.Cells[row, column + 4].Value = "доц.";
            excelWorksheet.Cells[row, column + 5].Value = "ст. преп.";
            excelWorksheet.Cells[row, column + 6].Value = "преп.";
            excelWorksheet.Cells[row, column + 7].Value = "ассистент";
            excelWorksheet.Cells[row, column + 8].Value = "ставки";
            excelWorksheet.Cells[row, column + 9].Value = "учебная нагрузка";
            excelWorksheet.Cells[row, column + 10].Value = "лекционная нагрузка";
            excelWorksheet.Cells[row, column + 11].Value = "почас. фонд";

            ExcelRange range = excelWorksheet.Cells[row, column, row, column + 11];
            SetBorder(range);
        }

        private void LoadHeaderListTeacherInfo(ExcelWorksheet excelWorksheet, List<Teacher> teachers)
        {
            int row = exportCell.MainSheetStartListTeacher.row;
            int column = exportCell.MainSheetStartListTeacher.column;
            int counter = 1;

            foreach (Teacher teacher in teachers)
            {
                excelWorksheet.Cells[row, column].Value = counter;
                excelWorksheet.Cells[row, column + 1].Value = teacherInitialsExcelConverter.Convert(teacher);
                excelWorksheet.Cells[row, academicTitleToNameExcelConverter.ConvertToColumn(teacher.AcademicTitle)].Value = rateExcelConverter.Convert(teacher.Rate);
                excelWorksheet.Cells[row, column + 9].Value = rateExcelConverter.Convert(teacher.Rate);
                excelWorksheet.Cells[row, column + 10].Formula = $"{teacher.LastName}!R12";
                excelWorksheet.Cells[row, column + 11].Formula = $"{teacher.LastName}!F12";

                counter++;
                row++;
            }

            ExcelRange range = excelWorksheet.Cells[exportCell.MainSheetStartListTeacher.row, column, row - 1, column + 12];
            SetBorder(range);

            ExcelRange rangeTeacherInitials = excelWorksheet.Cells[exportCell.MainSheetStartListTeacher.row, column + 1, row - 1, column + 1];
            SetBoldBorder(rangeTeacherInitials);
        }

        private string CreateSumFormula(ExcelWorksheet excelWorksheet, int startRow, int startColumn, int endRow, int endColumn)
        {
            return $"SUM({excelWorksheet.Cells[startRow, startColumn].Address}:{excelWorksheet.Cells[endRow, endColumn].Address})";
        }

        private void SetBorder(ExcelRange range)
        {
            range.Style.Border.Top.Style = ExcelBorderStyle.Thin;
            range.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
            range.Style.Border.Left.Style = ExcelBorderStyle.Thin;
            range.Style.Border.Right.Style = ExcelBorderStyle.Thin;
        }

        private void SetBoldBorder(ExcelRange range)
        {
            range.Style.Border.Top.Style = ExcelBorderStyle.Thick;
            range.Style.Border.Bottom.Style = ExcelBorderStyle.Thick;
            range.Style.Border.Left.Style = ExcelBorderStyle.Thick;
            range.Style.Border.Right.Style = ExcelBorderStyle.Thick;
        }
    }
}

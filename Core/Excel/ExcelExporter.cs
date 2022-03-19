using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Excel.Constants;
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
        private readonly ExportRowsColumns exportRowsColumns;

        /// <summary>
        /// ctor.
        /// </summary>
        public ExcelExporter()
        {
            ///TODO перенести в файл конфига (чтобы не было исключения про лицензию)
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            exportRowsColumns = new ExportRowsColumns();
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
                //Set some properties of the Excel document
                excelPackage.Workbook.Properties.Author = "VDWWD";
                excelPackage.Workbook.Properties.Title = "Title of Document";
                excelPackage.Workbook.Properties.Subject = "EPPlus demo export data";
                excelPackage.Workbook.Properties.Created = DateTime.Now;


                ExcelWorksheet mainWorksheet = excelPackage.Workbook.Worksheets.Add("Итого");


                List<ExcelWorksheet> teacherWorksheets = new List<ExcelWorksheet>();
                foreach (Teacher teacher in teachers)
                {
                    teacherWorksheets.Add(excelPackage.Workbook.Worksheets.Add(teacher.LastName));
                }
                foreach (ExcelWorksheet excelWorksheet in teacherWorksheets)
                {
                    LoadHeaderInfo(excelWorksheet);
                }

                excelPackage.Save();
            }
        }

        private void LoadHeaderInfo(ExcelWorksheet excelWorksheet,CalculationSheet calculationSheet)
        {
            excelWorksheet.Cells[exportRowsColumns.NamePzuStart.row,
                exportRowsColumns.NamePzuStart.column,
                exportRowsColumns.NamePzuEnd.row,
                exportRowsColumns.NamePzuEnd.column].Merge = true;

            excelWorksheet.Cells[exportRowsColumns.DistributionTeacherLoadStart.row,
                exportRowsColumns.DistributionTeacherLoadStart.column,
                exportRowsColumns.DistributionTeacherLoadEnd.row,
                exportRowsColumns.DistributionTeacherLoadEnd.column].Merge = true;

            excelWorksheet.Cells[exportRowsColumns.NamePzuStart.row, exportRowsColumns.NamePzuStart.column].Value = "Пензенский Государственный Университет";
            excelWorksheet.Cells[exportRowsColumns.NamePzuStart.row, exportRowsColumns.NamePzuStart.column].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;

            excelWorksheet.Cells[exportRowsColumns.DistributionTeacherLoadStart.row, exportRowsColumns.DistributionTeacherLoadStart.column].Value = "Распределение учебной нагрузки";
            excelWorksheet.Cells[exportRowsColumns.DistributionTeacherLoadStart.row, exportRowsColumns.DistributionTeacherLoadStart.column].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;

            excelWorksheet.Cells[exportRowsColumns.Approve.row, exportRowsColumns.Approve.column].Value = "УТВЕРЖДАЮ";
            excelWorksheet.Cells[exportRowsColumns.Prorector.row, exportRowsColumns.Prorector.column].Value = "Проректор по учебной работе";
        }
    }
}

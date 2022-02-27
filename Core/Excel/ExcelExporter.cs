using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Core.Excel.Interfaces;
using Data.Models;
using ExcelDataReader;

namespace Core.Excel
{
    /// <summary>
    /// Реализация IExcelExporter.
    /// </summary>
    public class ExcelExporter : IExcelExporter
    {
        public ICollection<DisciplineAcademicPlan> ExportCalculationSheet(string path)
        {
            CalculationSheet calculationSheet = new CalculationSheet();

            var stream = File.Open(path, FileMode.Open, FileAccess.Read);
            var reader = ExcelReaderFactory.CreateReader(stream);
            var result = reader.AsDataSet();
            var table = result.Tables.Cast<DataTable>().ToList().First();


            for (var i = 1; i < table.Rows.Count; i++)
            {
                for (var j = 0; j < table.Columns.Count; j++)
                {
                    var data = table.Rows[i][j];
                }
            }

        
         Test(calculationSheet,table);

            return null;
        }

        private void Test(CalculationSheet calculationSheet, DataTable table)
        {
            calculationSheet.Department = table.Rows[RowColumnConstants.DepartmentRow][RowColumnConstants.DepartmentColumn].ToString();
            calculationSheet.Faculty = table.Rows[RowColumnConstants.FacultyRow][RowColumnConstants.FacultyColumn].ToString();
            calculationSheet.AcademicYear = table.Rows[RowColumnConstants.AcademicYearRow][RowColumnConstants.AcademicYearColumn].ToString();

            var data = (table.Rows[RowColumnConstants.TotalStudentsBudgetRow][
                RowColumnConstants.TotalStudentsBudgetColumn]);
            double a = Convert.ToDouble(data);
            calculationSheet.TotalStudentsBudget = (int)(data);
            calculationSheet.TotalStudentsContract = (int)(table.Rows[RowColumnConstants.TotalStudentsContractRow][RowColumnConstants.TotalStudentsContractColumn]);
            calculationSheet.TotalHours = (int)(table.Rows[RowColumnConstants.TotalHoursRow][RowColumnConstants.TotalHoursColumn]);
        }
    }
}

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
        public CalculationSheet ExportCalculationSheet(string path)
        {
            CalculationSheet calculationSheet = new CalculationSheet();

            var stream = File.Open(path, FileMode.Open, FileAccess.Read);
            var reader = ExcelReaderFactory.CreateReader(stream);
            var result = reader.AsDataSet();
            var table = result.Tables.Cast<DataTable>().ToList().First();

            LoadMainInformation(calculationSheet, table);
           calculationSheet.CalculationSheetDisciplines=LoadDisciplineAcademicPlan(table);
            return null;
        }

        private void LoadMainInformation(CalculationSheet calculationSheet, DataTable table)
        {
            calculationSheet.Department = table.Rows[ExportRowColumnConstants.DepartmentRow][ExportRowColumnConstants.DepartmentColumn].ToString();
            calculationSheet.Faculty = table.Rows[ExportRowColumnConstants.FacultyRow][ExportRowColumnConstants.FacultyColumn].ToString();
            calculationSheet.AcademicYear = table.Rows[ExportRowColumnConstants.AcademicYearRow][ExportRowColumnConstants.AcademicYearColumn].ToString();


            calculationSheet.TotalStudentsBudget = Convert.ToDouble(table.Rows[ExportRowColumnConstants.TotalStudentsBudgetRow][ExportRowColumnConstants.TotalStudentsBudgetColumn]);
            calculationSheet.TotalStudentsContract = Convert.ToDouble(table.Rows[ExportRowColumnConstants.TotalStudentsContractRow][ExportRowColumnConstants.TotalStudentsContractColumn]);
            calculationSheet.TotalHours = Convert.ToDouble(table.Rows[ExportRowColumnConstants.TotalHoursRow][ExportRowColumnConstants.TotalHoursColumn]);

            int row = ExportRowColumnConstants.TotalHoursStartRow;
            int column = ExportRowColumnConstants.TotalHoursStartColumn;
            calculationSheet.TotalHoursLecture = Convert.ToDouble(table.Rows[row][column]);
            calculationSheet.TotalHoursLaboratory = Convert.ToDouble(table.Rows[row][column + 1]);
            calculationSheet.TotalHoursPracticalWorks = Convert.ToDouble(table.Rows[row][column + 2]);
            calculationSheet.TotalHoursKpKr = Convert.ToDouble(table.Rows[row][column + 3]);
            calculationSheet.TotalHoursControlWorks = Convert.ToDouble(table.Rows[row][column + 4]);
            calculationSheet.TotalHoursExam = Convert.ToDouble(table.Rows[row][column + 5]);
            calculationSheet.TotalHoursTest = Convert.ToDouble(table.Rows[row][column + 6]);
            calculationSheet.TotalHoursСonsultation = Convert.ToDouble(table.Rows[row][column + 7]);
            calculationSheet.TotalHoursPracticum = Convert.ToDouble(table.Rows[row][column + 8]);
            calculationSheet.TotalHoursGia = Convert.ToDouble(table.Rows[row][column + 9]);
        }

        private List<CalculationSheetDiscipline> LoadDisciplineAcademicPlan(DataTable table)
        {
            List<CalculationSheetDiscipline> calculationSheetDisciplines = new List<CalculationSheetDiscipline>();

            for (int i = ExportRowColumnConstants.CalculationSheetDisciplineStartRow; i < table.Rows.Count; i++)
            {
                CalculationSheetDiscipline calculationSheetDiscipline = new CalculationSheetDiscipline();
                int column = ExportRowColumnConstants.CalculationSheetDisciplineStartColumn;

                calculationSheetDiscipline.Index = table.Rows[i][column].ToString();
                calculationSheetDiscipline.Name = table.Rows[i][column + 1].ToString();

                calculationSheetDiscipline.Semester = Convert.ToInt32(table.Rows[i][column + 2]);
                calculationSheetDiscipline.LengthSemester = table.Rows[i][column + 3].ToString();

                calculationSheetDiscipline.CountGroups = Convert.ToInt32(table.Rows[i][column + 4]);
                calculationSheetDiscipline.Groups = table.Rows[i][column + 5].ToString();

                calculationSheetDiscipline.Stream = table.Rows[i][column + 6].ToString();
                calculationSheetDiscipline.StreamPracticumLabrotory = table.Rows[i][column + 7].ToString();

                calculationSheetDiscipline.StudentsBudget = Convert.ToInt32(table.Rows[i][column + 8]);
                calculationSheetDiscipline.StudentsContract = Convert.ToInt32(table.Rows[i][column + 9]);

                calculationSheetDiscipline.CountLecture = ToInt32(table.Rows[i][column + 10]);
                calculationSheetDiscipline.CountLaboratoryWork = ToInt32(table.Rows[i][column + 11]);
                calculationSheetDiscipline.CountPracticum = ToInt32(table.Rows[i][column + 12]);
                calculationSheetDiscipline.CountKp = ToInt32(table.Rows[i][column + 13]);
                calculationSheetDiscipline.CountKr = ToInt32(table.Rows[i][column + 14]);
                calculationSheetDiscipline.CountСontrolWork = ToInt32(table.Rows[i][column + 15]);
                calculationSheetDiscipline.CountExam = ToInt32(table.Rows[i][column + 16]);
                calculationSheetDiscipline.CountTest = ToInt32(table.Rows[i][column + 17]);
                calculationSheetDiscipline.CountDifferentiatedTest = ToInt32(table.Rows[i][column + 18]);
                calculationSheetDiscipline.CountEtc = ToInt32(table.Rows[i][column + 19]);


                calculationSheetDiscipline.HoursLecture = Convert.ToDouble(table.Rows[i][column + 20]);
                calculationSheetDiscipline.HoursLaboratoryWork = Convert.ToDouble(table.Rows[i][column + 21]);
                calculationSheetDiscipline.HoursPracticumLesson = Convert.ToDouble(table.Rows[i][column + 22]);
                calculationSheetDiscipline.HoursKpKr = Convert.ToDouble(table.Rows[i][column + 23]);
                calculationSheetDiscipline.HoursСontrolWork = Convert.ToDouble(table.Rows[i][column + 24]);
                calculationSheetDiscipline.HoursExam = Convert.ToDouble(table.Rows[i][column + 25]);
                calculationSheetDiscipline.HoursTest = Convert.ToDouble(table.Rows[i][column + 26]);
                calculationSheetDiscipline.HoursConsultation = Convert.ToDouble(table.Rows[i][column + 27]);
                calculationSheetDiscipline.HoursPracticum = Convert.ToDouble(table.Rows[i][column + 28]);
                calculationSheetDiscipline.HoursGia = Convert.ToDouble(table.Rows[i][column + 29]);
                calculationSheetDiscipline.HoursTotal = Convert.ToDouble(table.Rows[i][column + 30]);

                calculationSheetDisciplines.Add(calculationSheetDiscipline);
            }

            return calculationSheetDisciplines;
        }

        private int ToInt32(object item) => item is DBNull ? 0 : Convert.ToInt32(item);
    }
}

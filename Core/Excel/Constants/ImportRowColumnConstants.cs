using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Excel
{
    /// <summary>
    /// Расположение ячеек в таблице.
    /// Со смещением -1.
    /// </summary>
    public class ImportRowColumnConstants
    {
        public const int DepartmentRow = 1;
        public const int DepartmentColumn = 1;

        public const int FacultyRow = 1;
        public const int FacultyColumn = 2;

        public const int AcademicYearRow = 1;
        public const int AcademicYearColumn = 5;

        public const int TotalStudentsBudgetRow = 1;
        public const int TotalStudentsBudgetColumn = 10;

        public const int TotalStudentsContractRow = 1;
        public const int TotalStudentsContractColumn = 13;

        public const int TotalHoursRow = 1;
        public const int TotalHoursColumn = 19;

        public const int TotalHoursStartRow = 3;
        public const int TotalHoursStartColumn = 20;

        public const int CalculationSheetDisciplineStartRow = 5;
        public const int CalculationSheetDisciplineStartColumn = 0;

    }
}

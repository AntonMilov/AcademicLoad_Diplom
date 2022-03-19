using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Excel.Interfaces
{
    /// <summary>
    /// Интерфейс для экспорта Excel.
    /// </summary>
    public interface IExcelExporter
    {
        /// <summary>
        /// Экспортировать.
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        void ExportTeacherLoadDiscipline(string path,
            CalculationSheet calculationSheet,
            List<Teacher> teachers,
            List<TeacherLoadDiscipline> teacherLoadDisciplines);
    }
}

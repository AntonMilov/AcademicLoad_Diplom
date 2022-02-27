using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Models;

namespace Core.Services.Interfaces
{
    public interface ICalculationSheetService
    {
        /// <summary>
        /// Добавит расчетный лист кафедральной нагрузки.
        /// </summary>
        void AddCalculationSheet(string path);

        /// <summary>
        /// Преподаватели.
        /// </summary>
        ICollection<DisciplineAcademicPlan> DisciplineAcademicPlans { get; set; }
    }
}

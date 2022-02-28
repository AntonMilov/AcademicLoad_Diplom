using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Excel.Interfaces;
using Core.Services.Interfaces;
using Data.Models;

namespace Core.Services
{
    public class CalculationSheetService : ICalculationSheetService
    {
        private ICollection<CalculationSheetDiscipline> disciplineAcademicPlans;
        private readonly IExcelExporter excelExporter;

        /// <summary>
        /// .ctor
        /// </summary>
        public CalculationSheetService(IExcelExporter excelExporter)
        {
            this.excelExporter = excelExporter;
            disciplineAcademicPlans = new List<CalculationSheetDiscipline>();
        }

        /// <summary>
        /// 
        /// </summary>
        public ICollection<CalculationSheetDiscipline> DisciplineAcademicPlans
        {
            get => disciplineAcademicPlans;
            set => disciplineAcademicPlans = value;
        }

        public void AddCalculationSheet(string path)
        {
            excelExporter.ExportCalculationSheet(path);
        }
    }
}

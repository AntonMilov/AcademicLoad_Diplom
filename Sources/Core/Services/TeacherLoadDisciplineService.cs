using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Excel.Interfaces;
using Core.Services.Interfaces;
using Data.Enums;
using Data.Models;

namespace Core.Services
{
    /// <summary>
    /// <see cref="ITeacherLoadDisciplineService"/>
    /// </summary>
    public class TeacherLoadDisciplineService : ITeacherLoadDisciplineService
    {
        private readonly СalculatorTeacherLoadDiscipline сalculatorTeacherLoadDiscipline;
        private readonly IExcelExporter excelExporter;
        private List<TeacherLoadDiscipline> teacherLoadDisciplines;

        /// <summary>
        /// ctor.
        /// </summary>
        public TeacherLoadDisciplineService(IExcelExporter excelExporter)
        {
            this.excelExporter = excelExporter;
            сalculatorTeacherLoadDiscipline = new СalculatorTeacherLoadDiscipline();

            teacherLoadDisciplines = new List<TeacherLoadDiscipline>();
        }

        /// <inheritdoc/>
        public List<TeacherLoadDiscipline> TeacherLoadDisciplines
        {
            get => teacherLoadDisciplines;
            set => teacherLoadDisciplines = value;
        }

        /// <inheritdoc/>
        public void AddTeacherLoadDiscipline(TeacherLoadDiscipline teacherLoadDiscipline, CalculationSheetDiscipline calculationSheetDiscipline)
        {
            TeacherLoadDisciplines.Add(teacherLoadDiscipline);

            switch (teacherLoadDiscipline.TeacherLoadDisciplineFlags)
            {
                case TeacherLoadDisciplineFlags.IsMainLecture:
                    сalculatorTeacherLoadDiscipline.CalculateForMainLecture(teacherLoadDiscipline, calculationSheetDiscipline);
                    break;
                case TeacherLoadDisciplineFlags.IsAdditionalLecture:
                    сalculatorTeacherLoadDiscipline.CalculateForAdditionalLecture(teacherLoadDiscipline, calculationSheetDiscipline);
                    break;
                case TeacherLoadDisciplineFlags.IsNotLecture:
                    сalculatorTeacherLoadDiscipline.CalculateForNotLecture(teacherLoadDiscipline, calculationSheetDiscipline);
                    break;
            }

            сalculatorTeacherLoadDiscipline.CheckFlags(teacherLoadDiscipline, calculationSheetDiscipline);

            сalculatorTeacherLoadDiscipline.CalculateDividerGroups(teacherLoadDiscipline, calculationSheetDiscipline);

            calculationSheetDiscipline.TeacherLoadDisciplines.Add(teacherLoadDiscipline);
            calculationSheetDiscipline.HasTeacherLoadDisciplines = calculationSheetDiscipline.TeacherLoadDisciplines.Any();

            teacherLoadDiscipline.DividerGroups = calculationSheetDiscipline.DividerGroups;

            foreach (var variable in calculationSheetDiscipline.TeacherLoadDisciplines)
            {
                variable.Update();
            }
        }

        public void Clear()
        {
            teacherLoadDisciplines = null;
            teacherLoadDisciplines =  new List<TeacherLoadDiscipline>();
        }

        /// <inheritdoc/>
        public void DeleteTeacherLoadDiscipline(TeacherLoadDiscipline teacherLoadDiscipline, CalculationSheetDiscipline calculationSheetDiscipline)
        {
            TeacherLoadDisciplines.Remove(teacherLoadDiscipline);

            calculationSheetDiscipline.TeacherLoadDisciplines.Remove(teacherLoadDiscipline);
            calculationSheetDiscipline.HasTeacherLoadDisciplines = calculationSheetDiscipline.TeacherLoadDisciplines.Any();

            foreach (var group in teacherLoadDiscipline.Groups)
            {
                calculationSheetDiscipline.DividerGroups[group.Name]--;
            }
        }

        /// <inheritdoc/>
        public void ExportTeacherLoadDisciplines(string path, 
            CalculationSheet calculationSheet, 
            List<Teacher> teachers)
        {
            excelExporter.ExportTeacherLoadDiscipline(path, calculationSheet, teachers, TeacherLoadDisciplines);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        private List<TeacherLoadDiscipline> teacherLoadDisciplines;
        private readonly СalculatorTeacherLoadDiscipline сalculatorTeacherLoadDiscipline = new СalculatorTeacherLoadDiscipline();

        /// <summary>
        /// ctor.
        /// </summary>
        public TeacherLoadDisciplineService()
        {
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

            сalculatorTeacherLoadDiscipline.CalculateDividerGroups(teacherLoadDiscipline, calculationSheetDiscipline);

            calculationSheetDiscipline.TeacherLoadDisciplines.Add(teacherLoadDiscipline);
            teacherLoadDiscipline.DividerGroups = calculationSheetDiscipline.DividerGroups;

            foreach (var variable in calculationSheetDiscipline.TeacherLoadDisciplines)
            {
                variable.Update();
            }
        }

        /// <inheritdoc/>
        public void DeleteTeacherLoadDiscipline(TeacherLoadDiscipline teacherLoadDiscipline, CalculationSheetDiscipline calculationSheetDiscipline)
        {
            TeacherLoadDisciplines.Remove(teacherLoadDiscipline);

            calculationSheetDiscipline.TeacherLoadDisciplines.Remove(teacherLoadDiscipline);

            foreach (var group in teacherLoadDiscipline.Groups)
            {
                calculationSheetDiscipline.DividerGroups[group.Name]--;
            }
        }
    }
}

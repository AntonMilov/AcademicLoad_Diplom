﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Services.Interfaces;
using Data.Models;

namespace Core.Services
{
    /// <summary>
    /// <see cref="ITeacherLoadDisciplineService"/>
    /// </summary>
    public class TeacherLoadDisciplineService: ITeacherLoadDisciplineService
    {
        private List<TeacherLoadDiscipline> teacherLoadDisciplines;

        /// <summary>
        /// ctor.
        /// </summary>
        public TeacherLoadDisciplineService()
        {
            teacherLoadDisciplines = new List<TeacherLoadDiscipline>();
        }

        public List<TeacherLoadDiscipline> TeacherLoadDisciplines
        {
            get => teacherLoadDisciplines;
            set => teacherLoadDisciplines = value;
        }

        public void AddTeacherLoadDiscipline(TeacherLoadDiscipline teacherLoadDiscipline, CalculationSheetDiscipline calculationSheetDiscipline)
        {
            TeacherLoadDisciplines.Add(teacherLoadDiscipline);

            AddInfromation(teacherLoadDiscipline, calculationSheetDiscipline);

            calculationSheetDiscipline.TeacherLoadDisciplines.Add(teacherLoadDiscipline);
        }

        public void DeleteTeacherLoadDiscipline(TeacherLoadDiscipline teacherLoadDiscipline, CalculationSheetDiscipline calculationSheetDiscipline)
        {
            TeacherLoadDisciplines.Remove(teacherLoadDiscipline);

            calculationSheetDiscipline.TeacherLoadDisciplines.Remove(teacherLoadDiscipline);
        }

        private void AddInfromation(TeacherLoadDiscipline teacherLoadDiscipline, CalculationSheetDiscipline calculationSheetDiscipline)
        {
            teacherLoadDiscipline.Semester = calculationSheetDiscipline.Semester;

            teacherLoadDiscipline.HoursLecture = calculationSheetDiscipline.HoursLecture;
            teacherLoadDiscipline.HoursLaboratoryWork = calculationSheetDiscipline.HoursLaboratoryWork;
            teacherLoadDiscipline.HoursPracticum = calculationSheetDiscipline.HoursPracticum;
            teacherLoadDiscipline.HoursKpKr = calculationSheetDiscipline.HoursKpKr;
            teacherLoadDiscipline.HoursСontrolWork = calculationSheetDiscipline.HoursСontrolWork;
            teacherLoadDiscipline.HoursExam = calculationSheetDiscipline.HoursExam;
            teacherLoadDiscipline.HoursTest = calculationSheetDiscipline.HoursTest;
            teacherLoadDiscipline.HoursConsultation = calculationSheetDiscipline.HoursConsultation;
        }
    }
}

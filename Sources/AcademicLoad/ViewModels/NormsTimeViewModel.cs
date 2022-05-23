using Data;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AcademicLoadModule.ViewModels
{
    /// <summary>
    /// VM для норм времени
    /// </summary>
    public class NormsTimeViewModel : BindableBase
    {
        private double studentsTest;
        private double kp;
        private double kr;
        private NormsOfTime normsOfTime = NormsOfTime.getInstance();

        /// <summary>
        /// ctor.
        /// </summary>
        public NormsTimeViewModel()
        {
            Kp = normsOfTime.Kp;
            Kr = normsOfTime.Kr;
            StudentsTest = normsOfTime.StudentsTest;
        }

        public double Kp
        {
            get => kp;
            set
            {
                SetProperty(ref kp, value);
                normsOfTime.Kp = Kp;
            }
        }

        public double Kr
        {
            get => kr;
            set
            {
                SetProperty(ref kr, value);
                normsOfTime.Kr = Kr;
            }
        }

        public double StudentsTest
        {
            get => studentsTest;
            set
            {
                SetProperty(ref studentsTest, value);
                normsOfTime.StudentsTest = StudentsTest;
            }
        }
    }
}

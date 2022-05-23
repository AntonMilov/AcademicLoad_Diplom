using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    /// <summary>
    /// Нормы времени для расчета.
    /// </summary>
    public  class NormsOfTime : BindableBase
    {
        private double studentsTest;
             private double kp;
             private double kr;


        private static NormsOfTime instance;

        private NormsOfTime()
        {
            StudentsTest = 0.25;
            Kp = 2.5;
            Kr = 1.5;
        }

        public static NormsOfTime getInstance()
        {
            if (instance == null)
                instance = new NormsOfTime();
            return instance;
        }


        /// <summary>
        /// Норма времени на проведение зачета на одного студента.
        /// </summary>
        public  double StudentsTest
        {
            get => studentsTest;
            set => SetProperty(ref studentsTest, value);


        }

        /// <summary>
        /// Норма времени на курсовой проект.
        /// </summary>
        public  double Kp
        {
            get => kp;
            set => SetProperty(ref kp, value);

        }


        /// <summary>
        /// Норма времени на курсовую работу.
        /// </summary>
        public double Kr
        {
            get => kr;
            set => SetProperty(ref kr, value);

        }

    }
}

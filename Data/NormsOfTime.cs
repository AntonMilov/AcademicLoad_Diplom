using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    /// <summary>
    /// Нормы времени для расчета.
    /// </summary>
    public static class NormsOfTime
    {
        /// <summary>
        /// Норма времени на проведение зачета на одного студента.
        /// </summary>
        public static double StudentsTest => 0.25;

        /// <summary>
        /// Норма времени на курсовой проект.
        /// </summary>
        public static double Kp => 2.5;

        /// <summary>
        /// Норма времени на курсовую работу .
        /// </summary>
        public static double Kr => 1.5;
    }
}

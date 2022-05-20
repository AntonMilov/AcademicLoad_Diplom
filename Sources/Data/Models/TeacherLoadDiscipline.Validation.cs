using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    /// <summary>
    /// Модель назначения преподавателя к  дисциплине.
    /// </summary>
    public partial class TeacherLoadDiscipline
    {
        #region Hours
        /// <summary>
        /// 
        /// </summary>
        public double HoursLecture
        {
            get => hoursLecture;
            set
            {
                if (hoursLectureMaxValue == maxValue)
                {
                    hoursLectureMaxValue = value;
                }

                if (value > hoursLectureMaxValue || value < 0)
                {
                    SetProperty(ref hoursLecture, hoursLecture);
                    return;
                }
               
                SetProperty(ref hoursLecture, value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public double HoursLaboratoryWork
        {
            get => hoursLaboratoryWork;
            set
            {
                if (hoursLaboratoryWorkMaxValue == maxValue)
                {
                    hoursLaboratoryWorkMaxValue = value;
                }

                if (value > hoursLaboratoryWorkMaxValue || value < 0)
                {
                    SetProperty(ref hoursLaboratoryWork, hoursLaboratoryWork);
                    return;
                }
             
                SetProperty(ref hoursLaboratoryWork, value);
            }
        }

        /// <summary>
        /// Часы отведенные для практики (рукводитель).
        /// </summary>
        public double HoursPracticum
        {
            get => hoursPracticum;
            set
            {
                if (hoursPracticumMaxValue == maxValue)
                {
                    hoursPracticumMaxValue = value;
                }

                if (value > hoursPracticumMaxValue || value < 0)
                {
                    SetProperty(ref hoursPracticum, hoursPracticum);
                    return;
                }
               
                SetProperty(ref hoursPracticum, value);
            }
        }

        /// <summary>
        /// КП, КР (так называется в таблице).
        /// </summary>
        public double HoursKpKr
        {
            get => hoursKpKr;
            set
            {
                if (hoursKpKrMaxValue == maxValue)
                {
                    hoursKpKrMaxValue = value;
                }

                if (value > hoursKpKrMaxValue || value < 0)
                {
                    SetProperty(ref hoursKpKr, hoursKpKr);
                    return;
                }
              
                SetProperty(ref hoursKpKr, value);
            }
        }

        /// <summary>
        /// Часы отведенные для  контрольных работ.
        /// </summary>
        public double HoursСontrolWork
        {
            get => hoursСontrolWork;
            set
            {
                if (hoursСontrolWorkMaxValue == maxValue)
                {
                    hoursСontrolWorkMaxValue = value;
                }

                if (value > hoursСontrolWorkMaxValue || value < 0)
                {
                    SetProperty(ref hoursСontrolWork, hoursСontrolWork);
                    return;
                }
              
                SetProperty(ref hoursСontrolWork, value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public double HoursExam
        {
            get => hoursExam;
            set
            {
                if (hoursExamMaxValue == maxValue)
                {
                    hoursExamMaxValue = value;
                }

                if (value > hoursExamMaxValue)
                {
                    SetProperty(ref hoursExam, hoursExam);
                    return;
                }
              
                SetProperty(ref hoursExam, value);
            }
        }

        /// <summary>
        /// Часы отведенные для зачета.
        /// </summary>
        public double HoursTest
        {
            get => hoursTest;
            set
            {
                if (hoursTestMaxValue == maxValue)
                {
                    hoursTestMaxValue = value;
                }

                if (value > hoursTestMaxValue || value < 0)
                {
                    SetProperty(ref hoursTest, hoursTest);
                    return;
                }
          
                SetProperty(ref hoursTest, value);
            }
        }


        /// <summary>
        /// 
        /// </summary>
        public double HoursConsultation
        {
            get => hoursConsultation;
            set
            {
                if (hoursConsultationMaxValue == maxValue)
                {
                    hoursConsultationMaxValue = value;
                }

                if (value > hoursConsultationMaxValue || value < 0)
                {
                    SetProperty(ref hoursConsultation, hoursConsultation);
                    return;
                }
               
                SetProperty(ref hoursConsultation, value);
            }
        }

        /// <summary>
        /// Часы под прочую нагрузку по ВПО.
        /// </summary>
        public double HoursOtherLoadVpo
        {
            get => hoursOtherLoadVpo;
            set
            {
                if (hoursOtherLoadVpoMaxValue == maxValue)
                {
                    hoursOtherLoadVpoMaxValue = value;
                }

                if (value > hoursOtherLoadVpoMaxValue || value < 0)
                {
                    SetProperty(ref hoursOtherLoadVpo, hoursOtherLoadVpo);
                    return;
                }
               
                SetProperty(ref hoursOtherLoadVpo, value);
            }
        }

        /// <summary>
        /// Часы отведенные для подготовки аспирантов, интернов, ординаторов.
        /// </summary>
        public double HoursTraining
        {
            get => hoursTraining;
            set
            {
                if (hoursTrainingMaxValue == maxValue)
                {
                    hoursTrainingMaxValue = value;
                }

                if (value > hoursTrainingMaxValue || value < 0)
                {
                    SetProperty(ref hoursTraining, hoursTraining);
                    return;
                }
              
                SetProperty(ref hoursTraining, value);
            }
        }

        /// <summary>
        /// Всего часов за осенний семестр.
        /// </summary>
        public double HoursTotalFallSemester
        {
            get => hoursTotalFallSemester;
            set => SetProperty(ref hoursTotalFallSemester, value);
        }

        /// <summary>
        /// Всего часов за весенний семестр.
        /// </summary>
        public double HoursTotalSpringSemester
        {
            get => hoursTotalSpringSemester;
            set => SetProperty(ref hoursTotalSpringSemester, value);
        }

        /// <summary>
        /// Всего за год нагрузка.
        /// </summary>
        public double HoursTotalYearLoad
        {
            get => hoursTotalYearLoad;
            set => SetProperty(ref hoursTotalYearLoad, value);
        }
        #endregion
    }
}

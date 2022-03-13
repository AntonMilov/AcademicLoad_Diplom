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
        private Dictionary<string, string> errors = new Dictionary<string, string>();

        /// <summary>
        /// Cообщение о ошибки валидации <inheritdoc/>.
        /// </summary>
        public string this[string columnName] => errors.ContainsKey(columnName) ? errors[columnName] : null;

        /// <inheritdoc/>
        public string Error => throw new System.NotImplementedException();

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

                if (value > hoursLectureMaxValue)
                {
                    SetProperty(ref hoursLecture, hoursLecture);
                    return;
                }
                else
                {
                    errors[nameof(HoursLecture)] = null;
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
            set => SetProperty(ref hoursLaboratoryWork, value);
        }

        /// <summary>
        /// Часы отведенные для практики (рукводитель).
        /// </summary>
        public double HoursPracticum
        {
            get => hoursPracticum;
            set => SetProperty(ref hoursPracticum, value);
        }

        /// <summary>
        /// КП, КР (так называется в таблице).
        /// </summary>
        public double HoursKpKr
        {
            get => hoursKpKr;
            set => SetProperty(ref hoursKpKr, value);
        }

        /// <summary>
        /// Часы отведенные для  контрольных работ.
        /// </summary>
        public double HoursСontrolWork
        {
            get => hoursСontrolWork;
            set => SetProperty(ref hoursСontrolWork, value);
        }

        /// <summary>
        /// 
        /// </summary>
        public double HoursExam
        {
            get => hoursExam;
            set => SetProperty(ref hoursExam, value);
        }


        /// <summary>
        /// Часы отведенные для зачета.
        /// </summary>
        public double HoursTest
        {
            get => hoursTest;
            set => SetProperty(ref hoursTest, value);
        }


        /// <summary>
        /// 
        /// </summary>
        public double HoursConsultation
        {
            get => hoursConsultation;
            set => SetProperty(ref hoursConsultation, value);
        }


        /// <summary>
        /// Часы под прочую нагрузку по ВПО.
        /// </summary>
        public double HoursOtherLoadVpo
        {
            get => hoursOtherLoadVpo;
            set => SetProperty(ref hoursOtherLoadVpo, value);
        }


        /// <summary>
        /// Часы отведенные для подготовки аспирантов, интернов, ординаторов.
        /// </summary>
        public double HoursTraining
        {
            get => hoursTraining;
            set => SetProperty(ref hoursTraining, value);
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

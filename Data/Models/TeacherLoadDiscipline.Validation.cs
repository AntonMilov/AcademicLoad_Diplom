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
        public string this[string columnName]
        {
            get
            {
                string error = String.Empty;
                switch (columnName)
                {
                    case "HoursLecture":
                        if ((HoursLecture < 0) || (HoursLecture > 100))
                        {
                            error = "Значение больше 100";
                        }
                        break;
                    case "HoursLaboratoryWork":
                        if ((HoursLaboratoryWork < 0) || (HoursLaboratoryWork > 100))
                        {
                            error = "Возраст должен бытьjjjj больше 0 и меньше 100";
                        }
                        break;

                }
                return error;
            }
        }

    }
}

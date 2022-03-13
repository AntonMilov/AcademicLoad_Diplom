using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    /// <summary>
    /// Модель для строк в таблице расчетного листа кафедральной нагрузки.
    /// </summary>
    public partial class CalculationSheetDiscipline
    {
        private ObservableCollection<TeacherLoadDiscipline> teacherLoadDisciplines =
            new ObservableCollection<TeacherLoadDiscipline>();

        public ObservableCollection<TeacherLoadDiscipline> TeacherLoadDisciplines
        {
            get => teacherLoadDisciplines;
            set => teacherLoadDisciplines = value;
        }
    }
}

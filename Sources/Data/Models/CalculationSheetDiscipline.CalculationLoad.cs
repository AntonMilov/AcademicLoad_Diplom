using Prism.Mvvm;
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
    public partial class CalculationSheetDiscipline : BindableBase
    {
        private bool hasTeacherLoadDisciplines;
        private ObservableCollection<TeacherLoadDiscipline> teacherLoadDisciplines =
            new ObservableCollection<TeacherLoadDiscipline>();

        public ObservableCollection<TeacherLoadDiscipline> TeacherLoadDisciplines
        {
            get => teacherLoadDisciplines;
            set => teacherLoadDisciplines = value;
        }

        public bool HasTeacherLoadDisciplines
        {
            get => hasTeacherLoadDisciplines;
            set => SetProperty(ref hasTeacherLoadDisciplines, value);
         
        }

        public Dictionary<string, int> DividerGroups = new Dictionary<string, int>();
    }
}


using Prism.Mvvm;

namespace Data.Models
{
    /// <summary>
    /// Модель учебной группы.
    /// </summary>
    public class Group : BindableBase
    {
        private string name;
        private int studentsBudget;
        private int studentsContract;

        /// <summary>
        /// Название группы.
        /// </summary>
        public string Name
        {
            get => name;
            set => SetProperty(ref name, value.ToUpper());
        }

        /// <summary>
        /// Всего студентов.
        /// </summary>
        public int Students => StudentsBudget + StudentsContract;

        /// <summary>
        /// Количество студентов на бюджетной основе.
        /// </summary>
        public int StudentsBudget
        {
            get => studentsBudget;
            set => SetProperty(ref studentsBudget, value);
        }

        /// <summary>
        /// Количество студентов на договорной основе.
        /// </summary>
        public int StudentsContract
        {
            get => studentsContract;
            set => SetProperty(ref studentsContract, value);
        }
    }
}

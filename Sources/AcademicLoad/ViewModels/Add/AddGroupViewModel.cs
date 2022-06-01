using Data.Models;
using Prism.Mvvm;

namespace AcademicLoadModule.ViewModels.Add
{
    /// <inheritdoc/>
    public class AddGroupViewModel : BindableBase
    {
        private string name;
        private int studentsBudget = 0;
        private int studentsContract = 0;

        /// <summary>
        /// .ctor
        /// </summary>
        public AddGroupViewModel()
        {

        }

        /// <summary>
        /// Название группы.
        /// </summary>
        public string Name
        {
            get => name;
            set => SetProperty(ref name, value);
        }

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

        /// <summary>
        /// Создание новой учебной группы.
        /// </summary>
        /// <returns></returns>
        public Group CreateGroup()
        {
            return new Group()
            {
              Name = Name,
              StudentsBudget = StudentsBudget,
              StudentsContract = StudentsContract
            };
        }

        /// <summary>
        /// Проверка на заполнение всех полей.
        /// </summary>
        /// <returns></returns>
        public bool CanAddGroup()
        {
            return !string.IsNullOrEmpty(Name) &&
                   (StudentsBudget != 0 ||
                   StudentsContract != 0);
        }
    }
}

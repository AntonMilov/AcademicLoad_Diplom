using Data.Models;
using Prism.Mvvm;

namespace AcademicLoadModule.ViewModels.Add
{
    /// <inheritdoc/>
    public class AddGroupViewModel : BindableBase
    {
        private string name;
        private int students = 0;

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
        /// Количество студентов.
        /// </summary>
        public int Students
        {
            get => students;
            set => SetProperty(ref students, value);
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
              Students = Students
            };
        }

        /// <summary>
        /// Проверка на заполнение всех полей.
        /// </summary>
        /// <returns></returns>
        public bool CanAddGroup()
        {
            return !string.IsNullOrEmpty(Name) &&
                   Students != 0;
        }


    }
}

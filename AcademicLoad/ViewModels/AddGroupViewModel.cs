using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AcademicLoadModule.ViewModels
{
    public class AddGroupViewModel : BindableBase
    {
        private string name;
        private int studnets;

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
        public int Studnets
        {
            get => studnets;
            set => SetProperty(ref studnets, value);
        }
    }
}

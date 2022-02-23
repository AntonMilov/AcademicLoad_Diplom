using System.Collections.ObjectModel;
using Data.Models;
using Prism.Mvvm;

namespace AcademicLoadModule.ViewModels
{

    /// <inheritdoc/>
    public class TeachersViewModel : BindableBase
    {
        /// <summary>
        /// .ctor
        /// </summary>
        public TeachersViewModel()
        {
            Items = new ObservableCollection<Teacher>();
            Items.Add(new Teacher(){FirstName = "azaa",LastName = "gyuu"});
            Items.Add(new Teacher() { FirstName = "azaa", LastName = "gyuu" });
            Items.Add(new Teacher() { FirstName = "azaa", LastName = "gyuu" });
            Items.Add(new Teacher() { FirstName = "azaa", LastName = "gyuu" });
        }

        private ObservableCollection<Teacher> items;


        public ObservableCollection<Teacher> Items
        {
            get => items;
            set => SetProperty(ref items, value);
        }


    }

}

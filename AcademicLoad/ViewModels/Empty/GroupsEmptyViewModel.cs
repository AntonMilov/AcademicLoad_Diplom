using AcademicLoadModule.Controllers.Interfaces;
using Prism.Commands;
using Prism.Mvvm;

namespace AcademicLoadModule.ViewModels.Empty
{
    public class GroupsEmptyViewModel : BindableBase
    {
        private readonly IGroupController groupController;

        /// <summary>
        /// ctor.
        /// </summary>
        public GroupsEmptyViewModel(IGroupController groupController)
        {
            this.groupController = groupController;
            AddGroupCommand = new DelegateCommand(AddGroup);
        }

        /// <summary>
        /// Команда для добавления учебной группы.
        /// </summary>
        public DelegateCommand AddGroupCommand { get; private set; }

        private void AddGroup()
        {
            groupController.AddGroup();
        }
    }
}

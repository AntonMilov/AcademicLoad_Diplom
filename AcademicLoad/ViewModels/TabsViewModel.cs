using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using AcademicLoadModule.Controllers.Interfaces;

namespace AcademicLoadModule.ViewModels
{
    public class TabsViewModel : BindableBase
    {

        public TabsViewModel(IGroupController groupController, ITeacherController teacherController)
        {
            groupController.CheckGroupsCount();
            teacherController.CheckTeacherCount();
        }
    }
}

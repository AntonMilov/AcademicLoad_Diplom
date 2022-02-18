﻿using AcademicLoadModule.Controllers.Interfaces;
using AcademicLoadModule.Views;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AcademicLoadModule.ViewModels
{
    /// <summary>
    /// 
    /// </summary>
    public class TeachersEmptyViewModel : BindableBase
    {
        private readonly ITeacherController teacherController;

        /// <summary>
        /// .ctor
        /// </summary>
        public TeachersEmptyViewModel(ITeacherController teacherController)
        {
            this.teacherController = teacherController;
            AddTeacherComamnd = new DelegateCommand(addTeacher);
        }

        /// <summary>
        /// Команда для добавения преподавателя.
        /// </summary>
        public DelegateCommand AddTeacherComamnd { get; private set; }

        private void addTeacher()
        {
            teacherController.AddTeacher();
        }
    }
}

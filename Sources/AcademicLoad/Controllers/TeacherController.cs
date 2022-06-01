using System.Collections.ObjectModel;
using AcademicLoadModule.Controllers.Interfaces;
using AcademicLoadModule.Events;
using AcademicLoadModule.ViewModels.Add;
using AcademicLoadModule.ViewModels.Edit;
using AcademicLoadModule.Views.Add;
using AcademicLoadModule.Views.Edit;
using Core.Photo;
using Core.Services.Interfaces;
using Data.Models;
using Infrastructure.AddDialog;
using Infrastructure.ConfirmDialog;
using Infrastructure.DialogControllers.Interfaces;
using Microsoft.Win32;
using Prism.Events;
using Prism.Services.Dialogs;

namespace AcademicLoadModule.Controllers
{
    /// <summary>
    /// <inheritdoc cref="ITeacherController"/>
    /// </summary>
    public class TeacherController : ITeacherController
    {
        private readonly IDialogController dialogController;
        private readonly IEventAggregator eventAggregator;
        private readonly ITeacherService teacherService;
        private readonly OpenFileDialog openFileDialog;
        private readonly IPhotoService photoService;
        private ObservableCollection<Teacher> items;
      

        /// <summary>
        /// .ctor
        /// </summary>
        /// <param name="dialogService">.</param>
        /// <param name="eventAggregator">.</param>
        /// <param name="teacherService">.</param>
        /// <param name="notificationDialogController">.</param>
        public TeacherController(IEventAggregator eventAggregator,
            ITeacherService teacherService,
            IDialogController dialogController,
            IPhotoService photoService,
            OpenFileDialog openFileDialog)
        {
            this.dialogController = dialogController;
            this.eventAggregator = eventAggregator;
            this.teacherService = teacherService;
            this.photoService = photoService;
            this.openFileDialog = openFileDialog;

            items = new ObservableCollection<Teacher>(teacherService.Teachers);
        }

        /// <inheritdoc/>
        public ObservableCollection<Teacher> Items
        {
            get => items;
            set => items = value;
        }

        /// <inheritdoc/>
        public void AddTeacher()
        {
            AddTeacherViewModel model = new AddTeacherViewModel(photoService, openFileDialog);
            AddTeacherView view = new AddTeacherView() { DataContext = model };

            var addDialogParameters = new AddDialogParameters();
            addDialogParameters.CloseButtonText = Properties.Resources.Cancel;
            addDialogParameters.ConfirmButtonText = Properties.Resources.Add;
            addDialogParameters.Header = Properties.Resources.AddingTeacher;
            addDialogParameters.Title = Properties.Resources.AddingTeacher;
            addDialogParameters.Content = view;
            addDialogParameters.CanCloseWindow = model.CanAddTeacher;

            dialogController.OpenAddDialog(addDialogParameters, r =>
             {
                 if (r.Result == ButtonResult.OK)
                 {


                     items.Add(model.CreateTeacher());
                     teacherService.AddTeacher(model.CreateTeacher());

                     eventAggregator.GetEvent<TeachersCountChangeEvent>().Publish(teacherService.Teachers.Count);

                     dialogController.OpenNotificationDialog(Properties.Resources.Notification, Properties.Resources.SuccessAddTeacher);
                 }
             });
        }

        /// <inheritdoc/>
        public void DeleteTeacher(Teacher teacher)
        {
            var confirmDialogParameters = new ConfirmDialogParameters();
            confirmDialogParameters.Message = Properties.Resources.MessageDeleteTeacher;

            dialogController.OpenConfirmDialog(confirmDialogParameters, r =>
             {
                 if (r.Result == ButtonResult.OK)
                 {
                     items.Remove(teacher);
                     teacherService.DeleteTeacher(teacher);

                     eventAggregator.GetEvent<TeachersCountChangeEvent>().Publish(Items.Count);

                     dialogController.OpenNotificationDialog(Properties.Resources.Notification, Properties.Resources.SuccessDeleteTeacher);
                 }
             });
        }

        /// <inheritdoc/>
        public void CheckTeacherCount()
        {
            eventAggregator.GetEvent<TeachersCountChangeEvent>().Publish(teacherService.Teachers.Count);
        }

        public void EditTeacher(Teacher teacher)
        {
            EditTeacherViewModel model = new EditTeacherViewModel(teacher, photoService, openFileDialog);
            EditTeacherView view = new EditTeacherView() { DataContext = model };

            teacher.PhotoPath = null;

            var addDialogParameters = new AddDialogParameters();
            addDialogParameters.CloseButtonText = Properties.Resources.Cancel;
            addDialogParameters.ConfirmButtonText = "Сохранить";
            addDialogParameters.Header = "Редактирование преподавателя";
            addDialogParameters.Title = "Редактирование преподавателя";
            addDialogParameters.Content = view;
            addDialogParameters.CanCloseWindow = model.CanAddTeacher;

            dialogController.OpenAddDialog(addDialogParameters, r =>
            {
                if (r.Result == ButtonResult.OK)
                {
                    Teacher editTeacher = model.CreateTeacher();
                    teacher.FirstName = editTeacher.FirstName;
                    teacher.LastName = editTeacher.LastName;
                    teacher.MiddleName = editTeacher.MiddleName;
                    teacher.Rate = editTeacher.Rate;
                    teacher.AcademicTitle= editTeacher.AcademicTitle;
                    teacher.Birthday = editTeacher.Birthday;
                    teacher.PhotoPath = editTeacher.PhotoPath;

                    teacherService.SaveEditTeacher();

                    dialogController.OpenNotificationDialog(Properties.Resources.Notification, "Преподаватель успешно отредактирован");
                }

                if (r.Result == ButtonResult.Cancel)
                {
                }
            });
        }
    }
}

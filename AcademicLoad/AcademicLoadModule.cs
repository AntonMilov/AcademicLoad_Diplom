﻿using AcademicLoadModule.Controllers;
using AcademicLoadModule.Controllers.Interfaces;
using AcademicLoadModule.Views;
using Core.Services;
using Core.Services.Interfaces;
using Infrastructure.NotificationDialog.Controller;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

namespace AcademicLoadModule
{
    /// <inheritdoc/>
    public class AcademicLoadModule : IModule
    {
        /// <inheritdoc/>
        public void OnInitialized(IContainerProvider containerProvider)
        {
            var regionManager = containerProvider.Resolve<IRegionManager>();
            regionManager.RegisterViewWithRegion("MainRegion", typeof(TabsView));

            regionManager.RegisterViewWithRegion("TeachersRegion", typeof(TeachersEmptyView));
            regionManager.RegisterViewWithRegion("TeachersRegion", typeof(TeachersView));

            regionManager.RegisterViewWithRegion("GroupsRegion", typeof(GroupsEmptyView));
            regionManager.RegisterViewWithRegion("GroupsRegion", typeof(GroupsView));
        }

        /// <inheritdoc/>
        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.Register<INotificationDialogController, NotificationDialogController>();

            containerRegistry.RegisterSingleton<ITeacherController, TeacherController>();
            containerRegistry.RegisterSingleton<ITeacherService, TeacherService>();

            containerRegistry.RegisterSingleton<IGroupController, GroupController>();
        }
    }
}
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AcademicLoadModule.Events;
using Prism.Events;

using Prism.Regions;

namespace NavigationModule
{
    /// <summary>
    /// Класс навигации.
    /// </summary>
    public class Navigator
    {
        private readonly IRegionManager regionManager;

        /// <summary>
        /// .ctor
        /// </summary>
        /// <param name="eventAggregator"></param>
        /// <param name="regionManager"></param>
        public Navigator(IEventAggregator eventAggregator, IRegionManager regionManager)
        {
            this.regionManager = regionManager;

            eventAggregator.GetEvent<TeachersCountChangeEvent>().Subscribe(TeachersCountChangeHandler);
            eventAggregator.GetEvent<GroupsCountChangeEvent>().Subscribe(GroupsCountChangeHandler);
        }

        private void TeachersCountChangeHandler(int countTeachers)
        {
          if (countTeachers>0)
            regionManager.RequestNavigate("TeachersRegion","TeachersView");
        }

        private void GroupsCountChangeHandler(int countTeachers)
        {
            if (countTeachers > 0)
                regionManager.RequestNavigate("GroupsRegion", "GroupsView");
        }
    }
}

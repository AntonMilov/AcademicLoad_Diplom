using System;
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
            eventAggregator.GetEvent<CalculationSheetAddedEvent>().Subscribe(CalculationSheetAddedHandler);
            eventAggregator.GetEvent<CalculationSheetDeletedEvent>().Subscribe(CalculationSheetDeletedHandler);
        }

        private void TeachersCountChangeHandler(int countTeachers)
        {
            if (countTeachers > 0)
                regionManager.RequestNavigate("TeachersRegion", "TeachersView");

            if (countTeachers < 1)
                regionManager.RequestNavigate("TeachersRegion", "TeachersEmptyView");
        }

        private void GroupsCountChangeHandler(int countGroups)
        {
            if (countGroups > 0)
                regionManager.RequestNavigate("GroupsRegion", "GroupsView");

            if (countGroups < 1)
                regionManager.RequestNavigate("GroupsRegion", "GroupsEmptyView");

        }

        private void CalculationSheetAddedHandler()
        {
            regionManager.RequestNavigate("CalculationSheetsRegion", "CalculationSheetView");
        }

        private void CalculationSheetDeletedHandler()
        {
            regionManager.RequestNavigate("CalculationSheetsRegion", "CalculationSheetsEmptyView");
        }
    }
}

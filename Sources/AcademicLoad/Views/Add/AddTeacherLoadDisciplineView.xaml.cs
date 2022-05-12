using System.Diagnostics;
using System.Windows.Controls;
using System.Windows.Input;

namespace AcademicLoadModule.Views.Add
{
    /// <summary>
    /// Interaction logic for AddTeacherLoadDisciplineView
    /// </summary>
    public partial class AddTeacherLoadDisciplineView : UserControl
    {
        public AddTeacherLoadDisciplineView()
        {
            InitializeComponent();
        }

        private void UIElement_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            ContextMenu.PlacementTarget = TextBlockTeacher;
            ContextMenu.VerticalOffset = 10;
            ContextMenu.IsOpen = true;
        }

        private void UIElement_OnMouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            e.Handled = true;
        }

        private void Selector_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ContextMenu.IsOpen = false;
        }

        private void OnSelectionChangedComboBoxGroups(object sender, SelectionChangedEventArgs e)
        {
            ContextMenuGroups.IsOpen = false;
        }

        private void Group_OnPreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            ContextMenuGroups.PlacementTarget = TextBlockGroup;
            ContextMenuGroups.VerticalOffset = 10;
            ContextMenuGroups.IsOpen = true;
        }
    }
}

using System.Diagnostics;
using System.Windows.Controls;
using System.Windows.Input;

namespace AcademicLoadModule.Views
{
    /// <summary>
    /// Interaction logic for CalculationSheetView
    /// </summary>
    public partial class CalculationSheetView : UserControl
    {
        public CalculationSheetView()
        {
            InitializeComponent();
        }


        void MainDataGrid_PreparingCellForEdit(object sender, DataGridPreparingCellForEditEventArgs e)
        {
            TextBox tb = e.Column.GetCellContent(e.Row) as TextBox;
            tb.PreviewTextInput += new TextCompositionEventHandler(textBox1_PreviewTextInput);
        }

        private void textBox1_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Debug.WriteLine("azaza");
            e.Handled = "0123456789 ,".IndexOf(e.Text) < 0;
        }


        private void DataGridTextColumn_TextChanged(object sender, TextChangedEventArgs e)
        {
            int a = 0;
        }

        private void DataGrid_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            int a = 8;
        }
    }
}

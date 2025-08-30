using System.Windows.Controls;

namespace SynthesisSequenceGenerator
{
    /// <summary>
    /// Логика взаимодействия для TableCardUC.xaml
    /// </summary>
    public partial class TableCardUC : UserControl
    {
        private readonly ModelTableCard model;

        public TableCardUC()
        {
            InitializeComponent();
            model = (ModelTableCard)DataContext;
        }

        private void UserControl_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            var vals = Uid.ToCharArray();
            if (vals.Length == 2)
            {
                model.Key = vals[0].ToString();
                if (int.TryParse(vals[1].ToString(), out int index))
                    model.Index = index;
            }
        }
    }
}

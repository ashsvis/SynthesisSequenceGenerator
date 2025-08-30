using System.Windows;

namespace SynthesisSequenceGenerator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly ModelGenerator model;
        public MainWindow()
        {
            InitializeComponent();
            model = (ModelGenerator)DataContext;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            SourceSequencesBox.Text = Properties.Settings.Default.SourceSequenses;
        }

        private void SourceSequencesButton_Click(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default.SourceSequenses = SourceSequencesBox.Text;
            Properties.Settings.Default.Save();
            Calculate();
        }

        private void Calculate()
        {
            model.GenerateSequences(ModelGenerator.GenerateSourceArray(SourceSequencesBox.Text));
            ((ModelTableCard)J1.DataContext).UseSequenses(model.Sequenses);
            ((ModelTableCard)K1.DataContext).UseSequenses(model.Sequenses);
            ((ModelTableCard)J2.DataContext).UseSequenses(model.Sequenses);
            ((ModelTableCard)K2.DataContext).UseSequenses(model.Sequenses);
            ((ModelTableCard)J3.DataContext).UseSequenses(model.Sequenses);
            ((ModelTableCard)K3.DataContext).UseSequenses(model.Sequenses);
            ((ModelTableCard)J4.DataContext).UseSequenses(model.Sequenses);
            ((ModelTableCard)K4.DataContext).UseSequenses(model.Sequenses);
        }
    }
}
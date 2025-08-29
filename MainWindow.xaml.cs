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
            model.GenerateSequences(ModelGenerator.GenerateSourceArray(SourceSequencesBox.Text));
        }

        private void SourceSequencesButton_Click(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default.SourceSequenses = SourceSequencesBox.Text;
            Properties.Settings.Default.Save();
            model.GenerateSequences(ModelGenerator.GenerateSourceArray(SourceSequencesBox.Text));
        }
    }
}
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

        private void SourceSequencesButton_Click(object sender, RoutedEventArgs e)
        {
            model.GenerateSequences(ModelGenerator.GenerateSourceArray(SourceSequencesBox.Text));
        }
    }
}
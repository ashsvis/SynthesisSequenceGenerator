namespace SynthesisSequenceGenerator
{
    public class ModelTableCard : ObservableObject
    {
        private string key = string.Empty;
        private int index;

        public double ColumnWidth { get; set; } = 25;
        public string Key 
        { 
            get => key;
            set
            {
                key = value;
                NotifyPropertyChanged(nameof(Key));
            }
        }
        
        public int Index 
        { 
            get => index;
            set
            {
                index = value;
                NotifyPropertyChanged(nameof(Index));
            }
        }
    }

}

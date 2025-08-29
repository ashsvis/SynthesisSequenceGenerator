using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Windows.Data;

namespace SynthesisSequenceGenerator
{
    public class ModelGenerator : ObservableObject
    {
        private string sourceSequenses = string.Empty;

        public double ColumnWidth { get; set; } = 30.5;
        public ModelGenerator()
        {
            var array = Enumerable.Range(0, 16).ToArray();
            //int[] array = [1, 2, 2, 1, 2, 3];
            sourceSequenses = string.Join(" ", array.Select(x => x.ToString()));
            GenerateSequences(array);
        }

        public void GenerateSequences(params int[] enabledStates)
        {
            int i = 0;
            Sequenses.Clear();
            while (i < enabledStates.Length)
            {
                var state = enabledStates[i];
                var item = new Sequense()
                {
                    State = state,
                    Q4 = (state & 0x01) > 0 ? 1 : 0,
                    Q3 = (state & 0x02) > 0 ? 1 : 0,
                    Q2 = (state & 0x04) > 0 ? 1 : 0,
                    Q1 = (state & 0x08) > 0 ? 1 : 0,
                };
                var nextState = i < enabledStates.Length - 1 ? enabledStates[i + 1] : enabledStates[0];
                item.Qn4 = (nextState & 0x01) > 0 ? 1 : 0;
                item.Qn3 = (nextState & 0x02) > 0 ? 1 : 0;
                item.Qn2 = (nextState & 0x04) > 0 ? 1 : 0;
                item.Qn1 = (nextState & 0x08) > 0 ? 1 : 0;
                //------------------
                item.J4 = item.Q4 == 0 && item.Qn4 == 0 ? 0 : item.Q4 == 0 && item.Qn4 == 1 ? 1 : -1;
                item.K4 = item.Q4 == 1 && item.Qn4 == 0 ? 1 : item.Q4 == 1 && item.Qn4 == 1 ? 0 : -1;
                item.J3 = item.Q3 == 0 && item.Qn3 == 0 ? 0 : item.Q3 == 0 && item.Qn3 == 1 ? 1 : -1;
                item.K3 = item.Q3 == 1 && item.Qn3 == 0 ? 1 : item.Q3 == 1 && item.Qn3 == 1 ? 0 : -1;
                item.J2 = item.Q2 == 0 && item.Qn2 == 0 ? 0 : item.Q2 == 0 && item.Qn2 == 1 ? 1 : -1;
                item.K2 = item.Q2 == 1 && item.Qn2 == 0 ? 1 : item.Q2 == 1 && item.Qn2 == 1 ? 0 : -1;
                item.J1 = item.Q1 == 0 && item.Qn1 == 0 ? 0 : item.Q1 == 0 && item.Qn1 == 1 ? 1 : -1;
                item.K1 = item.Q1 == 1 && item.Qn1 == 0 ? 1 : item.Q1 == 1 && item.Qn1 == 1 ? 0 : -1;
                Sequenses.Add(item);
                i++;
            }
        }

        public static int[] GenerateSourceArray(string text)
        {
            List<int> sequences = [];
            text.Split(' ', StringSplitOptions.RemoveEmptyEntries).ToList()
                .ForEach(x =>
                {
                    if (int.TryParse(x, out int result) && result >= 0 && result < 16)
                        sequences.Add(result);
                });
            return [.. sequences];
        }

        public string SourceSequenses 
        { 
            get => sourceSequenses;
            set
            {
                if (sourceSequenses == value) return;
                sourceSequenses = value;
                NotifyPropertyChanged(nameof(SourceSequenses));
            }
        }

        public ObservableCollection<Sequense> Sequenses { get; set; } = [];
    }

    /// <summary>
    /// Класс поддержки привязки данных
    /// </summary>
    public class ObservableObject : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        protected void NotifyPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            var handler = PropertyChanged;
            handler?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class Sequense 
    { 
        public Sequense() { }
        public int State { get; set; }
        public int Q1 { get; set; }
        public int Q2 { get; set; }
        public int Q3 { get; set; }
        public int Q4 { get; set; }
        public int Qn1 { get; set; }
        public int Qn2 { get; set; }
        public int Qn3 { get; set; }
        public int Qn4 { get; set; }
        public int J1 { get; set; }
        public int K1 { get; set; }
        public int J2 { get; set; }
        public int K2 { get; set; }
        public int J3 { get; set; }
        public int K3 { get; set; }
        public int J4 { get; set; }
        public int K4 { get; set; }
    }

    [ValueConversion(typeof(object), typeof(string))]
    public class StateToHexConverter : IValueConverter
    {
        public object? Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return $"{value}";
        }

        public object? ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }

}

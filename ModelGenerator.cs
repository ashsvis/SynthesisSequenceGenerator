using System.Collections.ObjectModel;
using System.Globalization;
using System.Windows.Data;

namespace SynthesisSequenceGenerator
{
    public class ModelGenerator
    {
        public double ColumnWidth { get; set; } = 30.0;
        public ModelGenerator()
        {
            for (var i = 0; i < 16; i++) 
            {
                var item = new Sequense() 
                { 
                    Index = i,
                    Q4 = (i & 0x01) > 0 ? 1 : 0,
                    Q3 = (i & 0x02) > 0 ? 1 : 0,
                    Q2 = (i & 0x04) > 0 ? 1 : 0,
                    Q1 = (i & 0x08) > 0 ? 1 : 0,
                };
                Sequenses.Add(item);
            }
        }

        public ObservableCollection<Sequense> Sequenses { get; set; } = [];
    }

    public class Sequense 
    { 
        public Sequense() { }
        public bool Enabled { get; set; } = true;
        public int Index { get; set; }
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

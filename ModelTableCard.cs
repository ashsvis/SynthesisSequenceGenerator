using System.Collections.ObjectModel;

namespace SynthesisSequenceGenerator
{
    public class ModelTableCard : ObservableObject
    {
        private string key = string.Empty;
        private int index;
        private int r00_00;
        private int r00_01;
        private int r00_11;
        private int r00_10;
        private int r01_00;
        private int r01_01;
        private int r01_11;
        private int r01_10;
        private int r11_00;
        private int r11_01;
        private int r11_11;
        private int r11_10;
        private int r10_00;
        private int r10_01;
        private int r10_11;
        private int r10_10;
        private string function = "?";

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

        public void UseSequenses(ObservableCollection<Sequense> sequenses)
        {
            R00_00 = -1;
            R00_01 = -1;
            R00_11 = -1;
            R00_10 = -1;
            R01_00 = -1;
            R01_01 = -1;
            R01_11 = -1;
            R01_10 = -1;
            R11_00 = -1;
            R11_01 = -1;
            R11_11 = -1;
            R11_10 = -1;
            R10_00 = -1;
            R10_01 = -1;
            R10_11 = -1;
            R10_10 = -1;
            foreach (var sq in sequenses)
            {
                var value = -1;
                switch (key)
                {
                    case "J":
                        switch (index)
                        {
                            case 1:
                                value = sq.J1;
                                break;
                            case 2:
                                value = sq.J2;
                                break;
                            case 3:
                                value = sq.J3;
                                break;
                            case 4:
                                value = sq.J4;
                                break;
                        }
                        break;
                    case "K":
                        switch (index)
                        {
                            case 1:
                                value = sq.K1;
                                break;
                            case 2:
                                value = sq.K2;
                                break;
                            case 3:
                                value = sq.K3;
                                break;
                            case 4:
                                value = sq.K4;
                                break;
                        }
                        break;
                }

                var Q1Q2 = $"{sq.Q1}{sq.Q2}";
                var Q3Q4 = $"{sq.Q3}{sq.Q4}";
                switch (Q1Q2) 
                {
                    case "00":
                        switch (Q3Q4)
                        {
                            case "00":
                                R00_00 = value;
                                break;
                            case "01":
                                R00_01 = value;
                                break;
                            case "11":
                                R00_11 = value;
                                break;
                            case "10":
                                R00_10 = value;
                                break;
                        }
                        break;
                    case "01":
                        switch (Q3Q4)
                        {
                            case "00":
                                R01_00 = value;
                                break;
                            case "01":
                                R01_01 = value;
                                break;
                            case "11":
                                R01_11 = value;
                                break;
                            case "10":
                                R01_10 = value;
                                break;
                        }
                        break;
                    case "11":
                        switch (Q3Q4)
                        {
                            case "00":
                                R11_00 = value;
                                break;
                            case "01":
                                R11_01 = value;
                                break;
                            case "11":
                                R11_11 = value;
                                break;
                            case "10":
                                R11_10 = value;
                                break;
                        }
                        break;
                    case "10":
                        switch (Q3Q4)
                        {
                            case "00":
                                R10_00 = value;
                                break;
                            case "01":
                                R10_01 = value;
                                break;
                            case "11":
                                R10_11 = value;
                                break;
                            case "10":
                                R10_10 = value;
                                break;
                        }
                        break;
                }
            }
        }

        public int R00_00 { get => r00_00; set { r00_00 = value; NotifyPropertyChanged(); } }
        public int R00_01 { get => r00_01; set { r00_01 = value; NotifyPropertyChanged(); } }
        public int R00_11 { get => r00_11; set { r00_11 = value; NotifyPropertyChanged(); } }
        public int R00_10 { get => r00_10; set { r00_10 = value; NotifyPropertyChanged(); } }
        public int R01_00 { get => r01_00; set { r01_00 = value; NotifyPropertyChanged(); } }
        public int R01_01 { get => r01_01; set { r01_01 = value; NotifyPropertyChanged(); } }
        public int R01_11 { get => r01_11; set { r01_11 = value; NotifyPropertyChanged(); } }
        public int R01_10 { get => r01_10; set { r01_10 = value; NotifyPropertyChanged(); } }
        public int R11_00 { get => r11_00; set { r11_00 = value; NotifyPropertyChanged(); } }
        public int R11_01 { get => r11_01; set { r11_01 = value; NotifyPropertyChanged(); } }
        public int R11_11 { get => r11_11; set { r11_11 = value; NotifyPropertyChanged(); } }
        public int R11_10 { get => r11_10; set { r11_10 = value; NotifyPropertyChanged(); } }
        public int R10_00 { get => r10_00; set { r10_00 = value; NotifyPropertyChanged(); } }
        public int R10_01 { get => r10_01; set { r10_01 = value; NotifyPropertyChanged(); } }
        public int R10_11 { get => r10_11; set { r10_11 = value; NotifyPropertyChanged(); } }
        public int R10_10 { get => r10_10; set { r10_10 = value; NotifyPropertyChanged(); } }

        public string Function { get => function; set { function = value; NotifyPropertyChanged(); } }
    }

}

using System;
using System.ComponentModel;

namespace DevExpress.Maui.Demo.Stocks {

    public class SymbolViewModel : INotifyPropertyChanged {
        double closePrice;
        double change;
        double changePercent;
        DateTime date;
        public string Ticker { get; set; }
        public string CompanyName { get; set; }
        public double ClosePrice {
            get => closePrice;
            set {
                closePrice = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ClosePrice)));
            }
        }
        public double Change {
            get => change;
            set {
                change = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Change)));
            }
        }
        public double ChangePercent {
            get => changePercent;
            set {
                changePercent = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ChangePercent)));
            }
        }
        public DateTime Date {
            get => date;
            set {
                date = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Date)));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
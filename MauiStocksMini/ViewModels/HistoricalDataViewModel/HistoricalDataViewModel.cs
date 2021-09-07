using Microsoft.Maui.Controls;
using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;

namespace DevExpress.Maui.Demo.Stocks {
    public class HistoricalDataViewModel : INotifyPropertyChanged {
        public event PropertyChangedEventHandler PropertyChanged;


        public SymbolViewModel SymbolViewModel { get; set; }

        public IList<StockPrice> StockPrices { get; set;}

        DateTime rangeStart;
        public DateTime RangeStart { get; set; }
        public DateTime RangeEnd { get; set; }

        public HistoricalDataViewModel(SymbolViewModel symbolViewModel) {
            SymbolViewModel = symbolViewModel;
            Symbol symbol = Data.Symbols.Where(s => s.ticker == this.SymbolViewModel.Ticker).First();
            RangeStart = symbol.data.First().date;
            RangeEnd = RangeStart.AddDays(-60);
            StockPrices = new List<StockPrice>();
            foreach(HistoricalData data in symbol.data) {
                StockPrice price = new StockPrice();
                price.Date = data.date;
                price.Open = data.open;
                price.Close = data.close;
                price.High = data.high;
                price.Low = data.low;
                price.Volume = data.volume;
                StockPrices.Add(price);
            }
        }

    }
}

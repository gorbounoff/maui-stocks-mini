using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevExpress.Maui.Demo.Stocks {
    public class Symbol {
        public string ticker;
        public string name;
        public IList<HistoricalData> data;
    }
    public class HistoricalData {
        public DateTime date;
        public double open;
        public double close;
        public double high;
        public double low;
        public double volume;
    }
}
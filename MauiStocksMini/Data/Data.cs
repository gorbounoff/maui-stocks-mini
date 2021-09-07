using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DevExpress.Maui.Demo.Stocks {
    public static class Data {
        static readonly string folderName = "Historical_Data";
        static IList<Symbol> symbols;
        public static IList<Symbol> Symbols {
            get {
                if (symbols == null) {
                    symbols = new List<Symbol>();
                    IEnumerable<string> resources = Assembly.GetExecutingAssembly().GetManifestResourceNames().Where<string>(s => s.Contains(folderName));
                    foreach (string resource in resources) {
                        using (var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(resource))
                        using (var reader = new StreamReader(stream, Encoding.UTF8)) {
                            var json = reader.ReadToEnd();
                            var symbol = Newtonsoft.Json.JsonConvert.DeserializeObject<Symbol>(json);
                            symbols.Add(symbol);
                        }
                    }
                }
                var test = symbols;
                return symbols;
            }
        }
    }
}
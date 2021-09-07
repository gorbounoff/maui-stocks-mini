using System.Collections.Generic;

namespace DevExpress.Maui.Demo.Stocks
{
    public class SymbolListViewModel
    {
        public IList<SymbolViewModel> SymbolViewModels { get; set; }

        public bool IsLoadingSymbols { get; set; }

        public SymbolListViewModel()
        {
            LoadSymbols();
        }

        private void LoadSymbols()
        {
            IsLoadingSymbols = true;
            SymbolViewModels = new List<SymbolViewModel>();
            foreach (Symbol symbol in Data.Symbols)
            {
                var symbolViewModel = new SymbolViewModel();
                symbolViewModel.Ticker = symbol.ticker;
                symbolViewModel.CompanyName = symbol.name;
                symbolViewModel.Change = symbol.data[0].close - symbol.data[1].close;
                symbolViewModel.ChangePercent = symbol.data[0].close / symbol.data[1].close - 1;
                symbolViewModel.Date = symbol.data[0].date;
                symbolViewModel.ClosePrice = symbol.data[0].close;
                SymbolViewModels.Add(symbolViewModel);
            }
            IsLoadingSymbols = true;
        }
    }
}
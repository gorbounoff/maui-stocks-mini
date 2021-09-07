using Microsoft.Maui.Controls;

namespace DevExpress.Maui.Demo.Stocks {
    public partial class SymbolListPage: ContentPage {
        public SymbolListPage() {
            InitializeComponent();
        }

        private async void DXCollectionView_Tap(object sender, DevExpress.Maui.CollectionView.CollectionViewGestureEventArgs e)
        {
            var symbolViewModel = (SymbolViewModel)e.Item;
            var historicalDataViewModel = new HistoricalDataViewModel(symbolViewModel);
            var navigationPage = (NavigationPage)Application.Current.MainPage;
            await navigationPage.PushAsync(new HistoricalDataPage(historicalDataViewModel), false);
            navigationPage.Title = symbolViewModel.Ticker;
        }
    }
}
using _4C.Model;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using System.Windows.Documents;

namespace _4C.View
{
    public partial class DetailsWindow : Window
    {
        public ObservableCollection<Market> Markets { get; set; }
        public ObservableCollection<History> Histories { get; set; }

        public DetailsWindow(Asset asset)
        {
            InitializeComponent();
            Markets = new ObservableCollection<Market>();
            Histories = new ObservableCollection<History>();
            GeneratePropertiesUI(asset);
            InitializeMarketsByCurrencyAsync(asset).ConfigureAwait(false);
            InitializeHistoryOfCurrencyAsync(asset).ConfigureAwait(false);
            DataContext = this;
        }
        private void GeneratePropertiesUI(Asset asset)
        {
            if (asset == null) return;

            var type = asset.GetType();
            var properties = type.GetProperties();

            foreach (var prop in properties)
            {
                var propertyName = prop.Name;
                var propertyValue = prop.GetValue(asset, null)?.ToString() ?? "null";

                var textBlock = new TextBlock
                {
                    Text = $"{propertyName}: {propertyValue}",
                    Margin = new Thickness(5)
                };
                textBlock.Style = (Style)Application.Current.FindResource("tbDetails");

                PropertiesPanel.Children.Add(textBlock);
            }
        }

        public async Task InitializeMarketsByCurrencyAsync(Asset asset)
        {
            try
            {
                var loadedMarkets = await DataFromApi.GetMarketsByCurrency(asset.Id);
                foreach (var market in loadedMarkets)
                {
                    Markets.Add(market);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Помилка при завантаженні даних: {ex.Message}");
            }
        }

        public async Task InitializeHistoryOfCurrencyAsync(Asset asset)
        {
            try
            {
                var loadedHistories = await DataFromApi.GetHistoryOfCurrency(asset.Id);
                foreach (var history in loadedHistories)
                {
                    Histories.Add(history);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Помилка при завантаженні даних: {ex.Message}");
            }
        }

        private void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            if (sender is Hyperlink hyperlink)
            {
                if (hyperlink.DataContext is Market market)
                {
                    var url = $"http://www.{market.ExchangeId}.com";

                    try
                    {
                        System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(url) { UseShellExecute = true });
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Не вдалося відкрити посилання: {ex.Message}", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }

            e.Handled = true;
        }
    }
}

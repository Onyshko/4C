using _4C.Model;
using _4C.MVVM.ViewModel;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Navigation;

namespace _4C.MVVM.View
{
    public partial class DetailsWindow : Window
    {
        public DetailsWindow(Asset asset)
        {
            InitializeComponent();

            var viewModel = new DetailsWindowViewModel(asset);
            GeneratePropertiesUI(asset);
            DataContext = viewModel;
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

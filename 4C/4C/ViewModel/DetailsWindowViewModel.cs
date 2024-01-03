using _4C.Model;
using LiveCharts.Defaults;
using LiveCharts.Wpf;
using LiveCharts;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Navigation;
using System.Windows;
using _4C.MVVM;

namespace _4C.ViewModel
{
    class DetailsWindowViewModel : ViewModelBase
    {
        public ObservableCollection<Market> Markets { get; set; }
        public ObservableCollection<History> Histories { get; set; }
        private SeriesCollection _seriesCollection;
        public SeriesCollection SeriesCollection
        {
            get => _seriesCollection;
            set
            {
                _seriesCollection = value;
                OnPropertyChanged();
            }
        }
        private AxesCollection _xAxis;
        public AxesCollection XAxis
        {
            get => _xAxis;
            set
            {
                _xAxis = value;
                OnPropertyChanged();
            }
        }
        private AxesCollection _yAxis;
        public AxesCollection YAxis
        {
            get => _yAxis;
            set
            {
                _yAxis = value;
                OnPropertyChanged();
            }
        }

        public DetailsWindowViewModel(Asset asset)
        {
            Markets = new ObservableCollection<Market>();
            Histories = new ObservableCollection<History>();
            SeriesCollection = new SeriesCollection();
            XAxis = new AxesCollection();

            InitializeMarketsByCurrencyAsync(asset).ConfigureAwait(false);
            InitializeHistoryOfCurrencyAsync(asset).ConfigureAwait(false);
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
                PreparePointsForChart();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Помилка при завантаженні даних: {ex.Message}");
            }
        }

        private void PreparePointsForChart()
        {
            SeriesCollection = new SeriesCollection
            {
                new LineSeries
                {
                    Values = new ChartValues<ObservablePoint>(
                        Histories.Select(h => new ObservablePoint(
                            h.Time.ToOADate(),
                            Convert.ToDouble(h.PriceUsd))))
                }
            };

            XAxis = new AxesCollection
            {
                new Axis
                {
                    LabelFormatter = value => DateTime.FromOADate(value).ToString("dd.MM.yyyy")
                }
            };

            YAxis = new AxesCollection
            {
                new Axis
                {
                    Title = "Price USD"
                }
            };
        }
    }
}

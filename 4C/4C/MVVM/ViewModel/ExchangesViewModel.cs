using _4C.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace _4C.MVVM.ViewModel
{
    class ExchangesViewModel : ViewModelBase
    {
        public ObservableCollection<Asset> Assets { get; set; }

        private Asset selectedAsset_1;
        public Asset SelectedAsset_1
        {
            get { return selectedAsset_1; }
            set
            {
                selectedAsset_1 = value;
                OnPropertyChanged();
            }
        }

        private Asset selectedAsset_2;
        public Asset SelectedAsset_2
        {
            get { return selectedAsset_2; }
            set
            {
                selectedAsset_2 = value;
                OnPropertyChanged();
            }
        }

        private double exchangeFor_1;
        public double ExchangeFor_1
        {
            get { return exchangeFor_1; }
            set
            {
                exchangeFor_1 = value;
                OnPropertyChanged();
            }
        }

        private double exchangeFor_2;
        public double ExchangeFor_2
        {
            get { return exchangeFor_2; }
            set
            {
                exchangeFor_2 = value;
                OnPropertyChanged();
            }
        }

        public ICommand CountingExchanges { get; private set; }


        public ExchangesViewModel()
        {
            Assets = new ObservableCollection<Asset>();
            InitializeAsync();
            CountingExchanges = new RelayCommand(param => ExecuteCountingExchanges());
        }

        public async Task InitializeAsync()
        {
            try
            {
                var loadedAssets = await DataFromApi.GetTopListCurrencies();
                var sortedAssets = new ObservableCollection<Asset>(loadedAssets.OrderBy(i => i.Rank));
                for (int i = 0; i < sortedAssets.Count; i++)
                {
                    Assets.Add(sortedAssets[i]);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Помилка при завантаженні даних: {ex.Message}");
            }
        }

        public void ExecuteCountingExchanges()
        {
            ExchangeFor_1 = (double)selectedAsset_1.PriceUsd / (double)selectedAsset_2.PriceUsd;
            ExchangeFor_2 = (double)selectedAsset_2.PriceUsd / (double)selectedAsset_1.PriceUsd;
        }
    }
}

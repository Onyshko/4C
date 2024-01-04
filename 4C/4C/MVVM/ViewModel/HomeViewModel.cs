using _4C.Model;
using _4C.MVVM.View;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace _4C.MVVM.ViewModel
{
    class HomeViewModel : ViewModelBase
    {
        public ObservableCollection<Asset> Assets { get; set; }

        private Asset selectedAsset;
        public Asset SelectedAsset
        {
            get { return selectedAsset; }
            set
            {
                selectedAsset = value;
                OnPropertyChanged();
                OpenDetailsWindow(selectedAsset);
            }
        }

        private string _text;

        public string Text
        {
            get { return _text; }
            set
            {
                _text = value;
                OnPropertyChanged(nameof(Text));
            }
        }

        public HomeViewModel(string searchText)
        {
            Assets = new ObservableCollection<Asset>();
            InitializeAsync(searchText);
        }

        public async Task InitializeAsync(string searchText)
        {
            try
            {
                var loadedAssets = await DataFromApi.GetTopListCurrencies();
                var sortedAssets = new ObservableCollection<Asset>(loadedAssets.OrderBy(i => i.Rank));
                for (int i = 0; i < sortedAssets.Count; i++)
                {
                    if (searchText == null)
                        Assets.Add(sortedAssets[i]);
                    else if (sortedAssets[i].Name.Contains(searchText) || sortedAssets[i].Id.Contains(searchText))
                        Assets.Add(sortedAssets[i]);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Помилка при завантаженні даних: {ex.Message}");
            }
        }

        private void OpenDetailsWindow(Asset asset)
        {
            if (asset != null)
            {
                DetailsWindow detailsWindow = new DetailsWindow(asset);
                detailsWindow.ShowDialog();
            }
        }
    }
}

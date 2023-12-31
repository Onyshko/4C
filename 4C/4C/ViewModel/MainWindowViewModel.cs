using _4C.Model;
using _4C.MVVM;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

namespace _4C.ViewModel
{
    class MainWindowViewModel : ViewModelBase
    {
        public ObservableCollection<Asset> Assets { get; set; }

        public MainWindowViewModel()
        {
            Assets = new ObservableCollection<Asset>();
        }

        public async Task InitializeAsync()
        {
            try
            {
                var loadedAssets = await DataFromApi.CreateAsync();
                foreach (var asset in loadedAssets)
                {
                    Assets.Add(asset);
                }
            }
            catch (Exception ex)
            {
                // Логування або обробка помилок
                Debug.WriteLine($"Помилка при завантаженні даних: {ex.Message}");
            }
        }


        private Asset selectedAsset;
        public Asset SelectedAsset
        {
            get { return selectedAsset; }
            set 
            { 
                selectedAsset = value;
                OnPropertyChanged();
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace KerridgeAsessment.ViewModels
{
    public abstract class BaseViewModel : INotifyPropertyChanged
    {
        private bool isLoading;
        private string message;

        public bool IsLoading
        { 
            get => isLoading;
            set => SetProperty(ref isLoading, value);
        }

        public string Message
        {
            get => message;
            set => SetProperty(ref message, value);
        }

        protected bool SetProperty<T>(ref T backingStore, T value,
           [CallerMemberName] string propertyName = "",
           Action onChanged = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return false;

            backingStore = value;
            onChanged?.Invoke();
            OnPropertyChanged(propertyName);
            return true;
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            var changed = PropertyChanged;
            if (changed == null)
                return;

            changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected async Task PushPage(Page page)
        {
            await MainThread.InvokeOnMainThreadAsync(async () =>
            {
                await App.Current.MainPage.Navigation.PushAsync(page);
            });
        }

        protected async Task PopPage()
        {
            await MainThread.InvokeOnMainThreadAsync(async () =>
            {
                await App.Current.MainPage.Navigation.PopAsync();
            });
        }

        protected async Task DisplayAlert(string title, string message, string cancel)
        {
            await MainThread.InvokeOnMainThreadAsync(async () =>
            {
                await App.Current.MainPage.DisplayAlert(title, message, cancel);
            });
        }
    }
}

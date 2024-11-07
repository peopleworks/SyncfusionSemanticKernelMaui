using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace SyncfusionSemanticKernelMaui.ViewModels;

public class BaseViewModel : INotifyPropertyChanged
{
    public bool IsBusy { get; set; }
    protected async Task RunSafe(Func<Task> task)
    {
        try
        {
            if (IsBusy)
            {
                return;
            }
            IsBusy = true;
            await task.Invoke();
        }
        catch (Exception e)
        {
            IsBusy = false;
            await App.Current.MainPage.DisplayAlert("Error", e.Message, "OK");
        }
        finally
        {
            IsBusy = false;
        }
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    protected bool SetField<T>(ref T field, T value, [CallerMemberName] string? propertyName = null)
    {
        if (EqualityComparer<T>.Default.Equals(field, value)) return false;
        field = value;
        OnPropertyChanged(propertyName);
        return true;
    }
}
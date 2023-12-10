using CommunityToolkit.Mvvm.ComponentModel;

namespace MockMoney.ViewModels;

public abstract partial class ViewModelBase: ObservableObject
{
    [ObservableProperty]
    private bool _isVisibleLoader;
}
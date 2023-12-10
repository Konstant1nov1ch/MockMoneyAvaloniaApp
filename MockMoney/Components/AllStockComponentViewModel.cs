using CommunityToolkit.Mvvm.ComponentModel;
using MockMoney.Model.MockMoneyApiJsonObjects;

namespace MockMoney.Components;

public partial class AllStockComponentViewModel : BaseLikedViewModel
{
    [ObservableProperty]
    private GetStocks _stocks;
}

using Avalonia.Controls;
using Microsoft.Extensions.DependencyInjection;

namespace MockMoney.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private async void App_OnClosing(object? sender, WindowClosingEventArgs e)
    {
     
    }
}
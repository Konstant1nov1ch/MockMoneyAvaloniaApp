using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MediatR;
using MockMoney.Commands.LoginFromApi;
using MockMoney.Service;

namespace MockMoney.ViewModels;

public partial class MainPageViewModel : ViewModelBase
{
    // private readonly IMediator _mediator;
    private readonly ITokenService _tokenService;
    // private readonly ILogger<MainViewModel> _logger;

    [ObservableProperty]
    private string _TokenFromApi;
    

    public MainPageViewModel()
    {

   //     _mediator = Helpers.GetAppServiceProvider().GetService<IMediator>()!;
    }

    [RelayCommand]
    private async Task LoginInAppAsync(CancellationToken cancellationToken)
    {
        try
        {

            _TokenFromApi = _tokenService.Token;
        }
        catch (Exception ex)
        {
            //_logger.LogError(ex, "An error occurred during login.");
        }
        finally
        {
            IsVisibleLoader = false;
        }
    }
}
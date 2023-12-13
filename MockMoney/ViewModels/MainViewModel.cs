using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MediatR;
using Microsoft.Extensions.Logging;
using MockMoney.Commands.LoginFromApi;
using MockMoney.Service;
using MockMoney.ViewModels;

public partial class MainViewModel : ViewModelBase
{
    private readonly IMediator _mediator;
    private readonly ITokenService _tokenService;
    private readonly ILogger<MainViewModel> _logger;

    [ObservableProperty]
    private string _login;

    [ObservableProperty]
    private string _password; 

    [ObservableProperty]
    private bool _isLogin;

    [ObservableProperty]
    private bool _isLoading;

    public MainViewModel()
    {
        // _mediator = mediator;
        // _tokenService = tokenService;
        // _logger = logger
    }

    [RelayCommand]
    private async Task LoginInAppAsync(CancellationToken cancellationToken)
    {
        try
        {
            IsVisibleLoader = true;

            var hashedPassword = _password;

            var loginRequest = new LoginApiRequest(_login, hashedPassword);

            var response = await _mediator.Send(loginRequest, cancellationToken);

            if (response.Token != "")
            {
                _isLogin = true;
                _tokenService.Token = response.Token;
                _logger.LogInformation("User logged in successfully.");
            }
            else
            {
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred during login.");
        }
        finally
        {
            IsVisibleLoader = false;
        }
    }

    
}

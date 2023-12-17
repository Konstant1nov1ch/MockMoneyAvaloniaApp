using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using MockMoney.Commands.LoginFromApi;
using MockMoney.Commands.RegisterApi;
using MockMoney.Infrastructure.Service;
using MockMoney.Views;

namespace MockMoney.ViewModels;

public partial class RegisterAppViewModel : ViewModelBase
{
    private readonly IMediator _mediator;
    private readonly ITokenService _tokenService;
    // private readonly ILogger<MainViewModel> _logger;

    [ObservableProperty]
    private string _login;
    
    [ObservableProperty]
    private string _name;

    [ObservableProperty]
    private string _password; 

    [ObservableProperty]
    private bool _isRegister;
    
    [ObservableProperty]
    private bool _isLogin;
    
    [ObservableProperty]
    private bool _isLoading;
    
    private string _tokenFromApi;

    public string TokenFromApi
    {
        get => _tokenFromApi;
        set => SetProperty(ref _tokenFromApi, value);
    }

    public RegisterAppViewModel()
    {

        _mediator = Helpers.GetAppServiceProvider().GetService<IMediator>()!;
        _tokenService =  Helpers.GetAppServiceProvider().GetRequiredService<ITokenService>();


    }

    [RelayCommand]
    private async Task RegisterAppCommand(CancellationToken cancellationToken)
    {
        try
        {
            IsVisibleLoader = true;

            var hashedPassword = Password;

            var loginRequest = Login;

            var name = Name;

            var response = await _mediator.Send(new RegisterApiRequest(name, loginRequest, hashedPassword), cancellationToken);
            
            if (response.IsSuccessful)
            {
                IsRegister = true;
                try
                {
                    var response2 = await _mediator.Send(new LoginApiRequest(loginRequest, hashedPassword), cancellationToken);
                    var token = response2.Token;

                    if (response2.Token != "")
                    {
                        IsLogin = true;
                        _tokenService.Token = token;
                        TokenFromApi = _tokenService.Token;

                        Console.Write(response);
                    }
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
            else
            {
            }
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
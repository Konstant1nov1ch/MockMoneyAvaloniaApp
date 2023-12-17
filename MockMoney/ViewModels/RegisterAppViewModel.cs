using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using MockMoney.Commands.RegisterApi;
using MockMoney.Infrastructure.Service;
using MockMoney.Views;

namespace MockMoney.ViewModels;

public partial class RegisterAppViewModel : ViewModelBase
{
    private readonly IMediator _mediator;
   // private readonly ITokenService _tokenService;
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
    private bool _isLoading;


    public RegisterAppViewModel()
    {

        _mediator = Helpers.GetAppServiceProvider().GetService<IMediator>()!;

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
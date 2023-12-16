﻿using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using MockMoney;
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

        _mediator = Helpers.GetAppServiceProvider().GetService<IMediator>()!;
    }

    [RelayCommand]
    private async Task LoginInAppAsync(CancellationToken cancellationToken)
    {
        try
        {
            IsVisibleLoader = true;

            var hashedPassword = Password;

            var loginRequest = Login;

            var response = await _mediator.Send(new LoginApiRequest(loginRequest, hashedPassword), cancellationToken);
            var token = response.Token;
            
            if (response.Token != "")
            {
                IsLogin = true;
                _tokenService.Token = response.Token;
               Console.Write(response);
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

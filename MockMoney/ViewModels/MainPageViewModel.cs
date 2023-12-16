using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using MockMoney.Commands.LoginFromApi;
using MockMoney.Infrastructure.Service;

namespace MockMoney.ViewModels;

public partial class MainPageViewModel : ViewModelBase
{
    // private readonly IMediator _mediator;
    private readonly ITokenService _tokenService;
    // private readonly ILogger<MainViewModel> _logger;
    
    private string _tokenFromApi;
    
    public string TokenFromApi
    {
        get => _tokenFromApi;
        set => SetProperty(ref _tokenFromApi, value);
    }

    
    public  MainPageViewModel()
    {
            _tokenService =  Helpers.GetAppServiceProvider().GetRequiredService<ITokenService>();
            TokenFromApi = _tokenService.Token;
            _tokenService.TokenChanged += TokenService_TokenChanged;
    }

    private void TokenService_TokenChanged(object sender, EventArgs e)
    {
        TokenFromApi = _tokenService.Token;
    }
    
}
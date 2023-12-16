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

    //public MainPageViewModel()
    //{

   //     _mediator = Helpers.GetAppServiceProvider().GetService<IMediator>()!;
    //}
    
    public  MainPageViewModel()
    {
            _tokenService =  Helpers.GetAppServiceProvider().GetRequiredService<ITokenService>();
            UpdateTokenFromApi();
    }

    // public MainPageViewModel()
    // {
    //     throw new NotImplementedException();
    // }

    public void UpdateTokenFromApi()
    {
        TokenFromApi = _tokenService.Token;
    }
}
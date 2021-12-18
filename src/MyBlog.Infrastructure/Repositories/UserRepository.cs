using Microsoft.Extensions.Options;
using System.Net;

public class UserRepository : BaseRepository, IUserRepository
{
    private readonly ApiAuthenticationRoutingConfigurations _routingConfigurations;

    public UserRepository(IHttpClientFactory client, IOptions<ApiAuthenticationRoutingConfigurations> routingConfigurations)
        : base(client) =>  _routingConfigurations = routingConfigurations.Value;

    public async Task<HttpResponseViewModel<UserViewModel>> GetByIdAsync(int? id, string token)
    {
        HttpRequestMessage request = new(HttpMethod.Get, _routingConfigurations.RetrieveGetUserByIdPath(id));
        request.Headers.Authorization = new("Bearer", token);
        HttpResponseMessage response = await Client.CreateClient().SendAsync(request);
        return response.IsSuccessStatusCode ? new(true)
            : new(false, await (await response.Content.ReadAsStringAsync()).FromJsonAsync<ErrorViewModel>());
    }

    public async Task<HttpLoginResponseViewModel> SignUpAsync(CreateUserInputModel inputModel)
    {
        HttpRequestMessage request = new(HttpMethod.Post, _routingConfigurations.SignUpPath);
        request.Content = SetRequestContent(inputModel);
        HttpResponseMessage response = await Client.CreateClient().SendAsync(request);
        var responseJson = await response.Content.ReadAsStringAsync();

        return response.StatusCode == HttpStatusCode.Created ? 
            new(true, (await (await response.Content.ReadAsStringAsync()).FromJsonAsync<LoginResultViewModel>()).Token)
            : new(false, await (await response.Content.ReadAsStringAsync()).FromJsonAsync<ErrorViewModel>());
    }

    public async Task<HttpLoginResponseViewModel> SignInAsync(SignInUserModel inputModel)
    {
        HttpRequestMessage request = new(HttpMethod.Post, _routingConfigurations.SignInPath);
        request.Content = SetRequestContent(inputModel);
        HttpResponseMessage response = await Client.CreateClient().SendAsync(request);
        return response.IsSuccessStatusCode ? 
            new(true, (await (await response.Content.ReadAsStringAsync()).FromJsonAsync<LoginResultViewModel>()).Token)
            : new(false, await (await response.Content.ReadAsStringAsync()).FromJsonAsync<ErrorViewModel>());
    }

    public async Task SignOutAsync() 
        => await Client.CreateClient().SendAsync(new(HttpMethod.Post, _routingConfigurations.SignOutPath));

    public async Task<HttpResponseViewModel<UserViewModel>> GetAuthenticatedUserAsync(string token)
    {
        HttpRequestMessage request = new(HttpMethod.Get, _routingConfigurations.AuthenticatedUserPath);
        request.Headers.Authorization = new("Bearer", token);
        HttpResponseMessage response = await Client.CreateClient().SendAsync(request);

        return response.IsSuccessStatusCode ? new(true, await (await response.Content.ReadAsStringAsync()).FromJsonAsync<UserViewModel>())
            : new(false, await (await response.Content.ReadAsStringAsync()).FromJsonAsync<ErrorViewModel>());
    }

    public async Task<ErrorViewModel> UpdateAuthenticatedUserAsync(CreateUserInputModel inputModel, string token)
    {
        HttpRequestMessage request = new(HttpMethod.Patch, _routingConfigurations.RetrieveUpdateUserPath());
        request.Content = SetRequestContent(inputModel);
        request.Headers.Authorization = new("Bearer", token);
        HttpResponseMessage response = await Client.CreateClient().SendAsync(request);

        return response.IsSuccessStatusCode ? null
            : await (await response.Content.ReadAsStringAsync()).FromJsonAsync<ErrorViewModel>();
    }
}

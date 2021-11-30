using Microsoft.Extensions.Options;
using System.Net;

public class AuthenticationRepository : BaseRepository, IAuthenticationRepository
{
    private readonly ApiAuthenticationRoutingConfigurations _routingConfigurations;

    public AuthenticationRepository(IHttpClientFactory client, IOptions<ApiAuthenticationRoutingConfigurations> routingConfigurations)
        :base(client) => _routingConfigurations = routingConfigurations.Value;

    public async Task<HttpResponseViewModel<UserViewModel>> GetByIdAsync(int? id)
    {
        HttpRequestMessage request = new(HttpMethod.Get, _routingConfigurations.GetGetUserByIdPath(id));
        HttpResponseMessage response = await Client.CreateClient().SendAsync(request);

        string responseJson = await response.Content.ReadAsStringAsync();
        return response.IsSuccessStatusCode ? new(await responseJson.FromJsonAsync<UserViewModel>())
            : new(await responseJson.FromJsonAsync<ErrorViewModel>());
    }

    public async Task<HttpResponseViewModel<LoginResultViewModel>> SignUpAsync(CreateUserInputModel inputModel)
    {
        HttpRequestMessage request = new(HttpMethod.Post, _routingConfigurations.GetSignUpPath());
        request.Content = SetRequestContent(inputModel);
        HttpResponseMessage response = await Client.CreateClient().SendAsync(request);

        string responseJson = await response.Content.ReadAsStringAsync();
        return response.StatusCode == HttpStatusCode.Created ? new(await responseJson.FromJsonAsync<LoginResultViewModel>()) 
            : new(await responseJson.FromJsonAsync<ErrorViewModel>());
    }

    public async Task<HttpResponseViewModel<LoginResultViewModel>> SignInAsync(SignInUserModel inputModel)
    {
        HttpRequestMessage request = new(HttpMethod.Post, _routingConfigurations.GetSignInPath());
        request.Content = SetRequestContent(inputModel);
        HttpResponseMessage response = await Client.CreateClient().SendAsync(request);

        string responseJson = await response.Content.ReadAsStringAsync();
        return response.IsSuccessStatusCode ? new(await responseJson.FromJsonAsync<LoginResultViewModel>())
            : new(await responseJson.FromJsonAsync<ErrorViewModel>());
    }

    public async Task<ErrorViewModel> UpdateAsync(CreateUserInputModel inputModel)
    {
        HttpRequestMessage request = new(HttpMethod.Patch, _routingConfigurations.GetUpdateUserPath());
        request.Content = SetRequestContent(inputModel);
        HttpResponseMessage response = await Client.CreateClient().SendAsync(request);

        return response.IsSuccessStatusCode ? null
            : await response.Content.ReadAsStringAsync().Result.FromJsonAsync<ErrorViewModel>();
    }
}

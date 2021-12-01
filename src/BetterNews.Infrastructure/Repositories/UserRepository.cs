using Microsoft.Extensions.Options;
using System.Net;

public class UserRepository : BaseRepository, IUserRepository
{
    private readonly ApiAuthenticationRoutingConfigurations _routingConfigurations;

    public UserRepository(IHttpClientFactory client, IOptions<ApiAuthenticationRoutingConfigurations> routingConfigurations)
        : base(client) =>  _routingConfigurations = routingConfigurations.Value;

    public async Task<HttpResponseViewModel> GetByIdAsync(int? id, string token)
    {
        HttpRequestMessage request = new(HttpMethod.Get, _routingConfigurations.GetGetUserByIdPath(id));
        request.Headers.Authorization = new("Bearer", token);
        HttpResponseMessage response = await Client.CreateClient().SendAsync(request);

        string responseJson = await response.Content.ReadAsStringAsync();
        return response.IsSuccessStatusCode ? new(true)
            : new(false, await responseJson.FromJsonAsync<ErrorViewModel>());
    }

    public async Task<HttpLoginResponseViewModel> SignUpAsync(CreateUserInputModel inputModel)
    {
        HttpRequestMessage request = new(HttpMethod.Post, _routingConfigurations.GetSignUpPath());
        request.Content = SetRequestContent(inputModel);
        HttpResponseMessage response = await Client.CreateClient().SendAsync(request);

        string responseJson = await response.Content.ReadAsStringAsync();
        return response.StatusCode == HttpStatusCode.Created ? new(true, (await responseJson.FromJsonAsync<LoginResultViewModel>()).Token)
            : new (false, await responseJson.FromJsonAsync<ErrorViewModel>());
    }

    public async Task<HttpLoginResponseViewModel> SignInAsync(SignInUserModel inputModel)
    {
        HttpRequestMessage request = new(HttpMethod.Post, _routingConfigurations.GetSignInPath());
        request.Content = SetRequestContent(inputModel);
        HttpResponseMessage response = await Client.CreateClient().SendAsync(request);

        string responseJson = await response.Content.ReadAsStringAsync();
        return response.IsSuccessStatusCode ? new(true, (await responseJson.FromJsonAsync<LoginResultViewModel>()).Token)
            : new(false, await responseJson.FromJsonAsync<ErrorViewModel>());
    }

    public async Task SignOutAsync()
    {
        HttpRequestMessage request = new(HttpMethod.Post, _routingConfigurations.GetSignOutPath());
        HttpResponseMessage response = await Client.CreateClient().SendAsync(request);
    }

    public async Task<ErrorViewModel> UpdateAsync(CreateUserInputModel inputModel, string token)
    {
        HttpRequestMessage request = new(HttpMethod.Patch, _routingConfigurations.GetUpdateUserPath());
        request.Content = SetRequestContent(inputModel);
        request.Headers.Authorization = new("Bearer", token);
        HttpResponseMessage response = await Client.CreateClient().SendAsync(request);

        return response.IsSuccessStatusCode ? null
            : await response.Content.ReadAsStringAsync().Result.FromJsonAsync<ErrorViewModel>();
    }
}

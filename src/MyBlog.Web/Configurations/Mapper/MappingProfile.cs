using AutoMapper;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<HttpLoginResponseViewModel, HttpResponseViewModel<UserViewModel>>();
        CreateMap<UserViewModel, CreateUserInputModel>();
    }
}

using AutoMapper;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<HttpLoginResponseViewModel, HttpResponseViewModel>();
        CreateMap<HttpResponseViewModel, CreateUserInputModel>();
        CreateMap<UserViewModel, CreateUserInputModel>();
    }
}

using AutoMapper;
using Thor.WebApi.Infrastructure.Accessors.MySql.Dal;
using Thor.WebApi.Models;
using Thor.WebApi.ViewModels;

namespace Thor.WebApi;

public class WebApiMapper : Profile
{
    public WebApiMapper()
    {
        CreateMap<User, UserDal>().ReverseMap();

        CreateMap<User, UserViewModel>();
    }
}
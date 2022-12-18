using AutoMapper;
using SelfFit.Identity.Features.Authentication.Commands;
using SelfFit.WebApi.Models.User.Requests;

namespace SelfFit.WebApi.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<SignInRequest, SignInUserCommand>();
        }
    }
}

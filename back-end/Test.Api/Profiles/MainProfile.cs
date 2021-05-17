using AutoMapper;
using Test.Model.Entities;
using Test.Shared.DTO;

namespace Test.Api.Profiles
{
    public class MainProfile : Profile
    {
        public MainProfile()
        {
            CreateMap<Product, ProductDTO>().ReverseMap();
        }

    }
}

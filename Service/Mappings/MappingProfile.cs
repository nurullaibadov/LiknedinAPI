using AutoMapper;
using Core.DTOs;
using Core.Entities;
namespace Service.Mappings{
public class MappingProfile:Profile{
public MappingProfile(){CreateMap().ReverseMap();}
}
}
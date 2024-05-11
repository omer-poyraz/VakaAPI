using AutoMapper;
using Entities.DTOs.ProductDto;
using Entities.DTOs.RoomDto;
using Entities.DTOs.StoreDto;
using Entities.DTOs.StructureDto;
using Entities.DTOs.UserDto;
using Entities.DTOs.WorkOrderDto;
using Entities.Models;
using Microsoft.AspNetCore.Identity;

namespace Vaka.Utilities.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserForRegisterDto, User>();
            CreateMap<UserDtoForUpdate, User>().ReverseMap();
            CreateMap<User, UserDto>();
            CreateMap<IdentityResult, UserDto>().ReverseMap();

            CreateMap<ProductDtoForUpdate, Product>().ReverseMap();
            CreateMap<Product, ProductDto>();
            CreateMap<ProductDtoForInsertion, Product>();

            CreateMap<RoomDtoForUpdate, Room>().ReverseMap();
            CreateMap<Room, RoomDto>();
            CreateMap<RoomDtoForInsertion, Room>();

            CreateMap<StoreDtoForUpdate, Store>().ReverseMap();
            CreateMap<Store, StoreDto>();
            CreateMap<StoreDtoForInsertion, Store>();

            CreateMap<StructureDtoForUpdate, Structure>().ReverseMap();
            CreateMap<Structure, StructureDto>();
            CreateMap<StructureDtoForInsertion, Structure>();

            CreateMap<WorkOrderDtoForUpdate, WorkOrder>().ReverseMap();
            CreateMap<WorkOrder, WorkOrderDto>();
            CreateMap<WorkOrderDtoForInsertion, WorkOrder>();
        }
    }
}

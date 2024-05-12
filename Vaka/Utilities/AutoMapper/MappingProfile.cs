using AutoMapper;
using Entities.DTOs.ProductDto;
using Entities.DTOs.ProductRoomDto;
using Entities.DTOs.ProductStoreDto;
using Entities.DTOs.RoomDto;
using Entities.DTOs.SaveStoreDto;
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
            CreateMap<WorkOrderDtoForProductInsertion, WorkOrder>();
            CreateMap<WorkOrderDtoForRoomInsertion, WorkOrder>();
            CreateMap<WorkOrderDtoForStoreInsertion, WorkOrder>();
            CreateMap<WorkOrderDtoForStructureInsertion, WorkOrder>();

            CreateMap<ProductRoom, ProductRoomDto>();
            CreateMap<ProductRoomDtoForInsertion, ProductRoom>();

            CreateMap<ProductStore, ProductStoreDto>();
            CreateMap<ProductStoreDtoForInsertion, ProductStore>();

            CreateMap<SaveStoreDtoForUpdate, SaveStore>().ReverseMap();
            CreateMap<SaveStore, SaveStoreDto>();
            CreateMap<SaveStoreDtoForInsertion, SaveStore>();
        }
    }
}

using AutoMapper;
using BLL.DTOs;
using Common.Enums;
using DAL.Entities;

namespace BLL.Mappers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<int?, int>().ConvertUsing((src, dest) => src ?? dest);
            CreateMap<decimal?, decimal>().ConvertUsing((src, dest) => src ?? dest);
            CreateMap<string?, string>().ConvertUsing((src, dest) => src ?? dest);
            CreateMap<bool?, bool>().ConvertUsing((src, dest) => src ?? dest);
            CreateMap<Guid?, Guid>().ConvertUsing((src, dest) => src ?? dest);
            CreateMap<DateTime?, DateTime>().ConvertUsing((src, dest) => src ?? dest);
            CreateMap<LotStatus?, LotStatus>().ConvertUsing((src, dest) => src ?? dest);
            CreateMap<StockInRequestStatus?, StockInRequestStatus>().ConvertUsing((src, dest) => src ?? dest);

            // User Mappings
            CreateMap<UserCreateDTO, User>()
                .ForMember(dest => dest.PasswordHash, opt => opt.Ignore());

            CreateMap<UserUpdateDTO, User>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<User, UserViewDTO>()
                .ForMember(dest => dest.RoleName, opt => opt.MapFrom(src => src.Role.Name));

            // Role Mappings
            CreateMap<RoleCreateDTO, Role>();

            CreateMap<RoleUpdateDTO, Role>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<Role, RoleViewDTO>()
                .ForMember(dest => dest.RoleId, opt => opt.MapFrom(src => src.Id));

            // Item Mappings
            CreateMap<ItemCreateDTO, Item>()
                .ForMember(dest => dest.ItemCategoryId, opt => opt.MapFrom(src => src.ItemCategoryId))
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId));

            CreateMap<ItemUpdateDTO, Item>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<Item, ItemViewDTO>()
                .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.ItemCategory.Name))
                .ForMember(dest => dest.SupplierName, opt => opt.MapFrom(src => src.User.FullName))
                .ForMember(dest => dest.ItemType, opt => opt.MapFrom(src => src.UnitType.ToString()));

            // Item Category Mappings
            CreateMap<ItemCategory, ItemCategoryDTO>()
                .ReverseMap()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            // Order Mappings
            CreateMap<Order, OrderViewDTO>()
                .ForMember(dest => dest.OrderDetails, opt => opt.MapFrom(src => src.OrderDetails))
                .ForMember(dest => dest.Username, opt => opt.MapFrom(src => src.User.FullName));

            CreateMap<OrderCreateDTO, Order>()
                .ForMember(dest => dest.OrderDetails, opt => opt.MapFrom(src => src.OrderDetails));

            CreateMap<OrderUpdateDTO, Order>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            // Order Detail Mappings
            CreateMap<OrderDetailCreateDTO, OrderDetail>();

            CreateMap<OrderDetail, OrderDetailViewDTO>()
                .ForMember(dest => dest.OrderDate, opt => opt.MapFrom(src => src.Order.OrderDate))
                .ForMember(dest => dest.ItemName, opt => opt.MapFrom(src => src.Item.Name))
                .ForMember(dest => dest.UnitPrice, opt => opt.MapFrom(src => src.Price));

            // Submission Mappings
            CreateMap<Submission, SubmissionViewDTO>()
                .ForMember(dest => dest.FromUserName, opt => opt.MapFrom(src => src.FromUser.FullName))
                .ForMember(dest => dest.ToUserName, opt => opt.MapFrom(src => (src.ToUser != null) ? src.ToUser.FullName : ""))
                .ForMember(dest => dest.StorageName, opt => opt.MapFrom(src => (src.Storage != null) ? src.Storage.Name : ""))
                .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.Type.ToString()));

            CreateMap<SubmissionCreateDTO, Submission>();

            CreateMap<SubmissionUpdateDTO, Submission>()
                .ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));

            // Lot Request Mappings
            CreateMap<ItemLot, ItemLotViewDTO>()
                .ForMember(dest => dest.Item, opt => opt.MapFrom(src => src.Item))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status.ToString()))
                .ForMember(dest => dest.StorageName, opt => opt.MapFrom(src => src.Storage.Name));

            CreateMap<ItemLotCreateDTO, ItemLot>();

            CreateMap<ItemLotUpdateDTO, ItemLot>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));


            CreateMap<ItemLotAdminUpdateDTO, ItemLot>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            // Storage Mappings
            CreateMap<Storage, StorageViewDTO>()
                .ForMember(dest => dest.StorageCategoryName, opt => opt.MapFrom(src => src.StorageCategory.Name));

            CreateMap<StorageCategoryCreateDTO, Storage>();

            CreateMap<StorageCreateDTO, Storage>();

            CreateMap<StorageUpdateDTO, Storage>();

            CreateMap<StorageCategoryUpdateDTO, Storage>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            //Storage Category Mappings 
            CreateMap<StorageCategory, StorageCategoryViewDTO>();

            CreateMap<StorageCategoryCreateDTO, StorageCategory>();

            CreateMap<StorageCategoryUpdateDTO, StorageCategory>();

            CreateMap<StorageCategoryUpdateDTO, Storage>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<StockInRequest, StockInRequestViewDTO>()
                .ForMember(dest => dest.Username, opt => opt.MapFrom(src => src.User.FullName))
                .ForMember(dest => dest.ItemName, opt => opt.MapFrom(src => src.Item.Name));

            CreateMap<StockInRequestCreateDTO, StockInRequest>();

            CreateMap<StockInRequestUpdateDTO, StockInRequest>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}

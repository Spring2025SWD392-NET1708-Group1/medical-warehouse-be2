using AutoMapper;
using BLL.DTOs;
using DAL.Entities;

namespace BLL.Mappers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
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
                .ForMember(dest => dest.ItemCategoryId, opt => opt.MapFrom(src => src.ItemCategoryId));

            CreateMap<ItemUpdateDTO, Item>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<Item, ItemViewDTO>()
                .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.ItemCategory.Name));

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
                .ForPath(dest => dest.UserName, opt => opt.MapFrom(src => src.User.FullName))
                .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.Type.ToString()))
                .ForMember(dest => dest.SubmittedAt, opt => opt.MapFrom(src => src.CreatedDate));

            CreateMap<SubmissionCreateDTO, Submission>();

            CreateMap<SubmissionUpdateDTO, Submission>()
                .ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));

            // Lot Request Mappings
            CreateMap<LotRequest, LotRequestViewDTO>()
                .ForMember(dest => dest.Item, opt => opt.MapFrom(src => src.Item))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status.ToString()))
                .ForMember(dest => dest.Username, opt => opt.MapFrom(src => src.User.FullName))
                .ForMember(dest => dest.StorageName, opt => opt.MapFrom(src => src.Storage.Name));

            CreateMap<LotRequestCreateDTO, LotRequest>();

            CreateMap<LotRequestUpdateDTO, LotRequest>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<LotRequestAdminUpdateDTO, LotRequest>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            // Storage Mappings
            CreateMap<Storage, StorageViewDTO>();

            CreateMap<StorageCategoryCreateDTO, Storage>();

            CreateMap<StorageCategoryUpdateDTO, Storage>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            //Storage Category Mappings 
            CreateMap<StorageCategory, StorageCategoryViewDTO>();

            CreateMap<StorageCategoryCreateDTO, Storage>();

            CreateMap<StorageCategoryUpdateDTO, Storage>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}

using AutoMapper;
using BLL.DTOs;
using DAL.Entities;

namespace BLL.Mappers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            // Create mapping
            CreateMap<UserCreateDTO, User>()
                .ForMember(dest => dest.PasswordHash, opt => opt.Ignore()); // Hashing should be done before saving

            // Update mapping (only map non-null values)
            CreateMap<UserUpdateDTO, User>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) =>
                    srcMember != null));

            // View mapping (fetch related RoleName)
            CreateMap<User, UserViewDTO>()
                .ForMember(dest => dest.RoleName, opt => opt.MapFrom(src => src.Role.Name));

            CreateMap<Role, RoleDTO>()
                .ReverseMap()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<ItemCreateDTO, Item>();

            CreateMap<ItemUpdateDTO, Item>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<Item, ItemViewDTO>()
                .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.ItemCategory.Name));

            CreateMap<ItemCategory, ItemCategoryDTO>()
                .ReverseMap()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<Order, OrderDTO>()
                .ReverseMap()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<OrderDetailCreateDTO, OrderDetail>();

            CreateMap<OrderDetailUpdateDTO, OrderDetail>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<OrderDetail, OrderDetailViewDTO>()
                .ForMember(dest => dest.OrderDate, opt => opt.MapFrom(src => src.Order.OrderDate))
                .ForMember(dest => dest.ItemName, opt => opt.MapFrom(src => src.Item.Name));

            CreateMap<SubmissionCreateDTO, Submission>();

            CreateMap<SubmissionUpdateDTO, Submission>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<Submission, SubmissionViewDTO>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.User.FullName))
                .ForMember(dest => dest.SubmittedAt, opt => opt.MapFrom(src => src.CreatedDate));

            CreateMap<LotRequest, LotRequestViewDTO>()
                .ForMember(dest => dest.Item, opt => opt.MapFrom(src => src.Item))
                .ForMember(dest => dest.StaffName, opt => opt.MapFrom(src => src.Staff.FullName));

            CreateMap<LotRequestCreateDTO, LotRequest>();

            CreateMap<LotRequestUpdateDTO, LotRequest>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

        }
    }
}

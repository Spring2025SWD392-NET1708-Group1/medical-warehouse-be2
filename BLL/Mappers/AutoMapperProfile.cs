using AutoMapper;
using BLL.DTOs;
using DAL.Entities;

namespace BLL.Mappers
{
  public class AutoMapperProfile : Profile
  {
    public AutoMapperProfile()
    {
      CreateMap<UserCreateDTO, User>()
          .ForMember(dest => dest.PasswordHash, opt => opt.Ignore());

      CreateMap<UserUpdateDTO, User>()
          .ForAllMembers(opts => opts.Condition((src, dest, srcMember) =>
              srcMember != null));

      CreateMap<User, UserViewDTO>()
          .ForMember(dest => dest.RoleName, opt => opt.MapFrom(src => src.Role.Name));

      CreateMap<RoleCreateDTO, Role>();

      CreateMap<RoleUpdateDTO, Role>()
          .ForAllMembers(opts => opts.Condition((src, dest, srcMember) =>
              srcMember != null));

      CreateMap<Role, RoleViewDTO>()
          .ForMember(dest => dest.RoleId, opt => opt.MapFrom(src => src.Id));

      CreateMap<ItemCreateDTO, Item>()
          .ForMember(dest => dest.ItemCategoryId, opt => opt.MapFrom(src => src.ItemCategoryId));

      CreateMap<ItemUpdateDTO, Item>()
          .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

      CreateMap<Item, ItemViewDTO>()
          .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.ItemCategory.Name));


      CreateMap<ItemCategory, ItemCategoryDTO>()
          .ReverseMap()
          .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
      CreateMap<ItemViewDTO, Item>()
          .ForPath(dest => dest.ItemCategory.Name, opt => opt.MapFrom(src => src.CategoryName));

      CreateMap<ItemCategory, ItemCategoryDTO>()
          .ReverseMap()
          .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

      CreateMap<Order, OrderViewDTO>()
          .ForMember(dest => dest.OrderDetails, opt => opt.MapFrom(src => src.OrderDetails))
          .ForMember(dest => dest.Username, opt => opt.MapFrom(src => src.User.FullName));

      CreateMap<OrderCreateDTO, Order>()
          .ForMember(dest => dest.OrderDetails, opt => opt.MapFrom(src => src.OrderDetails));

      CreateMap<OrderUpdateDTO, Order>()
          .ForAllMembers(opts => opts.Condition((src, dest, srcMember) =>
              srcMember != null));

      CreateMap<OrderDetailCreateDTO, OrderDetail>();

      CreateMap<OrderDetail, OrderDetailViewDTO>()
          .ForPath(dest => dest.OrderDate, opt => opt.MapFrom(src => src.Order.OrderDate))
          .ForMember(dest => dest.ItemName, opt => opt.MapFrom(src => src.Item.Name))
          .ForMember(dest => dest.UnitPrice, opt => opt.MapFrom(src => src.Price));
      CreateMap<Submission, SubmissionViewDTO>()
          .ForPath(dest => dest.UserName, opt => opt.MapFrom(src => src.User.FullName))
          .ForMember(dest => dest.SubmittedAt, opt => opt.MapFrom(src => src.CreatedDate));

      CreateMap<LotRequest, LotRequestViewDTO>()
          .ForMember(dest => dest.Item, opt => opt.MapFrom(src => src.Item))
          .ForPath(dest => dest.StaffName, opt => opt.MapFrom(src => src.Staff.FullName));

      CreateMap<Submission, SubmissionViewDTO>()
          .ForPath(dest => dest.UserName, opt => opt.MapFrom(src => src.User.FullName))
          .ForMember(dest => dest.SubmittedAt, opt => opt.MapFrom(src => src.CreatedDate));

      CreateMap<LotRequest, LotRequestViewDTO>()
          .ForMember(dest => dest.Item, opt => opt.MapFrom(src => src.Item))
          .ForPath(dest => dest.StaffName, opt => opt.MapFrom(src => src.Staff.FullName));

      CreateMap<LotRequestCreateDTO, LotRequest>();

      CreateMap<LotRequestUpdateDTO, LotRequest>()
          .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

    }
  }
}

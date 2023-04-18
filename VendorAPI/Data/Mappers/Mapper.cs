using AutoMapper;
using GenericAppDLL.Models.Mappers;
using GenericAppDLL.Models.ViewModels;

namespace VendorAPI.Data.Mappers
{
    //public class Mapper : GenericAppDLL.Models.Mappers.Mapper
    //{
    //    public Mapper()
    //    :base()
    //    {

    //    }
    //}
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<PurchaseDto, Purchase>().ReverseMap();
            CreateMap<CreatePurchaseDto, Purchase>().ReverseMap();
            CreateMap<CreatePurchaseDto, PurchaseDto>().ReverseMap();
            CreateMap<PurchaseDto, PurchaseViewModel>().ReverseMap();
            CreateMap<PurchaseItemDto, PurchasedItem>().ReverseMap();
            CreateMap<PurchaseItemDto, CreatePurchaseItemDto>().ReverseMap();
            CreateMap<PurchaseItemDto, PurchaseItemViewModel>().ReverseMap();
            CreateMap<DirectMessage, DM>().ReverseMap();
            CreateMap<DirectMessageDto, DirectMessageViewModel>().ReverseMap();
            CreateMap<DirectMessageDto, SendDirectMessageViewModel>().ReverseMap();
            CreateMap<DirectMessageDto, DirectMessage>().ReverseMap();
            CreateMap<DirectMessageDto, DM>().ReverseMap();
            CreateMap<PostDto, Post>().ReverseMap();
            CreateMap<PostDto, PostViewModel>().ReverseMap();
            CreateMap<PostDto, CreatePostViewModel>().ReverseMap();
            CreateMap<VendorDto, Vendor>().ReverseMap();
            CreateMap<VendorDto, VendorViewModel>().ReverseMap();
            CreateMap<VendorDto, CreateVendorViewModel>().ReverseMap();
            CreateMap<MeetUpDto, Meetup>().ReverseMap();
            //CreateMap<MeetUpDto, MeetupViewModel>().ReverseMap();
            CreateMap<MeetUpDto, CreateMeetUpViewModel>().ReverseMap();
            CreateMap<MenuItemDto, Item>().ReverseMap();
            CreateMap<MenuItemDto, MenuItemViewModel>().ReverseMap();
            CreateMap<MenuItemDto, CreateMenuItemViewModel>().ReverseMap();

            //CreateMap<DirectMessageDto, DM>().ReverseMap();

        }
    }

}

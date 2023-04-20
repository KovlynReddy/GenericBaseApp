using AutoMapper;
using GenericAppDLL.Models.Mappers;

namespace GenericBaseMVC.Data.Mapper
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<PurchaseDto, Purchase>().ReverseMap();
            CreateMap<CreatePurchaseDto, Purchase>().ReverseMap();
            CreateMap<PurchaseDto, PurchaseViewModel>().ReverseMap();
            CreateMap<PurchaseItemDto, PurchasedItem>().ReverseMap();
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

            CreateMap<RelationshipDto, Relationship>().ReverseMap();
            CreateMap<CreateRelationshipDto, RelationshipDto>().ReverseMap();
            CreateMap<CreateRelationshipDto, Relationship>().ReverseMap();
            CreateMap<UpdateRelationshipDto, RelationshipDto>().ReverseMap();
            CreateMap<UpdateRelationshipDto, Relationship>().ReverseMap();

            //CreateMap<DirectMessageDto, DM>().ReverseMap();
            CreateMap<CustomerDto, Customer>().ReverseMap();
            CreateMap<CustomerDto, CreateCustomerViewModel>().ReverseMap();
            CreateMap<CustomerDto, CustomerViewModel>().ReverseMap();
            CreateMap<CustomerDto, EditCustomerDto>().ReverseMap();
            CreateMap<CustomerViewModel, EditCustomerDto>().ReverseMap();
            CreateMap<CustomerViewModel, CreateCustomerDto>().ReverseMap();

        }
    }
}

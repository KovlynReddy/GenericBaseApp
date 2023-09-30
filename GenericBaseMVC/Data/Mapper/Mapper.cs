using AutoMapper;
using GenericAppDLL.Models.Mappers;

namespace GenericBaseMVC.Data.Mapper
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<CreateAdvertViewModel, AdvertisingDto>();
            CreateMap<AdvertisingDto, SideAdvertViewModel>();
            CreateMap<AdvertisingDto, Advert>();

            CreateMap<MenuItemDto, ItemViewModel>();
            CreateMap<ItemDto, ItemViewModel>();

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

            CreateMap<JournalEntryDto, JournalEntry>().ReverseMap();
            CreateMap<JournalEntryDto, CreateJournalViewModel>().ReverseMap();
            CreateMap<JournalEntryDto, JournalViewModel>().ReverseMap();

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
            CreateMap<MeetUpDto, CreateMeetUpDto>().ReverseMap();
            CreateMap<CreateMeetUpViewModel,CreateMeetUpDto >().ReverseMap();
            CreateMap<MeetUpDto,MeetupViewModel >().ReverseMap();

            CreateMap<PointsDto, Points>().ReverseMap();
            CreateMap<PointsDto, PointsViewModel>().ReverseMap();

            CreateMap<CustomerDto, Customer>().ReverseMap();
            CreateMap<CustomerDto, CreateCustomerViewModel>().ReverseMap();
            CreateMap<CustomerDto, CustomerViewModel>().ReverseMap();
            CreateMap<CustomerDto, EditCustomerDto>().ReverseMap();
            CreateMap<CustomerViewModel, EditCustomerDto>().ReverseMap();
            CreateMap<CustomerViewModel, CreateCustomerDto>().ReverseMap();

            CreateMap<MeetupRequestDto, Meetup>().ReverseMap();
            CreateMap<CreateMeetupRequestDto, CreateMeetupRequestDto>().ReverseMap();
            CreateMap<CreateMeetupRequestDto, Meetup>().ReverseMap();
            CreateMap<MeetupViewRequestModel, MeetupRequestDto>().ReverseMap();

            CreateMap<PostInteractionDto, CreatePostInteractionDto>().ReverseMap();
            CreateMap<PostInteractionDto, PostInteractionViewModel>().ReverseMap();
            CreateMap<CreatePostInteractionDto, PostInteractionViewModel>().ReverseMap();
            CreateMap<PostInteraction, CreatePostInteractionDto>().ReverseMap();
            CreateMap<PostInteraction, PostInteractionDto>().ReverseMap();


        }
    }
}

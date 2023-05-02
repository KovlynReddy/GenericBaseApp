using AutoMapper;
using GenericAppDLL.Models.Dto;
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
            
            CreateMap<JournalEntryDto, JournalEntry>().ReverseMap();
            CreateMap<JournalEntryDto, CreateJournalViewModel>().ReverseMap();
            CreateMap<JournalEntryDto, JournalViewModel>().ReverseMap();

            CreateMap<VendorDto, Vendor>().ReverseMap();
            CreateMap<VendorDto, VendorViewModel>().ReverseMap();
            CreateMap<VendorDto, CreateVendorViewModel>().ReverseMap();

            CreateMap<MeetUpDto, Meetup>().ReverseMap();
            //CreateMap<MeetUpDto, MeetupViewModel>().ReverseMap();
            CreateMap<MeetUpDto, CreateMeetUpViewModel>().ReverseMap();
            CreateMap<MenuItemDto, Item>().ReverseMap();
            CreateMap<MenuItemDto, MenuItemViewModel>().ReverseMap();
            CreateMap<MenuItemDto, CreateMenuItemViewModel>().ReverseMap();

            CreateMap<Meetup, MeetUpDto>().ReverseMap();
            CreateMap<Meetup, CreateMeetUpDto>().ReverseMap();
            CreateMap<MeetUpDto, CreateMeetUpDto>().ReverseMap();
            
            CreateMap<MeetupRequestDto, MeetupRequest>().ReverseMap();
            CreateMap<CreateMeetupRequestDto, MeetupRequestDto>().ReverseMap();
            CreateMap<CreateMeetupRequestDto, MeetupRequest>().ReverseMap();

            CreateMap<PostInteractionDto, CreatePostInteractionDto>().ReverseMap();
            CreateMap<PostInteraction, CreatePostInteractionDto>().ReverseMap();
            CreateMap<PostInteraction, PostInteractionDto>().ReverseMap();
            
            CreateMap<PointsDto, Points>().ReverseMap();
            CreateMap<PointsDto, PointsViewModel>().ReverseMap();

            CreateMap<CustomerDto, Customer>().ReverseMap();
            CreateMap<CustomerDto, CreateCustomerViewModel>().ReverseMap();
            CreateMap<CustomerDto, CustomerViewModel>().ReverseMap();
            CreateMap<CustomerDto, EditCustomerDto>().ReverseMap();
            CreateMap<CustomerViewModel, EditCustomerDto>().ReverseMap();
            CreateMap<CustomerViewModel, CreateCustomerDto>().ReverseMap();

            CreateMap<RelationshipDto, Relationship>().ReverseMap();
            CreateMap<CreateRelationshipDto, RelationshipDto>().ReverseMap();
            CreateMap<CreateRelationshipDto, Relationship>().ReverseMap();
            CreateMap<UpdateRelationshipDto, RelationshipDto>().ReverseMap();
            CreateMap<UpdateRelationshipDto, Relationship>().ReverseMap();

            //CreateMap<DirectMessageDto, DM>().ReverseMap();

        }
    }

}

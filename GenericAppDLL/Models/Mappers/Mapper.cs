using AutoMapper;
using GenericAppDLL.Models.DomainModel;
using GenericAppDLL.Models.Dto;
using GenericAppDLL.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericAppDLL.Models.Mappers
{
    public class Mapper :Profile
    {
        public Mapper()
        {
            CreateMap<AdvertisingDto, Advert>().ReverseMap();
            CreateMap<SideAdvertViewModel, AdvertisingDto>().ReverseMap();

            CreateMap<CreateAdvertViewModel, AdvertisingDto>()
                .ForPath(dist => dist.VendorGuid, opt => opt.Ignore())
                .ForPath(dist => dist.UserGuid, opt => opt.Ignore())
                .ForPath(dist => dist.CreatorGuid, opt => opt.Ignore())
                .ForPath(dist => dist.ModelGuid, opt => opt.Ignore())
                .ForPath(dist => dist.IsDeleted, opt => opt.Ignore())
                .ForPath(dist => dist.CompletedDateTime, opt => opt.Ignore())
                .ForPath(dist => dist.BookDateTime, opt => opt.Ignore())
                .ForPath(dist => dist.ArrivedDateTime, opt => opt.Ignore())
                .ForPath(dist => dist.CreatedDateTime, opt => opt.Ignore())
                .ForPath(dist => dist.CompletedDateTimeString, opt => opt.Ignore())
                .ForPath(dist => dist.BookDateTimeString, opt => opt.Ignore())
                .ForPath(dist => dist.ArrivedDateTimeString, opt => opt.Ignore())
                .ForPath(dist => dist.CreatedDateTimeString, opt => opt.Ignore())
                .ForPath(dist => dist.Caption, opt => opt.MapFrom(src => src.Caption))
                .ForPath(dist => dist.Description, opt => opt.MapFrom(src => src.Description))
                .ForPath(dist => dist.Hyperlink, opt => opt.MapFrom(src => src.Hyperlink))
                .ForPath(dist => dist.ImagePath01, opt => opt.MapFrom(src => src.ImagePath01))
                .ForPath(dist => dist.ImagePath02, opt => opt.MapFrom(src => src.ImagePath02))
                .ForPath(dist => dist.ImagePath03, opt => opt.MapFrom(src => src.ImagePath03))
                .ForPath(dist => dist.ImagePath04, opt => opt.MapFrom(src => src.ImagePath04))
                .ForPath(dist => dist.VideoPath01, opt => opt.MapFrom(src => src.VideoPath01))
                .ForPath(dist => dist.Type, opt => opt.MapFrom(src => src.Type))
                .ForPath(dist => dist.Gif01, opt => opt.MapFrom(src => src.Gif01))
                .ForPath(dist => dist.StartingDate, opt => opt.MapFrom(src => src.StartingDate))
                .ForPath(dist => dist.CompletionDate, opt => opt.MapFrom(src => src.CompletionDate))
                .ReverseMap()
                .ForPath(dist => dist.settings, opt => opt.Ignore())
                .ForPath(dist => dist.uploadPaths, opt => opt.Ignore())
                .ForPath(dist => dist.uploads, opt => opt.Ignore());

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
            
            //CreateMap<DirectMessageDto, DM>().ReverseMap();

        }
    }
}

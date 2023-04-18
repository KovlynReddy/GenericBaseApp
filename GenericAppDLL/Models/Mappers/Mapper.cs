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
            CreateMap<PurchaseDto, Purchase>().ReverseMap();
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

﻿using AutoMapper;
using GenericAppDLL.Models.DomainModel;
using System.Security.AccessControl;
using System.Security.Policy;
using VendorAPI.Data.Interface;

namespace VendorAPI.Data.Repository
{
    public class DirectMessageDB : IDirectMessagesDB
    {
        private readonly VendorContext _context;
        public IMapper mapper { get; }

        public DirectMessageDB(VendorContext context, IMapper mapper)
        {
            _context = context;
        }

        public async Task<DirectMessageDto> Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<DirectMessageDto>> Get()
        {
            throw new NotImplementedException();
        }     
       
        public async Task<IEnumerable<DirectMessageDto>> Get(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<DirectMessageDto>> Get(string Id)
        {
            var Messages = _context.Messages.Where(m => (m.SenderGuid == Id) || ( m.RecieverGuid == Id) || (m.ModelGUID == Id)).ToList();

            var messages = convertToDto(Messages);

            return messages;
        }

        public async Task<DirectMessageDto> Post(DirectMessageDto model)
        {
            DM newEntity = new DM() { 
            Message = model.Message, 
            SenderGuid = model.SenderGuid,
            RecieverGuid = model.RecieverGuid,
            ModelGUID = Guid.NewGuid().ToString(),
            CreatedDateTime = DateTime.Now.ToString(),
            };

            await _context.Messages.AddAsync(newEntity);
            await _context.SaveChangesAsync();

            return model;
        }

        public async Task<DirectMessageDto> Put(DirectMessageDto model)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<DirectMessageDto>> Get(string id, string email)
        {
            var Messages = _context.Messages.Where(m=>(m.SenderGuid==id&&m.RecieverGuid == email)||(m.SenderGuid == email && m.RecieverGuid==id)).ToList();

            var messages = convertToDto(Messages);

            return messages;
        }

        private List<DirectMessageDto> convertToDto(List<DM> Messages) {
            var messages = new List<DirectMessageDto>();

            foreach (var message in Messages)
            {
                var messageDto = new DirectMessageDto()
                {
                    SenderGuid = message.SenderGuid,
                    Status = message.Status,
                    RecieverGuid = message.RecieverGuid,
                    Message = message.Message,
                    ModelGuid = message.ModelGUID,
                    Read = message.Read,
                    CreatedDateTimeString = message.CreatedDateTime,
                    CreatorId = message.CreatorId,
                    Path = message.Path,
                    IsDeleted = message.IsDeleted,
                    Id = message.Id,
                    GroupGuid = message.GroupGuid,
                    CreatedDateTime = Convert.ToDateTime(message.CreatedDateTime),
                    AttatchmentString = message.AttatchmentString
                };

                messages.Add(messageDto);
            }

            return messages;

        }

        public Task<List<DirectMessageDto>> Put(List<DirectMessageDto> model)
        {
            throw new NotImplementedException();
        }

        public async Task<DirectMessageDto> Put(string Id)
        {
            var DM = _context.Messages.Where(m => (m.SenderGuid == Id) || (m.RecieverGuid == Id) || (m.ModelGUID == Id)).FirstOrDefault();

            DM.Read = 1;
            var Read = _context.Entry(DM).Property("Read").IsModified;

            _context.SaveChanges();

            return new DirectMessageDto();
        }
    }
}

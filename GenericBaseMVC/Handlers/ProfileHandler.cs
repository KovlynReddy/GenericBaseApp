using AutoMapper;

namespace GenericBaseMVC.Handlers
{
    public class ProfileHandler
    {
        public VendorService _VendorService { get; set; }
        public CustomerService _customerService { get; set; }
        public AddressService _addressService { get; set; }
        public BookingService _bookingService { get; set; }
        public RelationshipService _relationshipService { get; set; }
        public IMapper Mapper { get; }

        public ProfileHandler(IMapper mapper)
        {
            _addressService = new AddressService();
            _customerService = new CustomerService();
            _VendorService = new VendorService();
            _bookingService = new BookingService();
            _relationshipService = new RelationshipService();
            Mapper = mapper;
        }

        public async Task<ViewListProfilesViewModel> GetAllProfiles(string email) {
            var currentUser = (await _customerService.Get(email)).FirstOrDefault();
            var result = new ViewListProfilesViewModel();
            var profiles = new List<ProfileViewModel>();
            var friendRequests = await _relationshipService.Get(currentUser.ModelGuid);
            var allProfiles = await _customerService.Get();
            //var customers = new List<CustomerViewModel>();

            foreach (var customer in allProfiles)
            {
                var relationship = friendRequests.FirstOrDefault(m=>m.SenderId == customer.ModelGuid || m.RecieverId == customer.ModelGuid);
                var customerVM = new CustomerViewModel()
                {
                    CustomerName = customer.CustomerName,
                    CustomerEmail = customer.CustomerEmail,
                    ModelGUID = customer.ModelGuid,
                    IsFriend = relationship != null ? relationship.Status : 99,
                    ProfileImagePath = customer.ProfileImagePath
                };

                //customers.Add(customerVM);
                profiles.Add(new ProfileViewModel()
                {
                    profileDetails = customerVM
                });

            }

            result.profiles = profiles;
            result.settings.SelectedTheme = currentUser.SelectedTheme;
            return result;
        }

        public async Task<List<ProfileViewModel>> Get() {

            return new List<ProfileViewModel>();
        }

        public async Task<RelationshipDto> RespondToFriendRequest(string id,int status)
        {
            var relationship = (await _relationshipService.Get(id)).FirstOrDefault();
            relationship.Status = status;
            relationship.DateReplied = DateTime.Now.ToString();
            relationship.CompletedDateTime = DateTime.Now.ToString();

            await _relationshipService.Put(relationship);

            return relationship;
        }   
        
        public async Task<CreateRelationshipDto> SendFriendRequest(string id,string email) {

            var recieverProfile = (await _customerService.Get(id)).FirstOrDefault();
            var senderProfile = (await _customerService.Get(email)).FirstOrDefault();

            var model = new CreateRelationshipDto()
            {
                SenderId = senderProfile.ModelGuid,
                RecieverId = recieverProfile.ModelGuid,
                CreatedDateTime = DateTime.Now.ToString(),
                CreatorId = email,
                Status = 1,
                ModelGUID = Guid.NewGuid().ToString(),
                DateSent = DateTime.Now.ToString(),
            };

            await _relationshipService.Post(model);

            return model;
        }        
        
        public async Task<List<ProfileViewModel>> Suggested(string id) {

            return new List<ProfileViewModel>();
        }
                
        public async Task<List<FriendRequestViewModel>> GetFriendRequests(string id) {

            return new List<FriendRequestViewModel>();
        }
                
        
        public async Task<ViewFriendRequestsViewModel> ViewFriendRequests(string email) {

            var currentUser = (await _customerService.Get(email)).FirstOrDefault();
            var friendRequests = await _relationshipService.Get(currentUser.ModelGuid);
            var userProfiles = new List<CustomerDto>();
            var model = new ViewFriendRequestsViewModel();

            foreach (var relationship in friendRequests)
            {
                string otherProfileId;
                if (relationship.SenderId == currentUser.ModelGuid)
                {
                    otherProfileId = relationship.RecieverId;
                }
                else
                {
                    otherProfileId = relationship.SenderId;
                }
                var otherUser = (await _customerService.Get(otherProfileId)).FirstOrDefault();
                userProfiles.Add(otherUser);

                model.users.Add(new FriendRequestViewModel()
                {
                    SenderGuid = relationship.SenderId,
                    ModelGUID = relationship.RecieverId,
                    RelationshipGuid = relationship.ModelGUID,
                    CustomerName = otherUser.CustomerName,
                    CustomerEmail = otherUser.CustomerEmail,
                    Status = relationship.Status,
                    ProfileImagePath = "",
                    CreatedDateTime = relationship.CreatedDateTime,                    
                });
            }

            model.settings.SelectedTheme = currentUser.SelectedTheme;

            return model;
        }

        public async Task<FriendRequestViewModel> GetFriendRequest(string id) {

            return new FriendRequestViewModel();
        }
    }
}

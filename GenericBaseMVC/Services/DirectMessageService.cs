using GenericAppDLL.Models.DomainModel;
using GenericAppDLL.Models.ViewModels;
using Humanizer;
using System.Net.Http;
using System.Text;

namespace GenericBaseMVC.Services;

public static class DirectMessageService
{
    public static async Task<List<DirectMessageDto>> Get(string Id,string email)
    {
        IEnumerable<DirectMessageDto> DirectMessages = null;


        //string apiUrl = $"https://localhost:7240/api/DirectMessage?id={Id}&email={email}";
        string apiUrl = $"https://localhost:7240/api/DirectMessage/{Id}/{email}";

        using (HttpClient client = new HttpClient())
        {
            client.BaseAddress = new Uri(apiUrl);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = await client.GetAsync(apiUrl);

            var apiresponse = new List<DirectMessageDto>();

            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsAsync<List<DirectMessageDto>>();
                //var table = Newtonsoft.Json.JsonConvert.DeserializeObject<System.Data.DataTable>(data);
                apiresponse = data;
                //Newtonsoft.Json.JsonConvert.DeserializeObject(data);
            }

            return apiresponse;
        }

    }    
    
    public static async Task<List<DirectMessageDto>> Get(string Id)
    {
        IEnumerable<DirectMessageDto> DirectMessages = null;


        string apiUrl = "https://localhost:7240/api/DirectMessage/" + Id;

        using (HttpClient client = new HttpClient())
        {
            client.BaseAddress = new Uri(apiUrl);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = await client.GetAsync(apiUrl);

            var apiresponse = new List<DirectMessageDto>();

            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsAsync<List<DirectMessageDto>>();
                //var table = Newtonsoft.Json.JsonConvert.DeserializeObject<System.Data.DataTable>(data);
                apiresponse = data;
                //Newtonsoft.Json.JsonConvert.DeserializeObject(data);
            }

            return apiresponse;
        }

    }

    public static async Task<List<DirectMessageDto>> Get()
    {
        IEnumerable<DirectMessageDto> DirectMessages = null;

        string apiUrl = "https://localhost:7240/api/DirectMessage";

        using (HttpClient client = new HttpClient())
        {
            client.BaseAddress = new Uri(apiUrl);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = await client.GetAsync(apiUrl);

            var apiresponse = new List<DirectMessageDto>();

            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsAsync<List<DirectMessageDto>>();
                //var table = Newtonsoft.Json.JsonConvert.DeserializeObject<System.Data.DataTable>(data);
                apiresponse = data;
                //Newtonsoft.Json.JsonConvert.DeserializeObject(data);
            }

            return apiresponse;
        }

    }

    public static async Task<List<DirectMessageDto>> Post(SendDirectMessageViewModel model)
    {
        var dto = new SendDirectMessageViewModel() {
            Message = model.Message,
            SenderGuid = model.SenderGuid,
            RecieverGuid = model.RecieverGuid,
        };

        IEnumerable<DirectMessageDto> DirectMessages = null;

        string apiUrl = "https://localhost:7240/api/DirectMessage";

        using (HttpClient client = new HttpClient())
        {
            client.BaseAddress = new Uri(apiUrl);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            var newEntityJson = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            var payload = new StringContent(newEntityJson, Encoding.UTF8, "application/json");

            HttpResponseMessage result = await client.PostAsync(apiUrl, payload);

            //result.EnsureSuccessStatusCode();

            var apiresponse = new List<DirectMessageDto>();

            if (result.IsSuccessStatusCode)
            {
                var data = await result.Content.ReadAsAsync<List<DirectMessageDto>>();
                //var table = Newtonsoft.Json.JsonConvert.DeserializeObject<System.Data.DataTable>(data);
                apiresponse = data;
            }

            return apiresponse;
        }

    }

    public static async Task<List<DirectMessage>> Delete()
    {
        IEnumerable<DirectMessage> DirectMessages = null;

        string apiUrl = "https://localhost:7240/api/DirectMessage";

        using (HttpClient client = new HttpClient())
        {
            client.BaseAddress = new Uri(apiUrl);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = await client.GetAsync(apiUrl);

            var apiresponse = new List<DirectMessage>();

            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsAsync<List<DirectMessage>>();
                //var table = Newtonsoft.Json.JsonConvert.DeserializeObject<System.Data.DataTable>(data);
                apiresponse = data;
                //Newtonsoft.Json.JsonConvert.DeserializeObject(data);
            }

            return apiresponse;
        }

    }

    public static async Task<List<DirectMessage>> Put(string messageId)
    {
        IEnumerable<DirectMessage> DirectMessages = null;
        var readMessage = new ReadMessageDto() { MessageGuid = messageId};

        string apiUrl = "https://localhost:7240/api/Read/DirectMessage" ;

        using (HttpClient client = new HttpClient())
        {
            client.BaseAddress = new Uri(apiUrl);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            var EntityJson = Newtonsoft.Json.JsonConvert.SerializeObject(readMessage);
            var payload = new StringContent(EntityJson, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await client.PutAsync(apiUrl, payload);

            var apiresponse = new List<DirectMessage>();
            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsAsync<List<DirectMessage>>();
                //var table = Newtonsoft.Json.JsonConvert.DeserializeObject<System.Data.DataTable>(data);
                apiresponse = data;
                //Newtonsoft.Json.JsonConvert.DeserializeObject(data);
            }

            return apiresponse;
        }

    }

}
    //private readonly string _baseUrl;
    //private readonly IAuthenticationManager _authenticationManager;

    //public BookingService(IOptions<SiteSettings> siteSettings, IAuthenticationManager authenticationManager)
    //{
    //    _authenticationManager = authenticationManager;
    //    _baseUrl = siteSettings.Value.URL;
    //}

    //public async Task<ApiResponse> Create(DirectMessageDto reservation)
    //{
    //    return await _baseUrl.WithHeader("X-TENANT-ID", _authenticationManager.GetTenant()).AppendPathSegment("/v1/Booking/").WithOAuthBearerToken(await _authenticationManager.GetToken()).PostJsonAsync(reservation).ReceiveJson<ApiResponse>();
    //}

    //public async Task<ApiResponse> Update(DirectMessageDto reservation)
    //{
    //    return await _baseUrl.WithHeader("X-TENANT-ID", _authenticationManager.GetTenant()).AppendPathSegment("/v1/Booking/").WithOAuthBearerToken(await _authenticationManager.GetToken()).PutJsonAsync(reservation).ReceiveJson<ApiResponse>();
    //}

    //public async Task<ApiResponse> UpdateOld(DirectMessageDto reservation)
    //{
    //    return await _baseUrl.WithHeader("X-TENANT-ID", _authenticationManager.GetTenant()).AppendPathSegment("/v1/Booking/").WithOAuthBearerToken(await _authenticationManager.GetToken()).PutJsonAsync(reservation).ReceiveJson<ApiResponse>();
    //}

    //public async Task<ApiResponse> Get(int id)
    //{
    //    return await _baseUrl.WithHeader("X-TENANT-ID", AppendPathSegments("/v1/Booking/").AppendPathSegment(id).WithOAuthBearerToken(await _authenticationManager.GetToken()).GetJsonAsync<ApiResponse>();
    //}


    //}
    //}



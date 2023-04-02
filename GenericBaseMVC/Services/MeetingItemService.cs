using ChilliSoftAssessmentMeetingMinuteTakerDLL.DomainModels;
using System.Text;

namespace GenericBaseMVC.Services;

public static class MeetingItemService
{
    public static async Task<List<Meeting>> Get()
    {
        IEnumerable<Meeting> meetings = null;


        string apiUrl = "https://localhost:7071/api/Meeting";

        using (HttpClient client = new HttpClient())
        {
            client.BaseAddress = new Uri(apiUrl);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = await client.GetAsync(apiUrl);

            var apiresponse = new List<Meeting>();

            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsAsync<List<Meeting>>();
                //var table = Newtonsoft.Json.JsonConvert.DeserializeObject<System.Data.DataTable>(data);
                apiresponse = data;
                //Newtonsoft.Json.JsonConvert.DeserializeObject(data);
            }

            return apiresponse;
        }

    }

    public static async Task<List<ItemStatus>> CreateStatus(ItemStatus dto)
    {


        IEnumerable<MeetingType> meetings = null;

        string apiUrl = "https://localhost:7071/api/MeetingItems/CreateStatus";

        using (HttpClient client = new HttpClient())
        {
            client.BaseAddress = new Uri(apiUrl);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            var newbarberJson = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            var payload = new StringContent(newbarberJson, Encoding.UTF8, "application/json");

            HttpResponseMessage result = await client.PostAsync(apiUrl, payload);

            //result.EnsureSuccessStatusCode();

            var apiresponse = new List<ItemStatus>();

            if (result.IsSuccessStatusCode)
            {
                var data = await result.Content.ReadAsAsync<List<ItemStatus>>();
                //var table = Newtonsoft.Json.JsonConvert.DeserializeObject<System.Data.DataTable>(data);
                apiresponse = data;
            }

            return apiresponse;
        }

    }

    public static async Task<List<ItemStatus>> GetAllStatuses()
    {
        IEnumerable<ItemStatus> meetings = null;


        string apiUrl = "https://localhost:7071/api/MeetingItems/GetAllItemStatuses";

        using (HttpClient client = new HttpClient())
        {
            client.BaseAddress = new Uri(apiUrl);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = await client.GetAsync(apiUrl);

            var apiresponse = new List<ItemStatus>();

            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsAsync<List<ItemStatus>>();
                //var table = Newtonsoft.Json.JsonConvert.DeserializeObject<System.Data.DataTable>(data);
                apiresponse = data;
                //Newtonsoft.Json.JsonConvert.DeserializeObject(data);
            }

            return apiresponse;
        }

    }



    public static async Task<List<ItemDto>> GetAll()
    {
        IEnumerable<ItemDto> meetings = null;


        string apiUrl = "https://localhost:7071/api/MeetingItems/GetAll";

        using (HttpClient client = new HttpClient())
        {
            client.BaseAddress = new Uri(apiUrl);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = await client.GetAsync(apiUrl);

            var apiresponse = new List<ItemDto>();

            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsAsync<List<ItemDto>>();
                //var table = Newtonsoft.Json.JsonConvert.DeserializeObject<System.Data.DataTable>(data);
                apiresponse = data;
                //Newtonsoft.Json.JsonConvert.DeserializeObject(data);
            }

            return apiresponse;
        }

    }

    public static async Task<List<CreateItemDto>> Create(CreateItemDto newBooking)
    {
        IEnumerable<CreateItemDto> meetings = null;

        string apiUrl = "https://localhost:7071/api/MeetingItems/Create";

        using (HttpClient client = new HttpClient())
        {
            client.BaseAddress = new Uri(apiUrl);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            var newbarberJson = Newtonsoft.Json.JsonConvert.SerializeObject(newBooking);
            var payload = new StringContent(newbarberJson, Encoding.UTF8, "application/json");

            HttpResponseMessage result = await client.PostAsync(apiUrl, payload);

            //result.EnsureSuccessStatusCode();

            var apiresponse = new List<CreateItemDto>();

            if (result.IsSuccessStatusCode)
            {
                var data = await result.Content.ReadAsAsync<List<CreateItemDto>>();
                //var table = Newtonsoft.Json.JsonConvert.DeserializeObject<System.Data.DataTable>(data);
                apiresponse = data;
            }

            return apiresponse;
        }

    }

    public static async Task<List<Meeting>> Cancel()
    {
        IEnumerable<Meeting> meetings = null;


        string apiUrl = "https://localhost:7071/api/Meeting";

        using (HttpClient client = new HttpClient())
        {
            client.BaseAddress = new Uri(apiUrl);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = await client.GetAsync(apiUrl);

            var apiresponse = new List<Meeting>();

            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsAsync<List<Meeting>>();
                //var table = Newtonsoft.Json.JsonConvert.DeserializeObject<System.Data.DataTable>(data);
                apiresponse = data;
                //Newtonsoft.Json.JsonConvert.DeserializeObject(data);
            }

            return apiresponse;
        }

    }

    public static async Task<List<CreateItemDto>> Update(CreateItemDto newBooking)
    {
        IEnumerable<CreateItemDto> meetings = null;

        string apiUrl = "https://localhost:7071/api/MeetingItems/Update";

        using (HttpClient client = new HttpClient())
        {
            client.BaseAddress = new Uri(apiUrl);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            var newbarberJson = Newtonsoft.Json.JsonConvert.SerializeObject(newBooking);
            var payload = new StringContent(newbarberJson, Encoding.UTF8, "application/json");

            HttpResponseMessage result = await client.PostAsync(apiUrl, payload);

            //result.EnsureSuccessStatusCode();

            var apiresponse = new List<CreateItemDto>();

            if (result.IsSuccessStatusCode)
            {
                var data = await result.Content.ReadAsAsync<List<CreateItemDto>>();
                //var table = Newtonsoft.Json.JsonConvert.DeserializeObject<System.Data.DataTable>(data);
                apiresponse = data;
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

//public async Task<ApiResponse> Create(MeetingDto reservation)
//{
//    return await _baseUrl.WithHeader("X-TENANT-ID", _authenticationManager.GetTenant()).AppendPathSegment("/v1/Booking/").WithOAuthBearerToken(await _authenticationManager.GetToken()).PostJsonAsync(reservation).ReceiveJson<ApiResponse>();
//}

//public async Task<ApiResponse> Update(MeetingDto reservation)
//{
//    return await _baseUrl.WithHeader("X-TENANT-ID", _authenticationManager.GetTenant()).AppendPathSegment("/v1/Booking/").WithOAuthBearerToken(await _authenticationManager.GetToken()).PutJsonAsync(reservation).ReceiveJson<ApiResponse>();
//}

//public async Task<ApiResponse> UpdateOld(MeetingDto reservation)
//{
//    return await _baseUrl.WithHeader("X-TENANT-ID", _authenticationManager.GetTenant()).AppendPathSegment("/v1/Booking/").WithOAuthBearerToken(await _authenticationManager.GetToken()).PutJsonAsync(reservation).ReceiveJson<ApiResponse>();
//}

//public async Task<ApiResponse> Get(int id)
//{
//    return await _baseUrl.WithHeader("X-TENANT-ID", AppendPathSegments("/v1/Booking/").AppendPathSegment(id).WithOAuthBearerToken(await _authenticationManager.GetToken()).GetJsonAsync<ApiResponse>();
//}


//}
//}



namespace GenericBaseMVC.Services;

public class VendorService
{
    public async Task<List<Vendor>> GetAll()
    {
        IEnumerable<Vendor> barbers = null;

        string apiUrl = "https://localhost:7240/api/Barbers/GetAll";

        using (HttpClient client = new HttpClient())
        {
            client.BaseAddress = new Uri(apiUrl);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = await client.GetAsync(apiUrl);

            var apiresponse = new List<Vendor>();

            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsAsync<List<Vendor>>();
                //var table = Newtonsoft.Json.JsonConvert.DeserializeObject<System.Data.DataTable>(data);
                apiresponse = data;
            }

            return apiresponse;
        }

    }

    public async Task<List<Vendor>> Search()
    {
        IEnumerable<Vendor> barbers = null;

        string apiUrl = "https://localhost:7240/api/Barbers";

        using (HttpClient client = new HttpClient())
        {
            client.BaseAddress = new Uri(apiUrl);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = await client.GetAsync(apiUrl);

            var apiresponse = new List<Vendor>();

            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsAsync<List<Vendor>>();
                //var table = Newtonsoft.Json.JsonConvert.DeserializeObject<System.Data.DataTable>(data);
                apiresponse = data;
            }

            return apiresponse;
        }

    }

    public async Task<List<Vendor>> Suggested()
    {
        IEnumerable<Vendor> barbers = new List<Vendor>();

        string apiUrl = "https://localhost:7240/api/Barbers";

        using (HttpClient client = new HttpClient())
        {
            client.BaseAddress = new Uri(apiUrl);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = await client.GetAsync(apiUrl);

            var apiresponse = new List<Vendor>();

            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsAsync<List<Vendor>>();
                //var table = Newtonsoft.Json.JsonConvert.DeserializeObject<System.Data.DataTable>(data);
                apiresponse = data;
            }

            return apiresponse;
        }

    }

    public async Task<List<Vendor>> SortBy()
    {
        IEnumerable<Vendor> barbers = null;

        string apiUrl = "https://localhost:7240/api/Barbers";

        using (HttpClient client = new HttpClient())
        {
            client.BaseAddress = new Uri(apiUrl);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = await client.GetAsync(apiUrl);

            var apiresponse = new List<Vendor>();

            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsAsync<List<Vendor>>();
                //var table = Newtonsoft.Json.JsonConvert.DeserializeObject<System.Data.DataTable>(data);
                apiresponse = data;
            }

            return apiresponse;
        }

    }   

    public async Task<List<CreateVendorDto>> Create(CreateVendorDto newbarber)
    {
        IEnumerable<CreateVendorDto> barbers = null;

        string apiUrl = "https://localhost:7240/api/Barbers/CreateDto";

        using (HttpClient client = new HttpClient())
        {
            client.BaseAddress = new Uri(apiUrl);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            var newbarberJson = Newtonsoft.Json.JsonConvert.SerializeObject(newbarber);
            var payload = new StringContent(newbarberJson, Encoding.UTF8, "application/json");

            HttpResponseMessage result = await client.PostAsync(apiUrl,payload);

            //result.EnsureSuccessStatusCode();

            var apiresponse = new List<CreateVendorDto>();

            if (result.IsSuccessStatusCode)
            {
                var data = await result.Content.ReadAsAsync<List<CreateVendorDto>>();
                //var table = Newtonsoft.Json.JsonConvert.DeserializeObject<System.Data.DataTable>(data);
                apiresponse = data;
            }

            return apiresponse;
        }

    }


    //private readonly string _baseUrl;
    //private readonly IAuthenticationManager _authenticationManager;

    //public BranchService(IOptions<SiteSettings> siteSettings)//, IAuthenticationManager authenticationManager)
    //{
    //    _baseUrl = siteSettings.Value.URL;
    //    //_authenticationManager = authenticationManager;
    //}

    //public async Task<ApiResponse<Barber>> Get(int id)
    //{
    //    var apiResponse = await _baseUrl
    //      .Append("/v1/Barber/Get")
    //      .PostJsonAsync(id)
    //      .ReceiveJson<ApiResponse<Barber>>();

    //    return apiResponse;
    //}
}

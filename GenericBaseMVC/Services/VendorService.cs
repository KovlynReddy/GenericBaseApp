namespace GenericBaseMVC.Services;

public class VendorService
{
    public async Task<List<Vendor>> GetAll()
    {
        IEnumerable<Vendor> Vendors = null;

        string apiUrl = "https://localhost:7240/api/Vendor/GetAll";

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
        IEnumerable<Vendor> Vendors = null;

        string apiUrl = "https://localhost:7240/api/Vendor";

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
        IEnumerable<Vendor> Vendors = new List<Vendor>();

        string apiUrl = "https://localhost:7240/api/Vendor";

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
        IEnumerable<Vendor> Vendors = null;

        string apiUrl = "https://localhost:7240/api/Vendor";

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

    public async Task<List<CreateVendorDto>> Create(CreateVendorDto newVendor)
    {
        IEnumerable<CreateVendorDto> Vendors = null;

        string apiUrl = "https://localhost:7240/api/Vendor";

        using (HttpClient client = new HttpClient())
        {
            client.BaseAddress = new Uri(apiUrl);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            var newVendorJson = Newtonsoft.Json.JsonConvert.SerializeObject(newVendor);
            var payload = new StringContent(newVendorJson, Encoding.UTF8, "application/json");

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

    //public async Task<ApiResponse<Vendor>> Get(int id)
    //{
    //    var apiResponse = await _baseUrl
    //      .Append("/v1/Vendor/Get")
    //      .PostJsonAsync(id)
    //      .ReceiveJson<ApiResponse<Vendor>>();

    //    return apiResponse;
    //}
}

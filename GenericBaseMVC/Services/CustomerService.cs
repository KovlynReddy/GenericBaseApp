namespace GenericBaseMVC.Services;

public class CustomerService
{

    public async Task<List<CustomerDto>> Get(string email)
    {
        IEnumerable<CustomerDto> Vendors = null;

        string apiUrl = "https://localhost:7240/api/Customers/" + email;

        using (HttpClient client = new HttpClient())
        {
            client.BaseAddress = new Uri(apiUrl);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = await client.GetAsync(apiUrl);

            var apiresponse = new List<CustomerDto>();

            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsAsync<List<CustomerDto>>();
                //var table = Newtonsoft.Json.JsonConvert.DeserializeObject<System.Data.DataTable>(data);
                apiresponse = data;
            }

            return apiresponse;
        }

    }    
    
    public async Task<List<CustomerDto>> Get(string email,int state)
    {
        IEnumerable<CustomerDto> Vendors = null;

        string apiUrl = "https://localhost:7240/api/Customers/" + email +"/"+state;

        using (HttpClient client = new HttpClient())
        {
            client.BaseAddress = new Uri(apiUrl);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = await client.GetAsync(apiUrl);

            var apiresponse = new List<CustomerDto>();

            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsAsync<List<CustomerDto>>();
                //var table = Newtonsoft.Json.JsonConvert.DeserializeObject<System.Data.DataTable>(data);
                apiresponse = data;
            }

            return apiresponse;
        }

    }

    public async Task<List<CustomerDto>> Get()
    {
        IEnumerable<CustomerDto> Vendors = null;

        string apiUrl = "https://localhost:7240/api/Customers";

        using (HttpClient client = new HttpClient())
        {
            client.BaseAddress = new Uri(apiUrl);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = await client.GetAsync(apiUrl);

            var apiresponse = new List<CustomerDto>();

            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsAsync<List<CustomerDto>>();
                //var table = Newtonsoft.Json.JsonConvert.DeserializeObject<System.Data.DataTable>(data);
                apiresponse = data;
            }

            return apiresponse;
        }

    }

    
    public async Task<CreateCustomerDto> Post(CreateCustomerDto newAddress)
    {
        CreateCustomerDto User = null;

        string apiUrl = "https://localhost:7240/api/Customers/CreateDto";

        using (HttpClient client = new HttpClient())
        {
            client.BaseAddress = new Uri(apiUrl);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            var newVendorJson = Newtonsoft.Json.JsonConvert.SerializeObject(newAddress);
            var payload = new StringContent(newVendorJson, Encoding.UTF8, "application/json");

            HttpResponseMessage result = await client.PostAsync(apiUrl, payload);

            //result.EnsureSuccessStatusCode();

            var apiresponse = new CreateCustomerDto();

            if (result.IsSuccessStatusCode)
            {
                var data = await result.Content.ReadAsAsync<CreateCustomerDto>();
                //var table = Newtonsoft.Json.JsonConvert.DeserializeObject<System.Data.DataTable>(data);
                apiresponse = data;
            }

            return apiresponse;
        }

    }

    public async Task<CustomerDto> Put(CustomerDto newAddress)
    {
        CustomerDto User = null;

        string apiUrl = "https://localhost:7240/api/Customers/UpdateTheme";

        using (HttpClient client = new HttpClient())
        {
            client.BaseAddress = new Uri(apiUrl);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            var newVendorJson = Newtonsoft.Json.JsonConvert.SerializeObject(newAddress);
            var payload = new StringContent(newVendorJson, Encoding.UTF8, "application/json");

            HttpResponseMessage result = await client.PutAsync(apiUrl, payload);

            //result.EnsureSuccessStatusCode();

            var apiresponse = new CustomerDto();

            if (result.IsSuccessStatusCode)
            {
                var data = await result.Content.ReadAsAsync<CustomerDto>();
                //var table = Newtonsoft.Json.JsonConvert.DeserializeObject<System.Data.DataTable>(data);
                apiresponse = data;
            }

            return apiresponse;
        }

    }


}

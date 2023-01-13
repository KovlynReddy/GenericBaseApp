namespace GenericBaseMVC.Services;

public class CustomerService
{

    public async Task<List<Customer>> Get()
    {
        IEnumerable<Customer> barbers = null;

        string apiUrl = "https://localhost:44337/api/Barbers";

        using (HttpClient client = new HttpClient())
        {
            client.BaseAddress = new Uri(apiUrl);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = await client.GetAsync(apiUrl);

            var apiresponse = new List<Customer>();

            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsAsync<List<Customer>>();
                //var table = Newtonsoft.Json.JsonConvert.DeserializeObject<System.Data.DataTable>(data);
                apiresponse = data;
            }

            return apiresponse;
        }

    }

    public async Task<List<CustomerDto>> GetAll()
    {
        IEnumerable<CustomerDto> barbers = null;

        string apiUrl = "https://localhost:7240/api/Customers/GetAll";

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

    
    public async Task<CreateCustomerDto> Create(CreateCustomerDto newAddress)
    {
        CreateCustomerDto User = null;

        string apiUrl = "https://localhost:7240/api/Customers/CreateDto";

        using (HttpClient client = new HttpClient())
        {
            client.BaseAddress = new Uri(apiUrl);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            var newbarberJson = Newtonsoft.Json.JsonConvert.SerializeObject(newAddress);
            var payload = new StringContent(newbarberJson, Encoding.UTF8, "application/json");

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


}

namespace GenericBaseMVC.Services
{
    public class CartService
    {
        public async Task<List<PurchaseItemDto>> Get(string id)
        {
            IEnumerable<PurchaseItemDto> Cart = null;


            string apiUrl = "https://localhost:7240/api/Shop/Item/" + id;

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync(apiUrl);

                var apiresponse = new List<PurchaseItemDto>();

                if (response.IsSuccessStatusCode)
                {
                    var data = await response.Content.ReadAsAsync<List<PurchaseItemDto>>();
                    //var table = Newtonsoft.Json.JsonConvert.DeserializeObject<System.Data.DataTable>(data);
                    apiresponse = data;
                    //Newtonsoft.Json.JsonConvert.DeserializeObject(data);
                }

                return apiresponse;
            }

        }

        public async Task<List<PurchaseDto>> Get(string id, string headers)
        {
            IEnumerable<PurchaseDto> Cart = null;


            //string apiUrl = "https://localhost:7240/api/Cart?id="+id+"&headers="+headers;
            string apiUrl = $"https://localhost:7240/api/Cart/{id}/{headers}";

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync(apiUrl);

                var apiresponse = new List<PurchaseDto>();

                if (response.IsSuccessStatusCode)
                {
                    var data = await response.Content.ReadAsAsync<List<PurchaseDto>>();
                    //var table = Newtonsoft.Json.JsonConvert.DeserializeObject<System.Data.DataTable>(data);
                    apiresponse = data;
                    //Newtonsoft.Json.JsonConvert.DeserializeObject(data);
                }

                return apiresponse;
            }

        }


        public async Task<PurchaseItemDto> Post(CreatePurchaseItemDto newCart)
        {
            IEnumerable<PurchaseItemDto> Carts = null;

            string apiUrl = "https://localhost:7240/api/Shop/Item";

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                var newVendorJson = Newtonsoft.Json.JsonConvert.SerializeObject(newCart);
                var payload = new StringContent(newVendorJson, Encoding.UTF8, "application/json");

                HttpResponseMessage result = await client.PostAsync(apiUrl, payload);

                //result.EnsureSuccessStatusCode();

                var apiresponse = new PurchaseItemDto();

                if (result.IsSuccessStatusCode)
                {
                    var data = await result.Content.ReadAsAsync<PurchaseItemDto>();
                    //var table = Newtonsoft.Json.JsonConvert.DeserializeObject<System.Data.DataTable>(data);
                    apiresponse = data;
                }

                return apiresponse;
            }

        }

        public async Task<PurchaseDto> Post(CreatePurchaseDto newCart)
        {
            IEnumerable<PurchaseDto> Carts = null;

            string apiUrl = "https://localhost:7240/api/Cart";

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                var newVendorJson = Newtonsoft.Json.JsonConvert.SerializeObject(newCart);
                var payload = new StringContent(newVendorJson, Encoding.UTF8, "application/json");

                HttpResponseMessage result = await client.PostAsync(apiUrl, payload);

                //result.EnsureSuccessStatusCode();

                var apiresponse = new PurchaseDto();

                if (result.IsSuccessStatusCode)
                {
                    var data = await result.Content.ReadAsAsync<PurchaseDto>();
                    //var table = Newtonsoft.Json.JsonConvert.DeserializeObject<System.Data.DataTable>(data);
                    apiresponse = data;
                }

                return apiresponse;
            }

        }

        public async Task<PurchaseDto> Put(string CartId)
        {
            IEnumerable<PurchaseDto> Carts = null;

            string apiUrl = "https://localhost:7240/api/Cart/"+CartId;

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                var newVendorJson = Newtonsoft.Json.JsonConvert.SerializeObject(CartId);
                var payload = new StringContent(newVendorJson, Encoding.UTF8, "application/json");

                HttpResponseMessage result = await client.PutAsync(apiUrl, payload);

                //result.EnsureSuccessStatusCode();

                var apiresponse = new PurchaseDto();

                if (result.IsSuccessStatusCode)
                {
                    var data = await result.Content.ReadAsAsync<PurchaseDto>();
                    //var table = Newtonsoft.Json.JsonConvert.DeserializeObject<System.Data.DataTable>(data);
                    apiresponse = data;
                }

                return apiresponse;
            }

        }


        public async Task<List<PurchaseItemDto>> Delete(PurchaseItemViewModel newCart)
        {
            IEnumerable<PurchaseItemDto> Carts = null;

            string apiUrl = "https://localhost:7240/api/Shop/Item";

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                var newVendorJson = Newtonsoft.Json.JsonConvert.SerializeObject(newCart);
                var payload = new StringContent(newVendorJson, Encoding.UTF8, "application/json");

                HttpResponseMessage result = await client.PostAsync(apiUrl, payload);

                //result.EnsureSuccessStatusCode();

                var apiresponse = new List<PurchaseItemDto>();

                if (result.IsSuccessStatusCode)
                {
                    var data = await result.Content.ReadAsAsync<List<PurchaseItemDto>>();
                    //var table = Newtonsoft.Json.JsonConvert.DeserializeObject<System.Data.DataTable>(data);
                    apiresponse = data;
                }

                return apiresponse;
            }

        }

        public async Task<List<PurchaseDto>> Delete(PurchaseViewModel newCart)
        {
            IEnumerable<PurchaseDto> Carts = null;

            string apiUrl = "https://localhost:7240/api/Cart";

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                var newVendorJson = Newtonsoft.Json.JsonConvert.SerializeObject(newCart);
                var payload = new StringContent(newVendorJson, Encoding.UTF8, "application/json");

                HttpResponseMessage result = await client.PostAsync(apiUrl, payload);

                //result.EnsureSuccessStatusCode();

                var apiresponse = new List<PurchaseDto>();

                if (result.IsSuccessStatusCode)
                {
                    var data = await result.Content.ReadAsAsync<List<PurchaseDto>>();
                    //var table = Newtonsoft.Json.JsonConvert.DeserializeObject<System.Data.DataTable>(data);
                    apiresponse = data;
                }

                return apiresponse;
            }

        }

    }
}

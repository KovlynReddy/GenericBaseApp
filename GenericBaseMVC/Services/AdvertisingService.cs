namespace GenericBaseMVC.Services
{
    public class AdvertisingService
    {
        public async Task<List<AdvertisingDto>> Get(string id)
        {
            IEnumerable<AdvertisingDto> Cart = null;

            string apiUrl = "https://localhost:7240/api/Advertisment/" + id;

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync(apiUrl);

                var apiresponse = new List<AdvertisingDto>();

                if (response.IsSuccessStatusCode)
                {
                    var data = await response.Content.ReadAsAsync<List<AdvertisingDto>>();
                    //var table = Newtonsoft.Json.JsonConvert.DeserializeObject<System.Data.DataTable>(data);
                    apiresponse = data;
                    //Newtonsoft.Json.JsonConvert.DeserializeObject(data);
                }

                return apiresponse;
            }

        }
        public async Task<AdvertisingDto> Post(AdvertisingDto model)
        {
            IEnumerable<AdvertisingDto> Carts = null;


            string apiUrl = "https://localhost:7240/api/advertisment/createdto";

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                var newObjectJson = Newtonsoft.Json.JsonConvert.SerializeObject(model);
                var payload = new StringContent(newObjectJson, Encoding.UTF8, "application/json");

                HttpResponseMessage result = await client.PostAsync(apiUrl, payload);

                //result.EnsureSuccessStatusCode();

                var apiresponse = new AdvertisingDto();

                if (result.IsSuccessStatusCode)
                {
                    var data = await result.Content.ReadAsAsync<AdvertisingDto>();
                    //var table = Newtonsoft.Json.JsonConvert.DeserializeObject<System.Data.DataTable>(data);
                    apiresponse = data;
                }

                return apiresponse;
            }

        }


    }
}

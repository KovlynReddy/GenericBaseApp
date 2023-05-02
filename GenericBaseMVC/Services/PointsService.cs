namespace GenericBaseMVC.Services
{
    public class PointsService
    {

        public async Task<List<PointsDto>> Get()
        {
            IEnumerable<PointsDto> Vendors = null;

            string apiUrl = "https://localhost:7240/api/Points";

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync(apiUrl);

                var apiresponse = new List<PointsDto>();

                if (response.IsSuccessStatusCode)
                {
                    var data = await response.Content.ReadAsAsync<List<PointsDto>>();
                    //var table = Newtonsoft.Json.JsonConvert.DeserializeObject<System.Data.DataTable>(data);
                    apiresponse = data;
                }

                return apiresponse;
            }

        }

        public async Task<List<PointsDto>> Get(string email)
        {
            IEnumerable<PointsDto> Vendors = null;

            string apiUrl = "https://localhost:7240/api/Points/" + email;

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync(apiUrl);

                var apiresponse = new List<PointsDto>();

                if (response.IsSuccessStatusCode)
                {
                    var data = await response.Content.ReadAsAsync<List<PointsDto>>();
                    //var table = Newtonsoft.Json.JsonConvert.DeserializeObject<System.Data.DataTable>(data);
                    apiresponse = data;
                }

                return apiresponse;
            }

        }

        public async Task<List<PointsDto>> Post(PointsDto sendInvite)
        {
            IEnumerable<PointsDto> Addresses = null;

            string apiUrl = "https://localhost:7240/api/Points";

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                var newVendorJson = Newtonsoft.Json.JsonConvert.SerializeObject(sendInvite);
                var payload = new StringContent(newVendorJson, Encoding.UTF8, "application/json");

                HttpResponseMessage result = await client.PostAsync(apiUrl, payload);

                //result.EnsureSuccessStatusCode();

                var apiresponse = new List<PointsDto>();

                if (result.IsSuccessStatusCode)
                {
                    var data = await result.Content.ReadAsAsync<List<PointsDto>>();
                    //var table = Newtonsoft.Json.JsonConvert.DeserializeObject<System.Data.DataTable>(data);
                    apiresponse = data;
                }

                return apiresponse;
            }

        }

        public async Task<PointsDto> Put(PointsDto response)
        {
            PointsDto Addresses = null;

            string apiUrl = "https://localhost:7240/api/Points";

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                var newVendorJson = Newtonsoft.Json.JsonConvert.SerializeObject(response);
                var payload = new StringContent(newVendorJson, Encoding.UTF8, "application/json");

                HttpResponseMessage result = await client.PutAsync(apiUrl, payload);

                //result.EnsureSuccessStatusCode();

                var apiresponse = new PointsDto();

                if (result.IsSuccessStatusCode)
                {
                    var data = await result.Content.ReadAsAsync<PointsDto>();
                    //var table = Newtonsoft.Json.JsonConvert.DeserializeObject<System.Data.DataTable>(data);
                    apiresponse = data;
                }

                return apiresponse;
            }

        }


    }
}

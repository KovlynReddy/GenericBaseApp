namespace GenericBaseMVC.Services
{
    public class JournalService
    {

        public async Task<List<JournalEntryDto>> Get()
        {
            IEnumerable<JournalEntryDto> Vendors = null;

            string apiUrl = "https://localhost:7240/api/Journal";

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync(apiUrl);

                var apiresponse = new List<JournalEntryDto>();

                if (response.IsSuccessStatusCode)
                {
                    var data = await response.Content.ReadAsAsync<List<JournalEntryDto>>();
                    //var table = Newtonsoft.Json.JsonConvert.DeserializeObject<System.Data.DataTable>(data);
                    apiresponse = data;
                }

                return apiresponse;
            }

        }

        public async Task<List<JournalEntryDto>> Get(string email)
        {
            IEnumerable<JournalEntryDto> Vendors = null;

            string apiUrl = "https://localhost:7240/api/Journal";

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync(apiUrl);

                var apiresponse = new List<JournalEntryDto>();

                if (response.IsSuccessStatusCode)
                {
                    var data = await response.Content.ReadAsAsync<List<JournalEntryDto>>();
                    //var table = Newtonsoft.Json.JsonConvert.DeserializeObject<System.Data.DataTable>(data);
                    apiresponse = data;
                }

                return apiresponse;
            }

        }

        public async Task<List<JournalEntryDto>> Post(JournalEntryDto sendInvite)
        {
            IEnumerable<JournalEntryDto> Addresses = null;

            string apiUrl = "https://localhost:7240/api/Journal";

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                var newVendorJson = Newtonsoft.Json.JsonConvert.SerializeObject(sendInvite);
                var payload = new StringContent(newVendorJson, Encoding.UTF8, "application/json");

                HttpResponseMessage result = await client.PostAsync(apiUrl, payload);

                //result.EnsureSuccessStatusCode();

                var apiresponse = new List<JournalEntryDto>();

                if (result.IsSuccessStatusCode)
                {
                    var data = await result.Content.ReadAsAsync<List<JournalEntryDto>>();
                    //var table = Newtonsoft.Json.JsonConvert.DeserializeObject<System.Data.DataTable>(data);
                    apiresponse = data;
                }

                return apiresponse;
            }

        }

        public async Task<JournalEntryDto> Put(JournalEntryDto response)
        {
            MeetUpDto Addresses = null;

            string apiUrl = "https://localhost:7240/api/Journal";

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                var newVendorJson = Newtonsoft.Json.JsonConvert.SerializeObject(response);
                var payload = new StringContent(newVendorJson, Encoding.UTF8, "application/json");

                HttpResponseMessage result = await client.PutAsync(apiUrl, payload);

                //result.EnsureSuccessStatusCode();

                var apiresponse = new JournalEntryDto();

                if (result.IsSuccessStatusCode)
                {
                    var data = await result.Content.ReadAsAsync<JournalEntryDto>();
                    //var table = Newtonsoft.Json.JsonConvert.DeserializeObject<System.Data.DataTable>(data);
                    apiresponse = data;
                }

                return apiresponse;
            }

        }


    }
}

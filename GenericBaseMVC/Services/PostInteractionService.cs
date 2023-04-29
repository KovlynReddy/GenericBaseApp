namespace GenericBaseMVC.Services
{
    public class PostInteractionService
    {
        public async Task<List<PostInteractionDto>> Get()
        {
            IEnumerable<PostInteractionDto> Vendors = null;

            string apiUrl = "https://localhost:7240/api/PostInteraction";

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync(apiUrl);

                var apiresponse = new List<PostInteractionDto>();

                if (response.IsSuccessStatusCode)
                {
                    var data = await response.Content.ReadAsAsync<List<PostInteractionDto>>();
                    //var table = Newtonsoft.Json.JsonConvert.DeserializeObject<System.Data.DataTable>(data);
                    apiresponse = data;
                }

                return apiresponse;
            }

        }

        public async Task<List<PostInteractionDto>> Get(string email)
        {
            IEnumerable<PostInteractionDto> Vendors = null;

            string apiUrl = "https://localhost:7240/api/PostInteraction/"+email;

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync(apiUrl);

                var apiresponse = new List<PostInteractionDto>();

                if (response.IsSuccessStatusCode)
                {
                    var data = await response.Content.ReadAsAsync<List<PostInteractionDto>>();
                    //var table = Newtonsoft.Json.JsonConvert.DeserializeObject<System.Data.DataTable>(data);
                    apiresponse = data;
                }

                return apiresponse;
            }

        }

        public async Task<List<PostInteractionDto>> Create(CreatePostInteractionDto sendInvite)
        {
            IEnumerable<PostInteractionDto> Addresses = null;

            string apiUrl = "https://localhost:7240/api/PostInteraction";

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                var newVendorJson = Newtonsoft.Json.JsonConvert.SerializeObject(sendInvite);
                var payload = new StringContent(newVendorJson, Encoding.UTF8, "application/json");

                HttpResponseMessage result = await client.PostAsync(apiUrl, payload);

                //result.EnsureSuccessStatusCode();

                var apiresponse = new List<PostInteractionDto>();

                if (result.IsSuccessStatusCode)
                {
                    var data = await result.Content.ReadAsAsync<List<PostInteractionDto>>();
                    //var table = Newtonsoft.Json.JsonConvert.DeserializeObject<System.Data.DataTable>(data);
                    apiresponse = data;
                }

                return apiresponse;
            }

        }

        public async Task<PostInteractionDto> Put(PostInteractionDto response)
        {
            PostInteractionDto Addresses = null;

            string apiUrl = "https://localhost:7240/api/PostInteraction";

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                var newVendorJson = Newtonsoft.Json.JsonConvert.SerializeObject(response);
                var payload = new StringContent(newVendorJson, Encoding.UTF8, "application/json");

                HttpResponseMessage result = await client.PutAsync(apiUrl, payload);

                //result.EnsureSuccessStatusCode();

                var apiresponse = new PostInteractionDto();

                if (result.IsSuccessStatusCode)
                {
                    var data = await result.Content.ReadAsAsync<PostInteractionDto>();
                    //var table = Newtonsoft.Json.JsonConvert.DeserializeObject<System.Data.DataTable>(data);
                    apiresponse = data;
                }

                return apiresponse;
            }

        }

    }
}

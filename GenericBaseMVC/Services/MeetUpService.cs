namespace GenericBaseMVC.Services;

public class MeetUpService
{
    public async Task<List<MeetUpDto>> Get()
    {
        IEnumerable<MeetUpDto> Vendors = null;

        string apiUrl = "https://localhost:7240/api/MeetUp";

        using (HttpClient client = new HttpClient())
        {
            client.BaseAddress = new Uri(apiUrl);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = await client.GetAsync(apiUrl);

            var apiresponse = new List<MeetUpDto>();

            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsAsync<List<MeetUpDto>>();
                //var table = Newtonsoft.Json.JsonConvert.DeserializeObject<System.Data.DataTable>(data);
                apiresponse = data;
            }

            return apiresponse;
        }

    }

    public async Task<List<MeetUpDto>> Get(string id)
    {
        IEnumerable<MeetUpDto> addresses = null;

        string apiUrl = "https://localhost:7240/api/MeetUp/"+id;

        using (HttpClient client = new HttpClient())
        {
            client.BaseAddress = new Uri(apiUrl);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = await client.GetAsync(apiUrl);

            var apiresponse = new List<MeetUpDto>();

            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsAsync<List<MeetUpDto>>();
                //var table = Newtonsoft.Json.JsonConvert.DeserializeObject<System.Data.DataTable>(data);
                apiresponse = data;
            }

            return apiresponse;
        }

    }

    public async Task<CreateMeetUpDto> Create(CreateMeetUpDto sendInvite)
    {
        CreateMeetUpDto Addresses = null;

        string apiUrl = "https://localhost:7240/api/MeetUp";

        using (HttpClient client = new HttpClient())
        {
            client.BaseAddress = new Uri(apiUrl);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            var newVendorJson = Newtonsoft.Json.JsonConvert.SerializeObject(sendInvite);
            var payload = new StringContent(newVendorJson, Encoding.UTF8, "application/json");

            HttpResponseMessage result = await client.PostAsync(apiUrl, payload);

            //result.EnsureSuccessStatusCode();

            var apiresponse = new CreateMeetUpDto();

            if (result.IsSuccessStatusCode)
            {
                var data = await result.Content.ReadAsAsync<CreateMeetUpDto>();
                //var table = Newtonsoft.Json.JsonConvert.DeserializeObject<System.Data.DataTable>(data);
                apiresponse = data;
            }

            return apiresponse;
        }

    }

    public async Task<MeetUpDto> Respond(MeetupResponseDto response)
    {
        MeetUpDto Addresses = null;

        string apiUrl = "https://localhost:7240/api/MeetUp";

        using (HttpClient client = new HttpClient())
        {
            client.BaseAddress = new Uri(apiUrl);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            var newVendorJson = Newtonsoft.Json.JsonConvert.SerializeObject(response);
            var payload = new StringContent(newVendorJson, Encoding.UTF8, "application/json");

            HttpResponseMessage result = await client.PutAsync(apiUrl, payload);

            //result.EnsureSuccessStatusCode();

            var apiresponse = new MeetUpDto();

            if (result.IsSuccessStatusCode)
            {
                var data = await result.Content.ReadAsAsync<MeetUpDto>();
                //var table = Newtonsoft.Json.JsonConvert.DeserializeObject<System.Data.DataTable>(data);
                apiresponse = data;
            }

            return apiresponse;
        }

    }


}

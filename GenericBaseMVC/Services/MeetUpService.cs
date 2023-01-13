namespace GenericBaseMVC.Services;

public class MeetUpService
{
    public async Task<List<MeetUpDto>> Get()
    {
        IEnumerable<MeetUpDto> barbers = null;

        string apiUrl = "https://localhost:44337/api/MeetUp";

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

    public async Task<List<MeetUpDto>> GetAll()
    {
        IEnumerable<MeetUpDto> addresses = null;

        string apiUrl = "https://localhost:44337/api/MeetUp/GetAll";

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

    public async Task<List<CreateMeetUpDto>> Create(CreateMeetUpDto sendInvite)
    {
        IEnumerable<CreateMeetUpDto> Addresses = null;

        string apiUrl = "https://localhost:44337/api/MeetUp/CreateDto";

        using (HttpClient client = new HttpClient())
        {
            client.BaseAddress = new Uri(apiUrl);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            var newbarberJson = Newtonsoft.Json.JsonConvert.SerializeObject(sendInvite);
            var payload = new StringContent(newbarberJson, Encoding.UTF8, "application/json");

            HttpResponseMessage result = await client.PostAsync(apiUrl, payload);

            //result.EnsureSuccessStatusCode();

            var apiresponse = new List<CreateMeetUpDto>();

            if (result.IsSuccessStatusCode)
            {
                var data = await result.Content.ReadAsAsync<List<CreateMeetUpDto>>();
                //var table = Newtonsoft.Json.JsonConvert.DeserializeObject<System.Data.DataTable>(data);
                apiresponse = data;
            }

            return apiresponse;
        }

    }

    public async Task<MeetUpDto> Respond(CreateMeetUpDto sendInvite)
    {
        MeetUpDto Addresses = null;

        string apiUrl = "https://localhost:44337/api/MeetUp/CreateDto";

        using (HttpClient client = new HttpClient())
        {
            client.BaseAddress = new Uri(apiUrl);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            var newbarberJson = Newtonsoft.Json.JsonConvert.SerializeObject(sendInvite);
            var payload = new StringContent(newbarberJson, Encoding.UTF8, "application/json");

            HttpResponseMessage result = await client.PostAsync(apiUrl, payload);

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

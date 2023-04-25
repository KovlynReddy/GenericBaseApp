﻿namespace GenericBaseMVC.Services
{
    public class MeetupRequestService
    {
        public async Task<List<MeetupRequestDto>> Get()
        {
            IEnumerable<MeetupRequestDto> Vendors = null;

            string apiUrl = "https://localhost:7240/api/MeetUpRequest";

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync(apiUrl);

                var apiresponse = new List<MeetupRequestDto>();

                if (response.IsSuccessStatusCode)
                {
                    var data = await response.Content.ReadAsAsync<List<MeetupRequestDto>>();
                    //var table = Newtonsoft.Json.JsonConvert.DeserializeObject<System.Data.DataTable>(data);
                    apiresponse = data;
                }

                return apiresponse;
            }

        }
        
        public async Task<List<MeetupRequestDto>> Get(string email)
        {
            IEnumerable<MeetupRequestDto> Vendors = null;

            string apiUrl = "https://localhost:7240/api/MeetUpRequest";

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync(apiUrl);

                var apiresponse = new List<MeetupRequestDto>();

                if (response.IsSuccessStatusCode)
                {
                    var data = await response.Content.ReadAsAsync<List<MeetupRequestDto>>();
                    //var table = Newtonsoft.Json.JsonConvert.DeserializeObject<System.Data.DataTable>(data);
                    apiresponse = data;
                }

                return apiresponse;
            }

        }

        public async Task<List<MeetupRequestDto>> Post(CreateMeetupRequestDto sendInvite)
        {
            IEnumerable<MeetupRequestDto> Addresses = null;

            string apiUrl = "https://localhost:7240/api/MeetUpRequest";

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                var newVendorJson = Newtonsoft.Json.JsonConvert.SerializeObject(sendInvite);
                var payload = new StringContent(newVendorJson, Encoding.UTF8, "application/json");

                HttpResponseMessage result = await client.PostAsync(apiUrl, payload);

                //result.EnsureSuccessStatusCode();

                var apiresponse = new List<MeetupRequestDto>();

                if (result.IsSuccessStatusCode)
                {
                    var data = await result.Content.ReadAsAsync<List<MeetupRequestDto>>();
                    //var table = Newtonsoft.Json.JsonConvert.DeserializeObject<System.Data.DataTable>(data);
                    apiresponse = data;
                }

                return apiresponse;
            }

        }

        public async Task<MeetupRequestDto> Put(MeetupRequestDto response)
        {
            MeetUpDto Addresses = null;

            string apiUrl = "https://localhost:7240/api/MeetUpRequest";

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                var newVendorJson = Newtonsoft.Json.JsonConvert.SerializeObject(response);
                var payload = new StringContent(newVendorJson, Encoding.UTF8, "application/json");

                HttpResponseMessage result = await client.PutAsync(apiUrl, payload);

                //result.EnsureSuccessStatusCode();

                var apiresponse = new MeetupRequestDto();

                if (result.IsSuccessStatusCode)
                {
                    var data = await result.Content.ReadAsAsync<MeetupRequestDto>();
                    //var table = Newtonsoft.Json.JsonConvert.DeserializeObject<System.Data.DataTable>(data);
                    apiresponse = data;
                }

                return apiresponse;
            }

        }

    }
}

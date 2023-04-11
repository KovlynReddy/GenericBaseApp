namespace GenericBaseMVC.Services;

public class VisitService
{
    //public VendorContext _Db { get; set; }

    //public VisitService(VendorContext DB)
    //{
    //    _Db = DB;
    //}

    public async Task<List<LogVisit>> Get()
    {
        IEnumerable<LogVisit> bookings = null;


        string apiUrl = "https://localhost:7240/api/Vendors";

        using (HttpClient client = new HttpClient())
        {
            client.BaseAddress = new Uri(apiUrl);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = await client.GetAsync(apiUrl);

            var apiresponse = new List<LogVisit>();

            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsAsync<List<LogVisit>>();
                //var table = Newtonsoft.Json.JsonConvert.DeserializeObject<System.Data.DataTable>(data);
                apiresponse = data;
                //Newtonsoft.Json.JsonConvert.DeserializeObject(data);
            }              

            return apiresponse;
        }

    }
}


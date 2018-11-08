using System.Net.Http;
using System.Windows;

namespace MyWpfApp.src
{
    class HttpClientSample
    {
        private const string localhost = "http://localhost:5000";//64411";

        public HttpClientSample() {

            string values;
            using (var client = new HttpClient())
            {
                var response = client.GetAsync(localhost + "/api/todos").Result;
                values = response.Content.ReadAsStringAsync().Result;
            }

            MessageBox.Show(values);
        }
    }
}

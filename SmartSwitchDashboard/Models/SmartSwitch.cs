using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace SmartSwitchDashboard.Models
{
    public class SmartSwitch
    {
        public string Id { get; set; }
        public string RelayOneClosed { get; set; }
        public string RelayTwoClosed { get; set; }
        public DateTime LastSeen { get; set; }
    
        public async Task ToggleRelayOne()
        {
            await SendCommand("toggleR1");
        }

        public async Task ToggleRelayTwo()
        {
            await SendCommand("toggleR2");
        }

        private const string ACCESS_TOKEN = "21fcad7d452e3ea45aedf415941d64f81e376b2c";
        public async Task SendCommand(string command)
        {
            try
            {
                using (var client = new HttpClient())
                {

                    client.BaseAddress = new Uri("https://api.particle.io/v1/devices/" + Id + "/" + command + "/");
                    var content = new FormUrlEncodedContent(new[]
                    {
                    new KeyValuePair<string, string>("access_token", ACCESS_TOKEN),
                    new KeyValuePair<string, string>("args", "255,255,255,255")
                });
                    HttpResponseMessage mes = await client.PostAsync("", content);

                    var result = mes.Content.ReadAsStringAsync().Result;


                }
            }
            catch (Exception ex)
            {

                Debug.WriteLine("EXCEPTION SendCommand: " + ex.ToString());
            }

        }
    }
}

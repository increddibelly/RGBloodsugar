using LedScout.Control;
using LedScout.Model;
using System;
using System.Net;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;
using System.Diagnostics;

namespace NightscoutClient
{
    public class NightscoutBloodSugarProvider : IBloodSugarProvider
    {
        private readonly string _uri;

        public NightscoutBloodSugarProvider(string baseUri)
        {
            _uri = (baseUri + "/api/v1/entries/current.json").Replace("//api", "/api");
        }

        public void Dispose()
        {
        }

        public BloodSugarEvent Get()
        {
            var client = WebRequest.Create(_uri);
            try
            {
                var stream = client.GetResponse().GetResponseStream();
                using (var reader = new StreamReader(stream, Encoding.UTF8))
                {
                    var nightscoutEntry = reader.ReadToEnd();

                    var items = JsonConvert.DeserializeObject<NightScoutBloodSugarEvent[]>(nightscoutEntry);
                    var parsed = items?.OrderByDescending(x => x.date).FirstOrDefault();

                    return Map(parsed);
                }
            } 
#pragma warning disable CS0168 // Variable is declared but never used
#pragma warning disable IDE0059 // Value assigned to symbol is never used
            catch (Exception ex)
            {
                // fail quietly, a low priority process such as this should be visible to the user in any way
                // todo logging 
                Debugger.Break();
            }
#pragma warning restore IDE0059 // Value assigned to symbol is never used
#pragma warning restore CS0168 // Variable is declared but never used
            return null;
        }

        private BloodSugarEvent Map(NightScoutBloodSugarEvent result)
        {
            var directionMap = new Dictionary<string, BloodSugarDirection>
            {
                { "DoubleDown", BloodSugarDirection.DroppingFast },
                { "FortyFiveDown", BloodSugarDirection.Dropping},
                { "Flat", BloodSugarDirection.Flat },
                { "FortyFiveUp", BloodSugarDirection.Rising},
                { "DoubleUp", BloodSugarDirection.RisingFast }
            };

            return new BloodSugarEvent
            {
                BloodSugarLevel = decimal.Round(result.sgv/18m, 1, MidpointRounding.AwayFromZero),
                Direction = directionMap[result.direction],
                Timestamp = DateTime.Parse(result.dateString)            
            };
        }

        public void Init()
        {
        }
    }
}

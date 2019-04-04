using Newtonsoft.Json;

namespace NightscoutClient
{
#pragma warning disable IDE1006 // Naming Styles
    [JsonObject]
    public class NightScoutBloodSugarEvent
    {
        /*
        [{"_id":"5ca5c68e90a7aee2c16676ef",
          "device":"xDrip-DexcomG5 G5 Native",
          "date":1554368138331,
          "dateString":
          "2019-04-04T10:55:38.331+0200",
          "sgv":217,
          "delta":0,
          "direction":"Flat",
          "type":"sgv",
          "filtered":211296,
          "unfiltered":211520,
          "rssi":100,
          "noise":1,
          "sysTime":"2019-04-04T10:55:38.331+0200"}]
          */

        public string _id {get;set; }
        public string device {get;set;}
        public long date {get;set;}
        public string dateString {get;set;}
        public int sgv {get;set;}
        public decimal delta {get;set;}
        public string direction {get;set;}
        public string type {get;set;}
        public int filtered {get;set;}
        public int unfiltered {get;set;}
        public int rssi {get;set;}
        public int noise {get;set;}
        public string sysTime {get;set;}
    }

    public class NightScoutBloodSugarEventList
    {
        public NightScoutBloodSugarEvent[] entries {get;set;}
    }
#pragma warning restore IDE1006 // Naming Styles
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;
using System.Threading;
using ExSharpBase.Modules;
using ExSharpBase.Enums;

namespace ExSharpBase.API
{
    class Service
    {
        private const double cache_timeout = 500.0;

        public static JObject GetActivePlayerData_realtime()
        {
            if (IsLiveGameRunning())
            {
                HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create("https://127.0.0.1:2999/liveclientdata/activeplayer");

                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                using (Stream stream = response.GetResponseStream())
                using (StreamReader reader = new StreamReader(stream))
                {
                    try { return JObject.Parse(reader.ReadToEnd()); }
                    catch (Exception)
                    {
                        LogService.Log("PlayerDataParseFailedException", LogLevel.Error);
                        throw new Exception("PlayerDataParseFailedException");
                    }
                }
            }
            else
            {
                LogService.Log("PlayerDataParseFailedException", LogLevel.Error);
                throw new Exception("PlayerDataParseFailedException");
            }
        }

        private static JObject GetActivePlayerData_cache;
        private static DateTime GetActivePlayerData_cache_timestamp;

        public static JObject GetActivePlayerData() {
            if (DateTime.UtcNow - GetActivePlayerData_cache_timestamp > TimeSpan.FromMilliseconds(cache_timeout)) {
                GetActivePlayerData_cache_timestamp = DateTime.UtcNow;
                GetActivePlayerData_cache = GetActivePlayerData_realtime();
            }

            return GetActivePlayerData_cache;
        }

        public static JArray GetAllPlayerData_realtime()
        {
            if (IsLiveGameRunning())
            {
                HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create("https://127.0.0.1:2999/liveclientdata/playerlist");

                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                using (Stream stream = response.GetResponseStream())
                using (StreamReader reader = new StreamReader(stream))
                {
                    try { return JArray.Parse(reader.ReadToEnd()); }
                    catch (Exception)
                    {
                        LogService.Log("AllPlayerDataParseFailedException", LogLevel.Error);
                        throw new Exception("AllPlayerDataParseFailedException");
                    }
                }
            }
            else
            {
                LogService.Log("AllPlayerDataParseFailedException", LogLevel.Error);
                throw new Exception("AllPlayerDataParseFailedException");
            }
        }

        private static JArray GetAllPlayerData_cache;
        private static DateTime GetAllPlayerData_cache_timestamp;

        public static JArray GetAllPlayerData() {
            if(DateTime.UtcNow - GetAllPlayerData_cache_timestamp > TimeSpan.FromMilliseconds(cache_timeout)) {
                GetAllPlayerData_cache_timestamp = DateTime.UtcNow;
                GetAllPlayerData_cache = GetAllPlayerData_realtime();
            }

            return GetAllPlayerData_cache;
        }

        public static JObject GetGameStatsData_realtime()
        {
            if (IsLiveGameRunning())
            {
                HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create("https://127.0.0.1:2999/liveclientdata/gamestats");

                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                using (Stream stream = response.GetResponseStream())
                using (StreamReader reader = new StreamReader(stream))
                {
                    try { return JObject.Parse(reader.ReadToEnd()); }
                    catch (Exception)
                    {
                        Console.WriteLine("GameDataParseFailedException");
                        throw new Exception("GameDataParseFailedException");
                    }
                }
            }
            else
            {
                Console.WriteLine("GameDataParseFailedException");
                throw new Exception("GameDataParseFailedException");
            }
        }

        private static JObject GetGameStatsData_cache;
        private static DateTime GetGameStatsData_cache_timestamp;

        public static JObject GetGameStatsData() {
            if(DateTime.UtcNow - GetGameStatsData_cache_timestamp > TimeSpan.FromMilliseconds(cache_timeout)) {
                GetGameStatsData_cache_timestamp = DateTime.UtcNow;
                GetGameStatsData_cache = GetGameStatsData_realtime();
            }

            return GetGameStatsData_cache;
        }

        public static bool IsLiveGameRunning_realtime()
        {
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create("https://127.0.0.1:2999/liveclientdata/allgamedata");
            System.Net.ServicePointManager.ServerCertificateValidationCallback += delegate (object sender, System.Security.Cryptography.X509Certificates.X509Certificate certificate,
                        System.Security.Cryptography.X509Certificates.X509Chain chain,
                        System.Net.Security.SslPolicyErrors sslPolicyErrors)
            {
                return true; // **** Always accept
            };

            request.Method = "GET";

            bool flag = false;

            try
            {
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    if (response.StatusCode == HttpStatusCode.OK) flag = true;
                }
            }
            catch (Exception)
            {
                LogService.Log($"Failed To Connect To A Running Game Instance. Exiting In 10 Seconds...", LogLevel.Error);
                Thread.Sleep(10000);
                Environment.Exit(0);
            }

            return flag;
        }

        private static bool IsLiveGameRunning_cache;
        private static DateTime IsLiveGameRunning_cache_timestamp;

        public static bool IsLiveGameRunning() {
            if(DateTime.UtcNow - IsLiveGameRunning_cache_timestamp > TimeSpan.FromMilliseconds(cache_timeout)) {
                IsLiveGameRunning_cache_timestamp = DateTime.UtcNow;
                IsLiveGameRunning_cache = IsLiveGameRunning_realtime();
            }

            return IsLiveGameRunning_cache;
        }
    }
}

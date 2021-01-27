using System;
using System.Collections.Generic;
using ExSharpBase.API.Models;

namespace ExSharpBase.API
{
    public class AllPlayerData
    {
        public static IList<PlayerData> AllPlayers { get { return GetAllPlayers(); } }
        public static PlayerData FirstPlayer { get { return GetPlayerData(0); } }
        public static PlayerData SecondPlayer { get { return GetPlayerData(1); } }
        public static PlayerData ThirdPlayer { get { return GetPlayerData(2); } }
        public static PlayerData FourthPlayer { get { return GetPlayerData(3); } }
        public static PlayerData FifthPlayer { get { return GetPlayerData(4); } }
        public static PlayerData SixthPlayer { get { return GetPlayerData(5); } }
        public static PlayerData SeventhPlayer { get { return GetPlayerData(6); } }
        public static PlayerData EighthPlayer { get { return GetPlayerData(7); } }
        public static PlayerData NinthPlayer { get { return GetPlayerData(8); } }
        public static PlayerData TenthPlayer { get { return GetPlayerData(9); } }
        public static PlayerData EleventhPlayer { get { return GetPlayerData(10); } }
        public static PlayerData TwelfthPlayer { get { return GetPlayerData(11); } }

        private static PlayerData GetPlayerData(int PlayerId)
        {
            var AllPlayerData = GetAllPlayers();
            if (AllPlayerData.Count <= PlayerId)
            {
                throw new IndexOutOfRangeException($"player: {PlayerId} is not available");
            }
            var PlayerData = AllPlayerData[PlayerId];
            return PlayerData;
        }

        private static IList<PlayerData> GetAllPlayers()
        {
            IList<PlayerData> allPlayersList = new List<PlayerData>();
            foreach (var playerData in Service.GetAllPlayerData())
            {
                PlayerData playerToAdd = new PlayerData()
                {
                    ChampionName = playerData["championName"].ToString(),
                    IsBot = playerData["isBot"].ToObject<bool>(),
                    IsDead = playerData["isDead"].ToObject<bool>(),
                    Level = playerData["level"].ToObject<int>(),
                    RolePosition = playerData["position"].ToString(),
                    RawChampionName = playerData["rawChampionName"].ToString(),
                    RespawnTimer = playerData["respawnTimer"].ToObject<float>(),
                    SkinID = playerData["skinID"].ToObject<int>(),
                    SummonerName = playerData["summonerName"].ToString(),
                    Team = playerData["team"].ToString()
                };
                allPlayersList.Add(playerToAdd);
            }
            return allPlayersList;
        }
    }
}

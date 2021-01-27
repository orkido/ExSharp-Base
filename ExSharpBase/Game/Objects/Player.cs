using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExSharpBase.Modules;
using SharpDX;
using Newtonsoft.Json.Linq;
using System.Diagnostics;

namespace ExSharpBase.Game.Objects
{
    class Player : GameObject
    {
        private int nativeId;
        private int apiId;
        private bool isLocalPlayer;
        public static JObject UnitRadiusData;
        private IList<Player> NearEnemies = new List<Player>();

        public static IList<Player> GetAllObjects() {
            var players = new List<Player>();

            var objCount = Engine.GetPlayerCount();
            for (int i = 0; i < objCount; ++i) {
                var player = new Player(i);
                players.Add(player);
            }

            players = players.Where(x => x.IsValid()).ToList();

            return players;
        }

        private Player(int native_id) {
            this.nativeId = native_id;

            if (native_id >= API.AllPlayerData.AllPlayers.Count || native_id >= Engine.GetPlayerCount()) {
                throw new ApplicationException("id does not exist");
            }

            var AllPlayers = API.AllPlayerData.AllPlayers;
            // e.g. training objects in pratice mode show up with a different summoner name in API and native
            // their api_id will be -1 -> IsValid() == false
            apiId = AllPlayers.IndexOf(AllPlayers.Where(x => x.SummonerName == GetName()).FirstOrDefault());

            if (apiId != -1)
                isLocalPlayer = API.ActivePlayerData.GetSummonerName() == GetPlayerAPI().SummonerName;

            if (isLocalPlayer)
                LocalPlayer = this;
        }

        private bool IsValid() {
            return apiId != -1;
        }

        override public int GetMemoryAddress() {
            return Engine.GetPlayer(nativeId);
        }

        public API.Models.PlayerData GetPlayerAPI() {
            if(IsValid())
                return API.AllPlayerData.AllPlayers[apiId];
            else
                throw new ApplicationException("GetPlayerAPI(): Player API is not available for invalid player object");
        }

        override public bool IsLocalPlayer() {
            return isLocalPlayer;
        }

        public string GetSummonerName() {
            return GetPlayerAPI().SummonerName;
        }

        public string GetTeam() {
            return GetPlayerAPI().Team;
        }

        public int GetLevel() {
            return GetPlayerAPI().Level;
        }

        public float GetCurrentGold() {
            if(isLocalPlayer)
                return API.ActivePlayerData.GetCurrentGold();
            else
                throw new NotImplementedException("GetCurrentGold() is only implemented for LocalPlayer");
        }

        override public void DrawExecution() {
            if (CanExecute(true))
                Overlay.Drawing.DrawFactory.DrawFont("Execute", 60, Renderer.WorldToScreen(GetPosition()), Color.Red);
        }

        public void DrawMarker() {
            if (!IsLocalPlayer() && GetTeam() != LocalPlayer.GetTeam())
                Overlay.Drawing.DrawFactory.DrawFont(GetChampionName(), 60, Renderer.WorldToScreen(GetPosition()) + new Vector2(0, 60), Color.Yellow);
        }

        public void SetNearEnemiesList(int range) {
            if (IsLocalPlayer()
                || GetTeam() == LocalPlayer.GetTeam()
                || !IsVisible()
                || GetCurrentHealth() <= 1.0f)
                return;

            var position = GetPosition();
            var local_position = LocalPlayer.GetPosition();

            var distance = (int) (position - local_position).Length();

            if (distance <= range) {
                LocalPlayer.NearEnemies.Add(this);
            }
        }

        public void DrawEnemyWarning(int range) {
            string showText = "";
            foreach(var player in NearEnemies) {
                showText += player.GetChampionName() + "\n";
            }
            showText = showText.TrimEnd('\n');
            Overlay.Drawing.DrawFactory.DrawCircleRange(GetPosition(), range, Color.Orange, 2.5f);
            if (showText != "")
                Overlay.Drawing.DrawFactory.DrawFont(showText, 60, Renderer.GetScreenResolution() / 2, Color.Red);
            NearEnemies.Clear();
        }

        public void DrawSpellRange(Spells.SpellBook.SpellSlot Slot, Color Colour, float Thickness) {
            Overlay.Drawing.DrawFactory.DrawCircleRange(GetPosition(), Spells.SpellBook.GetSpellRadius(Slot), Colour, Thickness);
        }

        private List<string> RangeSlotList = new List<string>() { "Q", "W", "E", "R" };
        private List<float> UsedRangeSlotsList = new List<float>();
        public void DrawAllSpellRange(Color RGB) {
            foreach(string RangeSlot in RangeSlotList) {
                float SpellRange = Spells.SpellBook.SpellDB[RangeSlot].ToObject<JObject>()["Range"][0].ToObject<float>();

                if(UsedRangeSlotsList.Count != 0) {
                    if(!UsedRangeSlotsList.Contains(SpellRange)) {
                        UsedRangeSlotsList.Add(SpellRange);
                    }
                } else {
                    UsedRangeSlotsList.Add(SpellRange);
                }
            }

            foreach(float Range in UsedRangeSlotsList) {
                Overlay.Drawing.DrawFactory.DrawCircleRange(GetPosition(), Range, RGB, 2.5f);
            }
        }

        public string GetChampionName() {
            return GetPlayerAPI().ChampionName;
        }

        override public int GetBoundingRadius() {
            return int.Parse(UnitRadiusData[GetChampionName()]["Gameplay radius"].ToString());
        }

        public float GetHealthRegenRate() {
            if(isLocalPlayer)
                return API.ActivePlayerData.ChampionStats.GetHealthRegenRate();
            else
                throw new NotImplementedException("GetHealthRegenRate() is only implemented for LocalPlayer");
        }

        public string GetResourceType() {
            if(isLocalPlayer)
                return API.ActivePlayerData.ChampionStats.GetResourceType();
            else
                throw new NotImplementedException("GetResourceType() is only implemented for LocalPlayer");
        }

        public float GetCurrentMana() {
            if(isLocalPlayer)
                return API.ActivePlayerData.ChampionStats.GetResourceValue();
            else
                throw new NotImplementedException("GetCurrentMana() is only implemented for LocalPlayer");
        }

        public float GetCurrentManaMax() {
            if(isLocalPlayer)
                return API.ActivePlayerData.ChampionStats.GetResourceMax();
            else
                throw new NotImplementedException("GetCurrentManaMax() is only implemented for LocalPlayer");
        }

        public float GetAttackDamage() {
            if(isLocalPlayer)
                return API.ActivePlayerData.ChampionStats.GetAttackDamage();
            else
                throw new NotImplementedException("GetAbilityPower() is only implemented for LocalPlayer");
        }

        public float GetAbilityPower() {
            if(isLocalPlayer)
                return API.ActivePlayerData.ChampionStats.GetAbilityPower();
            else
                throw new NotImplementedException("GetAbilityPower() is only implemented for LocalPlayer");
        }

        public float GetArmorPenetrationFlat() {
            if(isLocalPlayer)
                return API.ActivePlayerData.ChampionStats.GetArmorPenetrationFlat();
            else
                throw new NotImplementedException("GetArmorPenetrationFlat() is only implemented for LocalPlayer");
        }

        public float GetArmorPenetrationPercent() {
            if(isLocalPlayer)
                return API.ActivePlayerData.ChampionStats.GetArmorPenetrationPercent();
            else
                throw new NotImplementedException("GetArmorPenetrationPercent() is only implemented for LocalPlayer");
        }

        public float GetAttackSpeed() {
            if(isLocalPlayer)
                return API.ActivePlayerData.ChampionStats.GetAttackSpeed();
            else
                throw new NotImplementedException("GetAttackSpeed() is only implemented for LocalPlayer");
        }

        public float GetBonusArmorPenetrationPercent() {
            if(isLocalPlayer)
                return API.ActivePlayerData.ChampionStats.GetBonusArmorPenetrationPercent();
            else
                throw new NotImplementedException("GetBonusArmorPenetrationPercent() is only implemented for LocalPlayer");
        }

        public float GetBonusMagicPenetrationPercent() {
            if(isLocalPlayer)
                return API.ActivePlayerData.ChampionStats.GetBonusMagicPenetrationPercent();
            else
                throw new NotImplementedException("GetBonusMagicPenetrationPercent() is only implemented for LocalPlayer");
        }

        public float GetCooldownReduction() {
            if(isLocalPlayer)
                return API.ActivePlayerData.ChampionStats.GetCooldownReduction();
            else
                throw new NotImplementedException("GetCooldownReduction() is only implemented for LocalPlayer");
        }

        public float GetCritChance() {
            if(isLocalPlayer)
                return API.ActivePlayerData.ChampionStats.GetCritChance();
            else
                throw new NotImplementedException("GetCritChance() is only implemented for LocalPlayer");
        }

        public float GetCritDamage() {
            if(isLocalPlayer)
                return API.ActivePlayerData.ChampionStats.GetCritDamage();
            else
                throw new NotImplementedException("GetCritDamage() is only implemented for LocalPlayer");
        }

        public float GetLifeSteal() {
            if(isLocalPlayer)
                return API.ActivePlayerData.ChampionStats.GetLifeSteal();
            else
                throw new NotImplementedException("GetLifeSteal() is only implemented for LocalPlayer");
        }

        public float GetMagicLethality() {
            if(isLocalPlayer)
                return API.ActivePlayerData.ChampionStats.GetMagicLethality();
            else
                throw new NotImplementedException("GetMagicLethality() is only implemented for LocalPlayer");
        }

        public float GetMagicPenetrationFlat() {
            if(isLocalPlayer)
                return API.ActivePlayerData.ChampionStats.GetMagicPenetrationFlat();
            else
                throw new NotImplementedException("GetMagicPenetrationFlat() is only implemented for LocalPlayer");
        }

        public float GetMagicPenetrationPercent() {
            if(isLocalPlayer)
                return API.ActivePlayerData.ChampionStats.GetMagicPenetrationPercent();
            else
                throw new NotImplementedException("GetMagicPenetrationPercent() is only implemented for LocalPlayer");
        }

        public float GetMoveSpeed() {
            if(isLocalPlayer)
                return API.ActivePlayerData.ChampionStats.GetMoveSpeed();
            else
                throw new NotImplementedException("GetMoveSpeed() is only implemented for LocalPlayer");
        }

        public float GetPhysicalLethality() {
            if(isLocalPlayer)
                return API.ActivePlayerData.ChampionStats.GetPhysicalLethality();
            else
                throw new NotImplementedException("GetPhysicalLethality() is only implemented for LocalPlayer");
        }

        public float GetSpellVamp() {
            if(isLocalPlayer)
                return API.ActivePlayerData.ChampionStats.GetSpellVamp();
            else
                throw new NotImplementedException("GetSpellVamp() is only implemented for LocalPlayer");
        }

        public float GetTenacity() {
            if(isLocalPlayer)
                return API.ActivePlayerData.ChampionStats.GetTenacity();
            else
                throw new NotImplementedException("GetTenacity() is only implemented for LocalPlayer");
        }
    }
}

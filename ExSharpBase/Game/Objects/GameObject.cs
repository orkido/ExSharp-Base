using ExSharpBase.Modules;
using SharpDX;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExSharpBase.Game.Objects
{
    abstract class GameObject
    {
        public static Player LocalPlayer;

        virtual public bool IsLocalPlayer() {
            return false;
        }

        public abstract int GetMemoryAddress();

        public void DrawAttackRange(Color Colour, float Thickness) {
            if(GetCurrentHealth() > 1.0f) {
                Overlay.Drawing.DrawFactory.DrawCircleRange(GetPosition(), GetBoundingRadius() + GetAttackRange(), Colour, Thickness);
            }
        }

        public bool IsVisible() {
            return Memory.Read<byte>(GetMemoryAddress() + OffsetManager.Object.Visibility) != 0;
        }

        public Vector3 GetPosition() {
            float posX = Memory.Read<float>(GetMemoryAddress() + OffsetManager.Object.Pos);
            float posY = Memory.Read<float>(GetMemoryAddress() + OffsetManager.Object.Pos + 0x4);
            float posZ = Memory.Read<float>(GetMemoryAddress() + OffsetManager.Object.Pos + 0x8);

            return new Vector3() { X = posX, Y = posY, Z = posZ };
        }

        public float GetCurrentHealth() {
            return Memory.Read<float>(GetMemoryAddress() + OffsetManager.Object.Health);
        }

        public float GetMaxHealth() {
            return Memory.Read<float>(GetMemoryAddress() + OffsetManager.Object.MaxHealth);
        }

        public abstract int GetBoundingRadius();

        virtual public float GetAttackRange() {
            return Memory.Read<float>(GetMemoryAddress() + OffsetManager.Object.AttackRange);
        }

        public string GetName() {
            return Memory.ReadString(GetMemoryAddress() + OffsetManager.Object.Name, Encoding.UTF8);
        }

        public float GetArmor() {
            if(IsLocalPlayer())
                return API.ActivePlayerData.ChampionStats.GetArmor();
            else
                return Memory.Read<float>(GetMemoryAddress() + OffsetManager.Object.Armor);
        }

        public float GetMagicResist() {
            if(IsLocalPlayer())
                return API.ActivePlayerData.ChampionStats.GetMagicResist();
            else
                return Memory.Read<float>(GetMemoryAddress() + OffsetManager.Object.MagicResist);
        }

        public abstract void DrawExecution();

        protected bool CanExecute(bool abilities) {
            if(GetCurrentHealth() > 1.0f && !IsLocalPlayer()) {
                int local_level = LocalPlayer.GetLevel();
                const int DAMAGETYPE_TRUE = 0;
                const int DAMAGETYPE_NORMAL = 1;
                const int DAMAGETYPE_MAGIC = 2;

                int damage_type = DAMAGETYPE_TRUE;
                float base_damage = 0.0f;
                float percentAd = 0.0f;
                float percentAp = 0.0f;

                // Damage is increased by up to percentHealthMultiplier based on missing enemy health. Maximum if enemy health is below percentHealthMultiplierMax
                float percentHealthMultiplier = 0.0f;
                float percentHealthMultiplierMax = 1.0f;
                float percentMissingHealth = 0.0f;
                float percentMaxHealth = 0.0f;

                if(abilities) {
                    // Garen R execute
                    if(LocalPlayer.GetChampionName() == "Garen") {
                        damage_type = DAMAGETYPE_TRUE;
                        if(local_level >= 16) {
                            base_damage = 450.0f;
                            percentMissingHealth = 0.30f;
                        } else if(local_level >= 11) {
                            base_damage = 300.0f;
                            percentMissingHealth = 0.25f;
                        } else if(local_level >= 6) {
                            base_damage = 150.0f;
                            percentMissingHealth = 0.20f;
                        }
                        // Lux R execute
                    } else if(LocalPlayer.GetChampionName() == "Lux") {
                        damage_type = DAMAGETYPE_MAGIC;

                        if(local_level >= 6) {
                            percentAp = 1.0f;
                        }

                        if(local_level >= 16) {
                            base_damage = 500.0f;
                        } else if(local_level >= 11) {
                            base_damage = 400.0f;
                        } else if(local_level >= 6) {
                            base_damage = 300.0f;
                        }
                        // Urgot R execute
                    } else if(LocalPlayer.GetChampionName() == "Urgot") {
                        // the normal damage combined with true damage is currently not supported
                        damage_type = DAMAGETYPE_TRUE;

                        if(local_level >= 6) {
                            percentMaxHealth = 0.25f;
                            // percentAd = 0.5f;
                        }

                        if(local_level >= 16) {
                            // base_damage = 350.0f;
                        } else if(local_level >= 11) {
                            // base_damage = 225.0f;
                        } else if(local_level >= 6) {
                            // base_damage = 100.0f;
                        }
                        // Darius R execute
                    } else if(LocalPlayer.GetChampionName() == "Darius") {
                        damage_type = DAMAGETYPE_TRUE;

                        if(local_level >= 6) {
                            percentAd = 0.75f;
                        }

                        if(local_level >= 16) {
                            base_damage = 300.0f;
                        } else if(local_level >= 11) {
                            base_damage = 200.0f;
                        } else if(local_level >= 6) {
                            base_damage = 100.0f;
                        }
                        // Veigar R execute
                    } else if(LocalPlayer.GetChampionName() == "Veigar") {
                        damage_type = DAMAGETYPE_MAGIC;

                        if(local_level >= 6) {
                            percentAp = 0.75f;
                            percentHealthMultiplier = 1.0f;
                            percentHealthMultiplierMax = 0.33f;
                        }

                        if(local_level >= 16) {
                            base_damage = 325.0f;
                        } else if(local_level >= 11) {
                            base_damage = 250.0f;
                        } else if(local_level >= 6) {
                            base_damage = 175.0f;
                        }
                    }
                } else {
                    // No abilities
                    damage_type = DAMAGETYPE_NORMAL;
                    percentAd = 1.0f;
                }

                // Calculate resistance
                float resistanceValue = 0.0f;
                float penetrationPercent = 0.0f;
                float penetrationFlat = 0.0f;
                float penetrationLethality = 0.0f;

                if(damage_type == DAMAGETYPE_TRUE) {
                } else if(damage_type == DAMAGETYPE_NORMAL) {
                    resistanceValue = GetArmor();
                    penetrationPercent = LocalPlayer.GetArmorPenetrationPercent();
                    penetrationFlat = LocalPlayer.GetArmorPenetrationFlat();
                    penetrationLethality = LocalPlayer.GetPhysicalLethality();
                } else if(damage_type == DAMAGETYPE_MAGIC) {
                    resistanceValue = GetMagicResist();
                    penetrationPercent = LocalPlayer.GetMagicPenetrationPercent();
                    penetrationFlat = LocalPlayer.GetMagicPenetrationFlat();
                    penetrationLethality = LocalPlayer.GetMagicLethality();
                }

                // Lethality calculation
                penetrationFlat += penetrationLethality * (0.6f + 0.4f * local_level / 18.0f);

                // Negative resistance is not affected by penetration
                if(resistanceValue > 0.0f) {
                    resistanceValue = resistanceValue * penetrationPercent - penetrationFlat;
                    // Penetration cannot reduce resistance below 0
                    resistanceValue = Math.Max(0.0f, resistanceValue);
                }

                // Damage multiplier for armor, magic resistance or true damage
                float damageMultiplier;
                if(resistanceValue >= 0.0f) {
                    damageMultiplier = 100.0f / (100.0f + resistanceValue);
                } else {
                    damageMultiplier = 2.0f - 100.0f / (100.0f - resistanceValue);
                }

                float dealtDamage =
                    base_damage
                    + percentMissingHealth * (GetMaxHealth() - GetCurrentHealth())
                    + percentMaxHealth * GetMaxHealth()
                    + percentAd * LocalPlayer.GetAttackDamage()
                    + percentAp * LocalPlayer.GetAbilityPower();

                float percentCurrentHealth = GetCurrentHealth() / GetMaxHealth();

                if(percentCurrentHealth <= percentHealthMultiplierMax)
                    dealtDamage = dealtDamage * (1.0f + percentHealthMultiplier);
                else
                    dealtDamage = dealtDamage *
                        (1.0f + percentHealthMultiplier - percentHealthMultiplier * ((percentCurrentHealth - percentHealthMultiplierMax) / (1.0f - percentHealthMultiplierMax)));

                // Multiplier for armor, magic resist or true damage
                dealtDamage = damageMultiplier * dealtDamage;

                if(GetCurrentHealth() <= dealtDamage) {
                    return true;
                }
            }
            return false;
        }
    }
}

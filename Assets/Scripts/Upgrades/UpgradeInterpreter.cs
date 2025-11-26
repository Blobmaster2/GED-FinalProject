using System;
using System.Collections.Generic;
using UnityEngine;
using Upgrade_Lib;

public static class UpgradeInterpreter
{
    public static void ApplyUpgrade(Upgrade upgrade, Player player)
    {
        foreach (var modifier in upgrade.Modifiers)
        {
            var key = modifier.Key;
            var value = modifier.Value;

            switch (key)
            {
                case "player_speed":

                    player.speedMultiplier *= 1 + (value / 100);

                    break;

                case "bullet_speed":

                    player.bulletSpeed *= 1 + (value / 100);

                    break;

                case "bullet_damage":

                    player.bulletDamage *= 1 + (value / 100);

                    break;

                case "bullet_count":

                    player.bulletCount += (int)value;

                    break;

                case "shoot_cooldown":

                    player.TotalBulletCooldown /= 1 + (value / 100);

                    break;
            }
        }
    }
}

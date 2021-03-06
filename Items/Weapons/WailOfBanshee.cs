using Microsoft.Xna.Framework;
using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace AlchemistNPC.Items.Weapons
{
	public class WailOfBanshee : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Scroll ''Wail Of Banshee''");
			Tooltip.SetDefault("One-use item"
			+"\nContains the spell ''Wail of Banshee''"
			+"\nWhen used causes all normal enemies on the screen to instantly die"
			+"\nExhausts player for 1 minute, making him unable to use magic");
			DisplayName.AddTranslation(GameCulture.Russian, "Свиток ''Вопль Баньши''");
            Tooltip.AddTranslation(GameCulture.Russian, "Одноразовый предмет\nЭтот свиток содержит заклинание ''Вопль Баньши''\nПрименение мгновенно убивает всех обычных врагов на экране\nИстощает игрока на 1 минуту, не позволяя ему использовать магию");
        }

		public override void SetDefaults()
		{
			item.consumable = true;
			item.maxStack = 99;
			item.width = 32;
			item.height = 32;
			item.useTime = 60;
			item.useAnimation = 60;
			item.useStyle = 2;
			item.noMelee = true;
			item.rare = 11;
			item.mana = 200;
			item.autoReuse = false;
			item.shoot = mod.ProjectileType("WailOfBanshee");
			item.value = Item.sellPrice(1, 0, 0, 0);
			item.UseSound = SoundID.NPCDeath59;
		}

		public bool CalamityModRevengeance
		{
        get { return CalamityMod.CalamityWorld.revenge; }
        }
		
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			Vector2 vel1 = new Vector2(-0, 0);
			vel1 *= 0f;
			Projectile.NewProjectile(player.position.X, player.position.Y, vel1.X, vel1.Y, mod.ProjectileType("WailOfBanshee"), 1, 0, Main.myPlayer);
			if (ModLoader.GetLoadedMods().Contains("CalamityMod"))
			{
				if (CalamityModRevengeance)
				{
				player.AddBuff(mod.BuffType("Exhausted"), 1800); 
				}
				else
				{
				player.AddBuff(mod.BuffType("Exhausted"), 3600); 	
				}
			}
			if (!ModLoader.GetLoadedMods().Contains("CalamityMod"))
			{
				player.AddBuff(mod.BuffType("Exhausted"), 3600); 
			}
			return false;
		}
		public override bool CanUseItem(Player player)
		{
			if (!player.HasBuff(mod.BuffType("Exhausted")) && !player.HasBuff(mod.BuffType("ExecutionersEyes")) && !player.HasBuff(mod.BuffType("CloakOfFear")))
			{
				return true;
			}
			return false;
		}
	}
}

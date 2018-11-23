using Terraria.Utilities;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using System;
using System.IO;
using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using Terraria.Localization;

namespace AlchemistNPC.Items
{
	public class AlchemistGlobalItem : GlobalItem
	{	
		public static bool on = false;
		public static bool Luck = false;
		public static bool Luck2 = false;
		public static bool Menacing = false;
		public static bool Lucky = false;
		public static bool Violent = false;
		public static bool Warding = false;
		public static bool Stopper = false;
		public static bool PerfectionToken = false;
		
		public bool CalamityModDownedSCal
		{
		get { return CalamityMod.CalamityWorld.downedSCal; }
		}
		
		public override void HoldItem(Item item, Player player)
		{
			if (item.type == 2272 && NPC.AnyNPCs(mod.NPCType("Knuckles")))
			{
				item.damage = 1;
			}
		}
		
		public override void UpdateInventory(Item item, Player player)
		{
			if (item.type == mod.ItemType("LuckCharm"))
			{
				Luck = true;
			}
			if (item.type == mod.ItemType("LuckCharmT2"))
			{
				Luck = true;
				Luck2 = true;
			}
			if (item.type == mod.ItemType("PerfectionToken"))
			{
				PerfectionToken = true;
			}
			if (item.type == mod.ItemType("MenacingToken"))
			{
				Menacing = true;
			}
			if (item.type == mod.ItemType("LuckyToken"))
			{
				Lucky = true;
			}
			if (item.type == mod.ItemType("ViolentToken"))
			{
				Violent = true;
			}
			if (item.type == mod.ItemType("WardingToken"))
			{
				Warding = true;
			}
		}
		
		public override int ChoosePrefix(Item item, UnifiedRandom rand)
		{
			if (Luck == true && PerfectionToken == false)
			{
				if (item.melee)
				{
					if (Main.rand.Next(10) == 0)
					return 59;
				
					if (Main.rand.Next(20) == 0)
					return 81;
				}
				if (item.ranged && !item.consumable)
				{
					if (Main.rand.Next(10) == 0)
					return 20;
				
					if (Main.rand.Next(20) == 0)
					return 82;
				}
				if (item.magic)
				{
					if (Main.rand.Next(10) == 0)
					return 28;
				
					if (Main.rand.Next(20) == 0)
					return 83;
				}
				if (item.summon)
				{
					if (Main.rand.Next(10) == 0)
					return 57;
				
					if (Main.rand.Next(20) == 0)
					return 83;
				}
				if (item.thrown && !item.consumable)
				{
					if (Main.rand.Next(10) == 0)
					return 20;
				
					if (Main.rand.Next(20) == 0)
					return 82;
				}
			}
			if (Luck2 == true && !Menacing && !Lucky && !Violent && !Warding)
			{
				if (item.accessory)
				{
					if (Main.rand.Next(10) == 0)
					return 72;
				
					else if (Main.rand.Next(10) == 0)
					return 68;
				
					else if (Main.rand.Next(10) == 0)
					return 65;
				}
			}
			if (PerfectionToken == true)
			{
				if (item.melee)
				{
					return 81;
				}
				if (item.ranged && !item.consumable && item.knockBack > 0)
				{
					return 82;
				}
				if (item.ranged && !item.consumable && item.knockBack <= 0)
				{
					return 60;
				}
				if (item.magic && item.knockBack > 0)
				{
					return 83;
				}
				if (item.magic && item.knockBack <= 0)
				{
					return 60;
				}
				if (item.summon)
				{
					return 83;
				}
				if (item.thrown && !item.consumable)
				{
					return 82;
				}
			}
			if (item.accessory)
			{
				if (Menacing)
				{
					return 72;
				}
				if (Lucky)
				{
					return 68;
				}
				if (Violent)
				{
					return 80;
				}
				if (Warding)
				{
					return 65;
				}
			}
		return -1;
		}
		
		public override bool NewPreReforge(Item item)
		{
			Player player = Main.player[Main.myPlayer];
			if (Main.player[Main.myPlayer].HasItem(mod.ItemType("PerfectionToken")) && !Stopper)
			{
				Item[] inventory = Main.player[Main.myPlayer].inventory;
				for (int k = 0; k < inventory.Length; k++)
				{
					if (inventory[k].type == mod.ItemType("PerfectionToken"))
					{
						inventory[k].stack--;
						Stopper = true;
						break;
					}
				}
			}
			if (Main.player[Main.myPlayer].HasItem(mod.ItemType("MenacingToken")) && !Stopper)
			{
				Item[] inventory = Main.player[Main.myPlayer].inventory;
				for (int k = 0; k < inventory.Length; k++)
				{
					if (inventory[k].type == mod.ItemType("MenacingToken"))
					{
						inventory[k].stack--;
						Stopper = true;
						break;
					}
				}
			}
			if (Main.player[Main.myPlayer].HasItem(mod.ItemType("LuckyToken")) && !Stopper)
			{
				Item[] inventory = Main.player[Main.myPlayer].inventory;
				for (int k = 0; k < inventory.Length; k++)
				{
					if (inventory[k].type == mod.ItemType("LuckyToken"))
					{
						inventory[k].stack--;
						Stopper = true;
						break;
					}
				}
			}
			if (Main.player[Main.myPlayer].HasItem(mod.ItemType("ViolentToken")) && !Stopper)
			{
				Item[] inventory = Main.player[Main.myPlayer].inventory;
				for (int k = 0; k < inventory.Length; k++)
				{
					if (inventory[k].type == mod.ItemType("ViolentToken"))
					{
						inventory[k].stack--;
						Stopper = true;
						break;
					}
				}
			}
			if (Main.player[Main.myPlayer].HasItem(mod.ItemType("WardingToken")) && !Stopper)
			{
				Item[] inventory = Main.player[Main.myPlayer].inventory;
				for (int k = 0; k < inventory.Length; k++)
				{
					if (inventory[k].type == mod.ItemType("WardingToken"))
					{
						inventory[k].stack--;
						Stopper = true;
						break;
					}
				}
			}	
			return true;
		}
		
		public override bool ConsumeItem(Item item, Player player)	
		{
			if (((AlchemistNPCPlayer)player.GetModPlayer(mod, "AlchemistNPCPlayer")).AlchemistCharmTier4 == true && (item.buffTime > 0 || item.healLife > 0 || item.healMana > 0))
			{
				if (CalamityModDownedSCal)
				{
				return false;
				}
				else if (Main.rand.NextFloat() >= .25f)
				{
				return false;
				}
			}
			
			else if (((AlchemistNPCPlayer)player.GetModPlayer(mod, "AlchemistNPCPlayer")).AlchemistCharmTier3 == true && (item.buffTime > 0 || item.healLife > 0 || item.healMana > 0))
			{
				if (Main.rand.Next(2) == 0)
				return false;
			}
			
			else if (((AlchemistNPCPlayer)player.GetModPlayer(mod, "AlchemistNPCPlayer")).AlchemistCharmTier2 == true && (item.buffTime > 0 || item.healLife > 0 || item.healMana > 0))
			{
				if (Main.rand.Next(4) == 0)
				return false;
			}
			
			else if (((AlchemistNPCPlayer)player.GetModPlayer(mod, "AlchemistNPCPlayer")).AlchemistCharmTier1 == true && (item.buffTime > 0 || item.healLife > 0 || item.healMana > 0))
			{
				if (Main.rand.Next(10) == 0)
				return false;
			}
			return true;
		}
		
		private void BluemagicGodmode(Player player)
        {
			Bluemagic.BluemagicPlayer BluemagicPlayer = player.GetModPlayer<Bluemagic.BluemagicPlayer>(Bluemagic);
			BluemagicPlayer.godmode = false;
        }
		private readonly Mod Bluemagic = ModLoader.GetMod("Bluemagic");
		
		public override void UpdateAccessory(Item item, Player player, bool hideVisual)
		{
			if (ModLoader.GetLoadedMods().Contains("Bluemagic"))
			{
				if (item.type == (ModLoader.GetMod("Bluemagic").ItemType("RainbowStar")) && NPC.AnyNPCs(mod.NPCType("BillCipher")))
				{
				BluemagicGodmode(player);
				player.endurance -= 1f;
				player.statDefense -= 1337;
				}
			}
		}
		
		public override bool ConsumeAmmo(Item item, Player player)
		{
			if (player.HasBuff(mod.BuffType("DemonSlayer")))
			{
			return Main.rand.NextFloat() >= .25f;
			}
			return true;
		}
		
		public override float UseTimeMultiplier(Item item, Player player)	
		{
			if (((AlchemistNPCPlayer)player.GetModPlayer(mod, "AlchemistNPCPlayer")).Symbiote == true)
			{
				return 1.2f;
			}
			if (player.HasBuff(mod.BuffType("ThoriumCombo")))
			{
				return 1.08f;
			}
			return 1f;
		}
		
		public override bool Shoot(Item item, Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			if (player.HasBuff(mod.BuffType("DemonSlayer")) && item.thrown && Main.rand.Next(3) == 0)
			{
				Projectile.NewProjectile(position.X, position.Y-12, speedX, speedY, type, damage, knockBack, player.whoAmI);
			}
			if (((AlchemistNPCPlayer)player.GetModPlayer(mod, "AlchemistNPCPlayer")).Rampage == true && type == 14)
			{
				type = mod.ProjectileType("Chloroshard");
			}
			if (((AlchemistNPCPlayer)player.GetModPlayer(mod, "AlchemistNPCPlayer")).Rampage == true && type == 1)
			{
				type = mod.ProjectileType("ChloroshardArrow");
			}
			if (((AlchemistNPCPlayer)player.GetModPlayer(mod, "AlchemistNPCPlayer")).DeltaRune && item.melee && Main.rand.NextBool(15))
			{
				Projectile.NewProjectile(position.X, position.Y, speedX, speedY, mod.ProjectileType("RedWave"), 6666, 1f, player.whoAmI);
			}
			if (((AlchemistNPCPlayer)player.GetModPlayer(mod, "AlchemistNPCPlayer")).DeltaRune && item.magic && Main.rand.NextBool(30))
			{
				Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(10));
				Vector2 perturbedSpeed2 = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(10));
				Vector2 perturbedSpeed3 = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(10));
				Vector2 perturbedSpeed4 = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(20));
				Vector2 perturbedSpeed5 = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(20));
				Vector2 perturbedSpeed6 = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(30));
				Vector2 perturbedSpeed7 = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(40));
				Vector2 perturbedSpeed8 = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(40));
				Vector2 vector = player.RotatedRelativePoint(player.MountedCenter, true);
				speedX = perturbedSpeed.X;
				speedY = perturbedSpeed.Y;
				float speedX2 = perturbedSpeed2.X/4;
				float speedY2 = perturbedSpeed2.Y/4;
				float speedX3 = perturbedSpeed3.X/4;
				float speedY3 = perturbedSpeed3.Y/4;
				float speedX4 = perturbedSpeed4.X/4;
				float speedY4 = perturbedSpeed4.Y/4;
				float speedX5 = perturbedSpeed5.X/4;
				float speedY5 = perturbedSpeed5.Y/4;
				float speedX6 = perturbedSpeed6.X/4;
				float speedY6 = perturbedSpeed6.Y/4;
				float speedX7 = perturbedSpeed7.X/4;
				float speedY7 = perturbedSpeed7.Y/4;
				float speedX8 = perturbedSpeed8.X/4;
				float speedY8 = perturbedSpeed8.Y/4;
				Projectile.NewProjectile(vector.X, vector.Y, speedX, speedY, 297, 2222, knockBack, player.whoAmI);
				Projectile.NewProjectile(vector.X, vector.Y, speedX2, speedY2, 297, 2222, knockBack, player.whoAmI);
				Projectile.NewProjectile(vector.X, vector.Y, speedX3, speedY3, 297, 2222, knockBack, player.whoAmI);
				Projectile.NewProjectile(vector.X, vector.Y, speedX4, speedY4, 297, 2222, knockBack, player.whoAmI);
				Projectile.NewProjectile(vector.X, vector.Y, speedX5, speedY5, 297, 2222, knockBack, player.whoAmI);
				Projectile.NewProjectile(vector.X, vector.Y, speedX6, speedY6, 297, 2222, knockBack, player.whoAmI);
				Projectile.NewProjectile(vector.X, vector.Y, speedX7, speedY7, 297, 2222, knockBack, player.whoAmI);
				Projectile.NewProjectile(vector.X, vector.Y, speedX8, speedY8, 297, 2222, knockBack, player.whoAmI);
			}
			return base.Shoot(item, player, ref position, ref speedX, ref speedY, ref type, ref damage, ref knockBack);
		}
		
		public override bool UseItem(Item item, Player player)
		{
			if (((AlchemistNPCPlayer)player.GetModPlayer(mod, "AlchemistNPCPlayer")).DeltaRune && item.melee && Main.rand.NextBool(60))
			{
				float num1 = 9f;
				Vector2 vector2 = new Vector2(player.position.X + (float)player.width * 0.5f, player.position.Y + (float)player.height * 0.5f);
				float f1 = (float)Main.mouseX + Main.screenPosition.X - vector2.X;
				float f2 = (float)Main.mouseY + Main.screenPosition.Y - vector2.Y;
				if ((double)player.gravDir == -1.0)
					f2 = Main.screenPosition.Y + (float)Main.screenHeight - (float)Main.mouseY - vector2.Y;
				float num4 = (float)Math.Sqrt((double)f1 * (double)f1 + (double)f2 * (double)f2);
				float num5;
				if (float.IsNaN(f1) && float.IsNaN(f2) || (double)f1 == 0.0 && (double)f2 == 0.0)
				{
					f1 = (float)player.direction;
					f2 = 0.0f;
					num5 = num1;
				}
				else
					num5 = num1 / num4;
				float SpeedX = f1 * num5;
				float SpeedY = f2 * num5;
				Projectile.NewProjectile(vector2.X, vector2.Y, SpeedX, SpeedY, mod.ProjectileType("RedWave"), 6666, 1f, player.whoAmI);
			}
			return base.UseItem(item, player);
		}
		
		public override void PickAmmo(Item item, Player player, ref int type, ref float speed, ref int damage, ref float knockback)
		{
			if (type == ProjectileID.Bullet && player.GetModPlayer<AlchemistNPCPlayer>().Rampage)
			{
				type = mod.ProjectileType("Chloroshard");
			}
			if (type == 1 && player.GetModPlayer<AlchemistNPCPlayer>().Rampage)
			{
				type = mod.ProjectileType("ChloroshardArrow");
			}
		}
		
		public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
		{
			string BillCipher = Language.GetTextValue("Mods.AlchemistNPC.BillCipher");
			string Knuckles = Language.GetTextValue("Mods.AlchemistNPC.Knuckles");
            //SBMW:Vanilla
            string KingSlime = Language.GetTextValue("Mods.AlchemistNPC.KingSlime");
            string EyeofCthulhu = Language.GetTextValue("Mods.AlchemistNPC.EyeofCthulhu");
            string EaterOfWorlds = Language.GetTextValue("Mods.AlchemistNPC.EaterOfWorlds");
            string BrainOfCthulhu = Language.GetTextValue("Mods.AlchemistNPC.BrainOfCthulhu");
            string QueenBee = Language.GetTextValue("Mods.AlchemistNPC.QueenBee");
            string Skeletron = Language.GetTextValue("Mods.AlchemistNPC.Skeletron");
            string WallOfFlesh = Language.GetTextValue("Mods.AlchemistNPC.WallOfFlesh");
            string Destroyer = Language.GetTextValue("Mods.AlchemistNPC.Destroyer");
            string Twins = Language.GetTextValue("Mods.AlchemistNPC.Twins");
            string SkeletronPrime = Language.GetTextValue("Mods.AlchemistNPC.SkeletronPrime");
            string Plantera = Language.GetTextValue("Mods.AlchemistNPC.Plantera");
            string Golem = Language.GetTextValue("Mods.AlchemistNPC.Golem");
			string Betsy = Language.GetTextValue("Mods.AlchemistNPC.Betsy");
            string DukeFishron = Language.GetTextValue("Mods.AlchemistNPC.DukeFishron");
            string MoonLord = Language.GetTextValue("Mods.AlchemistNPC.MoonLord");

            //SBMW:CalamityMod
            string DesertScourge = Language.GetTextValue("Mods.AlchemistNPC.DesertScourge");
            string Crabulon = Language.GetTextValue("Mods.AlchemistNPC.Crabulon");
            string HiveMind = Language.GetTextValue("Mods.AlchemistNPC.HiveMind");
            string Perforator = Language.GetTextValue("Mods.AlchemistNPC.Perforator");
            string SlimeGod = Language.GetTextValue("Mods.AlchemistNPC.SlimeGod");
            string Cryogen = Language.GetTextValue("Mods.AlchemistNPC.Cryogen");
            string BrimstoneElemental = Language.GetTextValue("Mods.AlchemistNPC.BrimstoneElemental");
            string AquaticScourge = Language.GetTextValue("Mods.AlchemistNPC.AquaticScourge");
            string Calamitas = Language.GetTextValue("Mods.AlchemistNPC.Calamitas");
            string AstrageldonSlime = Language.GetTextValue("Mods.AlchemistNPC.AstrageldonSlime");
            string AstrumDeus = Language.GetTextValue("Mods.AlchemistNPC.AstrumDeus");
            string Leviathan = Language.GetTextValue("Mods.AlchemistNPC.Leviathan");
            string PlaguebringerGoliath = Language.GetTextValue("Mods.AlchemistNPC.PlaguebringerGoliath");
            string Ravager = Language.GetTextValue("Mods.AlchemistNPC.Ravager");
            string Providence = Language.GetTextValue("Mods.AlchemistNPC.Providence");
            string Polterghast = Language.GetTextValue("Mods.AlchemistNPC.Polterghast");
            string DevourerofGods = Language.GetTextValue("Mods.AlchemistNPC.DevourerofGods");
            string Bumblebirb = Language.GetTextValue("Mods.AlchemistNPC.Bumblebirb");
            string Yharon = Language.GetTextValue("Mods.AlchemistNPC.Yharon");

            //SBMW:ThoriumMod
			string DarkMage = Language.GetTextValue("Mods.AlchemistNPC.DarkMage");
			string Ogre = Language.GetTextValue("Mods.AlchemistNPC.Ogre");
            string ThunderBird = Language.GetTextValue("Mods.AlchemistNPC.ThunderBird");
            string QueenJellyfish = Language.GetTextValue("Mods.AlchemistNPC.QueenJellyfish");
			string CountEcho = Language.GetTextValue("Mods.AlchemistNPC.CountEcho");
            string GraniteEnergyStorm = Language.GetTextValue("Mods.AlchemistNPC.GraniteEnergyStorm");
            string TheBuriedChampion = Language.GetTextValue("Mods.AlchemistNPC.TheBuriedChampion");
            string TheStarScouter = Language.GetTextValue("Mods.AlchemistNPC.TheStarScouter");
            string BoreanStrider = Language.GetTextValue("Mods.AlchemistNPC.BoreanStrider");
            string CoznixTheFallenBeholder = Language.GetTextValue("Mods.AlchemistNPC.CoznixTheFallenBeholder");
            string TheLich = Language.GetTextValue("Mods.AlchemistNPC.TheLich");
            string AbyssionTheForgottenOne = Language.GetTextValue("Mods.AlchemistNPC.AbyssionTheForgottenOne");
            string TheRagnarok = Language.GetTextValue("Mods.AlchemistNPC.TheRagnarok");
			
			//SacredTools
			string FlamingPumpkin = Language.GetTextValue("Mods.AlchemistNPC.FlamingPumpkin");
            string Jensen = Language.GetTextValue("Mods.AlchemistNPC.Jensen");
			string Raynare = Language.GetTextValue("Mods.AlchemistNPC.Raynare");
            string Abaddon = Language.GetTextValue("Mods.AlchemistNPC.Abaddon");
            string Araghur = Language.GetTextValue("Mods.AlchemistNPC.Araghur");
            string Lunarians = Language.GetTextValue("Mods.AlchemistNPC.Lunarians");
            string Challenger = Language.GetTextValue("Mods.AlchemistNPC.Challenger");
			
			//SpiritMod
			string Scarabeus = Language.GetTextValue("Mods.AlchemistNPC.Scarabeus");
            string Bane = Language.GetTextValue("Mods.AlchemistNPC.Bane");
			string Flier = Language.GetTextValue("Mods.AlchemistNPC.Flier");
            string Raider = Language.GetTextValue("Mods.AlchemistNPC.Raider");
            string Infernon = Language.GetTextValue("Mods.AlchemistNPC.Infernon");
            string Dusking = Language.GetTextValue("Mods.AlchemistNPC.Dusking");
            string EtherialUmbra = Language.GetTextValue("Mods.AlchemistNPC.EtherialUmbra");
			string IlluminantMaster = Language.GetTextValue("Mods.AlchemistNPC.IlluminantMaster");
			string Atlas = Language.GetTextValue("Mods.AlchemistNPC.Atlas");
			string Overseer = Language.GetTextValue("Mods.AlchemistNPC.Overseer");
			
			//Enigma
			string Sharkron = Language.GetTextValue("Mods.AlchemistNPC.Sharkron");
            string Hypothema = Language.GetTextValue("Mods.AlchemistNPC.Hypothema");
			string Ragnar = Language.GetTextValue("Mods.AlchemistNPC.Ragnar");
            string AnDio = Language.GetTextValue("Mods.AlchemistNPC.AnDio");
            string Annihilator = Language.GetTextValue("Mods.AlchemistNPC.Annihilator");
            string Slybertron = Language.GetTextValue("Mods.AlchemistNPC.Slybertron");
            string SteamTrain = Language.GetTextValue("Mods.AlchemistNPC.SteamTrain");
			
			//pinky
			string SunlightTrader = Language.GetTextValue("Mods.AlchemistNPC.SunlightTrader");
            string THOFC = Language.GetTextValue("Mods.AlchemistNPC.THOFC");
			string MythrilSlime = Language.GetTextValue("Mods.AlchemistNPC.MythrilSlime");
            string Valdaris = Language.GetTextValue("Mods.AlchemistNPC.Valdaris");
            string Gatekeeper = Language.GetTextValue("Mods.AlchemistNPC.Gatekeeper");
			
			if (item.type == mod.ItemType("KnucklesBag"))
			{
				TooltipLine line = new TooltipLine(mod, "Knuckles", Knuckles);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
			}
			if (item.type == mod.ItemType("BillCipherBag"))
			{
				TooltipLine line = new TooltipLine(mod, "BillCipher", BillCipher);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
			}
            if (item.type == ItemID.KingSlimeBossBag)
			{
				TooltipLine line = new TooltipLine(mod, "KingSlime", KingSlime);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
			}
			if (item.type == ItemID.EyeOfCthulhuBossBag)
			{
				TooltipLine line = new TooltipLine(mod, "EyeofCthulhu", EyeofCthulhu);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
			}
			if (item.type == ItemID.EaterOfWorldsBossBag)
			{
				TooltipLine line = new TooltipLine(mod, "EaterOfWorlds", EaterOfWorlds);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
			}
			if (item.type == ItemID.BrainOfCthulhuBossBag)
			{
				TooltipLine line = new TooltipLine(mod, "BrainOfCthulhu", BrainOfCthulhu);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
			}
			if (item.type == ItemID.QueenBeeBossBag)
			{
				TooltipLine line = new TooltipLine(mod, "QueenBeeBossBag", QueenBee);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
			}
			if (item.type == ItemID.SkeletronBossBag)
			{
				TooltipLine line = new TooltipLine(mod, "Skeletron", Skeletron);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
			}
			if (item.type == ItemID.WallOfFleshBossBag)
			{
				TooltipLine line = new TooltipLine(mod, "WallOfFleshBoss", WallOfFlesh);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
			}
			if (item.type == ItemID.DestroyerBossBag)
			{
				TooltipLine line = new TooltipLine(mod, "Destroyer", Destroyer);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
			}
			if (item.type == ItemID.TwinsBossBag)
			{
				TooltipLine line = new TooltipLine(mod, "Twins", Twins);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
			}
			if (item.type == ItemID.SkeletronPrimeBossBag)
			{
				TooltipLine line = new TooltipLine(mod, "SkeletronPrime", SkeletronPrime);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
			}
			if (item.type == ItemID.PlanteraBossBag)
			{
				TooltipLine line = new TooltipLine(mod, "Plantera", Plantera);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
			}
			if (item.type == ItemID.GolemBossBag)
			{
				TooltipLine line = new TooltipLine(mod, "Golem", Golem);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
			}
			if (item.type == ItemID.BossBagBetsy)
			{
				TooltipLine line = new TooltipLine(mod, "Betsy", Betsy);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
			}
			if (item.type == ItemID.FishronBossBag)
			{
				TooltipLine line = new TooltipLine(mod, "DukeFishron", DukeFishron);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
			}
			if (item.type == ItemID.MoonLordBossBag)
			{
				TooltipLine line = new TooltipLine(mod, "MoonLord", MoonLord);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
			}
			if (ModLoader.GetLoadedMods().Contains("CalamityMod"))
			{
				if (item.type == (ModLoader.GetMod("CalamityMod").ItemType("DesertScourgeBag")))
				{
				TooltipLine line = new TooltipLine(mod, "DesertScourge", DesertScourge);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("CalamityMod").ItemType("CrabulonBag")))
				{
				TooltipLine line = new TooltipLine(mod, "Crabulon", Crabulon);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("CalamityMod").ItemType("HiveMindBag")))
				{
				TooltipLine line = new TooltipLine(mod, "HiveMind", HiveMind);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("CalamityMod").ItemType("PerforatorBag")))
				{
				TooltipLine line = new TooltipLine(mod, "Perforator", Perforator);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("CalamityMod").ItemType("SlimeGodBag")))
				{
				TooltipLine line = new TooltipLine(mod, "SlimeGod", SlimeGod);

                line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("CalamityMod").ItemType("CryogenBag")))
				{
				TooltipLine line = new TooltipLine(mod, "Cryogen", Cryogen);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("CalamityMod").ItemType("BrimstoneWaifuBag")))
				{
				TooltipLine line = new TooltipLine(mod, "BrimstoneElemental", BrimstoneElemental);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("CalamityMod").ItemType("AquaticScourgeBag")))
				{
				TooltipLine line = new TooltipLine(mod, "AquaticScourge", AquaticScourge);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("CalamityMod").ItemType("CalamitasBag")))
				{
				TooltipLine line = new TooltipLine(mod, "Calamitas", Calamitas);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("CalamityMod").ItemType("AstrageldonBag")))
				{
				TooltipLine line = new TooltipLine(mod, "AstrageldonSlime", AstrageldonSlime);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("CalamityMod").ItemType("AstrumDeusBag")))
				{
				TooltipLine line = new TooltipLine(mod, "AstrumDeus", AstrumDeus);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("CalamityMod").ItemType("LeviathanBag")))
				{
				TooltipLine line = new TooltipLine(mod, "Leviathan", Leviathan);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("CalamityMod").ItemType("PlaguebringerGoliathBag")))
				{
				TooltipLine line = new TooltipLine(mod, "PlaguebringerGoliath", PlaguebringerGoliath);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("CalamityMod").ItemType("RavagerBag")))
				{
				TooltipLine line = new TooltipLine(mod, "Ravager", Ravager);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("CalamityMod").ItemType("ProvidenceBag")))
				{
				TooltipLine line = new TooltipLine(mod, "Providence", Providence);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("CalamityMod").ItemType("PolterghastBag")))
				{
				TooltipLine line = new TooltipLine(mod, "Polterghast", Polterghast);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("CalamityMod").ItemType("DevourerofGodsBag")))
				{
				TooltipLine line = new TooltipLine(mod, "DevourerofGods", DevourerofGods);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("CalamityMod").ItemType("BumblebirbBag")))
				{
				TooltipLine line = new TooltipLine(mod, "Bumblebirb", Bumblebirb);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("CalamityMod").ItemType("YharonBag")))
				{
				TooltipLine line = new TooltipLine(mod, "Yharon", Yharon);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
			}
			if (ModLoader.GetLoadedMods().Contains("ThoriumMod"))
			{
				if (item.type == (ModLoader.GetMod("ThoriumMod").ItemType("DarkMageBag")))
				{
				TooltipLine line = new TooltipLine(mod, "DarkMage", DarkMage);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("ThoriumMod").ItemType("OgreBag")))
				{
				TooltipLine line = new TooltipLine(mod, "Ogre", Ogre);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("ThoriumMod").ItemType("ThunderBirdBag")))
				{
				TooltipLine line = new TooltipLine(mod, "ThunderBird", ThunderBird);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("ThoriumMod").ItemType("JellyFishBag")))
				{
				TooltipLine line = new TooltipLine(mod, "QueenJellyfish", QueenJellyfish);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("ThoriumMod").ItemType("CountBag")))
				{
				TooltipLine line = new TooltipLine(mod, "CountEcho", CountEcho);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("ThoriumMod").ItemType("GraniteBag")))
				{
				TooltipLine line = new TooltipLine(mod, "GraniteEnergyStorm", GraniteEnergyStorm);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("ThoriumMod").ItemType("HeroBag")))
				{
				TooltipLine line = new TooltipLine(mod, "TheBuriedChampion", TheBuriedChampion);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("ThoriumMod").ItemType("ScouterBag")))
				{
				TooltipLine line = new TooltipLine(mod, "TheStarScouter", TheStarScouter);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("ThoriumMod").ItemType("BoreanBag")))
				{
				TooltipLine line = new TooltipLine(mod, "BoreanStrider", BoreanStrider);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("ThoriumMod").ItemType("BeholderBag")))
				{
				TooltipLine line = new TooltipLine(mod, "CoznixTheFallenBeholder", CoznixTheFallenBeholder);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("ThoriumMod").ItemType("LichBag")))
				{
				TooltipLine line = new TooltipLine(mod, "TheLich", TheLich);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("ThoriumMod").ItemType("AbyssionBag")))
				{
				TooltipLine line = new TooltipLine(mod, "AbyssionTheForgottenOne", AbyssionTheForgottenOne);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("ThoriumMod").ItemType("RagBag")))
				{
				TooltipLine line = new TooltipLine(mod, "TheRagnarok", TheRagnarok);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
			}
			if (ModLoader.GetLoadedMods().Contains("SacredTools"))
			{
				if (item.type == (ModLoader.GetMod("SacredTools").ItemType("PumpkinBag")))
				{
				TooltipLine line = new TooltipLine(mod, "FlamingPumpkin", FlamingPumpkin);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("SacredTools").ItemType("HarpyBag")))
				{
				TooltipLine line = new TooltipLine(mod, "Jensen", Jensen);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("SacredTools").ItemType("HarpyBag2")))
				{
				TooltipLine line = new TooltipLine(mod, "Raynare", Raynare);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("SacredTools").ItemType("OblivionBag")))
				{
				TooltipLine line = new TooltipLine(mod, "Abaddon", Abaddon);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("SacredTools").ItemType("SerpentBag")))
				{
				TooltipLine line = new TooltipLine(mod, "Araghur", Araghur);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("SacredTools").ItemType("LunarBag")))
				{
				TooltipLine line = new TooltipLine(mod, "Lunarians", Lunarians);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("SacredTools").ItemType("ChallengerBag")))
				{
				TooltipLine line = new TooltipLine(mod, "Challenger", Challenger);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
			}
			if (ModLoader.GetLoadedMods().Contains("SpiritMod"))
			{
				if (item.type == (ModLoader.GetMod("SpiritMod").ItemType("BagOScarabs")))
				{
				TooltipLine line = new TooltipLine(mod, "Scarabeus", Scarabeus);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("SpiritMod").ItemType("ReachBossBag")))
				{
				TooltipLine line = new TooltipLine(mod, "Bane", Bane);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("SpiritMod").ItemType("FlyerBag")))
				{
				TooltipLine line = new TooltipLine(mod, "Flier", Flier);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("SpiritMod").ItemType("SteamRaiderBag")))
				{
				TooltipLine line = new TooltipLine(mod, "Raider", Raider);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("SpiritMod").ItemType("InfernonBag")))
				{
				TooltipLine line = new TooltipLine(mod, "Infernon", Infernon);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("SpiritMod").ItemType("DuskingBag")))
				{
				TooltipLine line = new TooltipLine(mod, "Dusking", Dusking);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("SpiritMod").ItemType("SpiritCoreBag")))
				{
				TooltipLine line = new TooltipLine(mod, "EqualityComparer", EtherialUmbra);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("SpiritMod").ItemType("IlluminantBag")))
				{
				TooltipLine line = new TooltipLine(mod, "IlluminantMaster", IlluminantMaster);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("SpiritMod").ItemType("AtlasBag")))
				{
				TooltipLine line = new TooltipLine(mod, "Atlas", Atlas);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("SpiritMod").ItemType("OverseerBag")))
				{
				TooltipLine line = new TooltipLine(mod, "Overseer", Overseer);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
			}
			if (ModLoader.GetLoadedMods().Contains("Laugicality"))
			{
				if (item.type == (ModLoader.GetMod("Laugicality").ItemType("DuneSharkronTreasureBag")))
				{
				TooltipLine line = new TooltipLine(mod, "Sharkron", Sharkron);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("Laugicality").ItemType("HypothemaTreasureBag")))
				{
				TooltipLine line = new TooltipLine(mod, "Hypothema", Hypothema);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("Laugicality").ItemType("RagnarTreasureBag")))
				{
				TooltipLine line = new TooltipLine(mod, "Ragnar", Ragnar);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("Laugicality").ItemType("AnDioTreasureBag")))
				{
				TooltipLine line = new TooltipLine(mod, "AnDio", AnDio);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("Laugicality").ItemType("AnnihilatorTreasureBag")))
				{
				TooltipLine line = new TooltipLine(mod, "Annihilator", Annihilator);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("Laugicality").ItemType("SlybertronTreasureBag")))
				{
				TooltipLine line = new TooltipLine(mod, "Slybertron", Slybertron);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("Laugicality").ItemType("SteamTrainTreasureBag")))
				{
				TooltipLine line = new TooltipLine(mod, "SteamTrain", SteamTrain);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
			}
			if (ModLoader.GetLoadedMods().Contains("pinkymod"))
			{
				if (item.type == (ModLoader.GetMod("pinkymod").ItemType("STBag")))
				{
				TooltipLine line = new TooltipLine(mod, "SunlightTrader", SunlightTrader);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("pinkymod").ItemType("HOTCTreasureBag")))
				{
				TooltipLine line = new TooltipLine(mod, "THOFC", THOFC);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("pinkymod").ItemType("MythrilBag")))
				{
				TooltipLine line = new TooltipLine(mod, "MythrilSlime", MythrilSlime);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("pinkymod").ItemType("Valdabag")))
				{
				TooltipLine line = new TooltipLine(mod, "Valdaris", Valdaris);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("pinkymod").ItemType("GatekeeperTreasureBag")))
				{
				TooltipLine line = new TooltipLine(mod, "Gatekeeper", Gatekeeper);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
			}
		}
		
		public override void OpenVanillaBag(string context, Player player, int arg)
		{
			if (Main.hardMode && context == "bossBag" && Main.rand.Next(150) == 0)
			{
				player.QuickSpawnItem(mod.ItemType("SuspiciousLookingScythe"));
			}
			if (NPC.downedPlantBoss && context == "bossBag" && Main.rand.Next(150) == 0)
			{
				player.QuickSpawnItem(mod.ItemType("HeartofYui"));
			}
			if (Main.hardMode && context == "bossBag" && Main.rand.Next(150) == 0)
			{
				player.QuickSpawnItem(mod.ItemType("StatsChecker"));
			}
			if (NPC.downedPlantBoss && context == "bossBag" && Main.rand.Next(200) == 0)
			{
				player.QuickSpawnItem(mod.ItemType("BanHammer"));
			}
			if (NPC.downedPlantBoss && context == "bossBag" && Main.rand.Next(150) == 0)
			{
				player.QuickSpawnItem(mod.ItemType("PinkGuyHead"));
				player.QuickSpawnItem(mod.ItemType("PinkGuyBody"));
				player.QuickSpawnItem(mod.ItemType("PinkGuyLegs"));
			}
			if (NPC.downedPlantBoss && context == "bossBag" && Main.rand.Next(150) == 0)
			{
				player.QuickSpawnItem(mod.ItemType("BlackCatHead"));
				player.QuickSpawnItem(mod.ItemType("BlackCatBody"));
				player.QuickSpawnItem(mod.ItemType("BlackCatLegs"));
			}
			if (NPC.downedPlantBoss && context == "bossBag" && Main.rand.Next(150) == 0)
			{
				player.QuickSpawnItem(mod.ItemType("Skyline222Hair"));
				player.QuickSpawnItem(mod.ItemType("Skyline222Body"));
				player.QuickSpawnItem(mod.ItemType("Skyline222Legs"));
			}
			if (NPC.downedPlantBoss && context == "bossBag" && Main.rand.Next(150) == 0)
			{
				player.QuickSpawnItem(mod.ItemType("somebody0214Hood"));
				player.QuickSpawnItem(mod.ItemType("somebody0214Robe"));
			}
			if (NPC.downedPlantBoss && context == "bossBag" && Main.rand.Next(250) == 0)
			{
				player.QuickSpawnItem(mod.ItemType("BloodMoonCirclet"));
				player.QuickSpawnItem(mod.ItemType("BloodMoonDress"));
				player.QuickSpawnItem(mod.ItemType("BloodMoonStockings"));
			}
			if (NPC.downedMoonlord && context == "bossBag" && Main.rand.Next(300) == 0)
			{
				player.QuickSpawnItem(mod.ItemType("StrangeTopHat"));
			}
		}
		
		public override void HorizontalWingSpeeds(Item item, Player player, ref float speed, ref float acceleration)	
		{
			if (player.HasBuff(mod.BuffType("Exhausted")))
			{
			speed *= 0.8f;
			acceleration *= 0.8f;
			}
			if (((AlchemistNPCPlayer)player.GetModPlayer(mod, "AlchemistNPCPlayer")).chargetime >= 390)
			{
			speed *= 0.5f;
			acceleration *= 0.5f;
			}
			else if (((AlchemistNPCPlayer)player.GetModPlayer(mod, "AlchemistNPCPlayer")).chargetime >= 210)
			{
			speed *= 0.8f;
			acceleration *= 0.8f;
			}
		}
		
		public override bool CloneNewInstances
		{
			get
			{
				return true;
			}
		}
		
		public override bool InstancePerEntity
		{
			get
			{
				return true;
			}
		}
	}
}

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace NexusMod3.Items.Consumables
{
	public class MerchantGuildBanner : ModItem
	{
		public override void SetStaticDefaults() {

			DisplayName.SetDefault("Merchant Guild Banner");
			Tooltip.SetDefault("Summons the traveling merchant.");
		}

		public override void SetDefaults() {

			item.width = 20;
			item.height = 20;
			item.maxStack = 1;
			item.value = 100 * 100 * 100;
			item.rare = 1;
			item.useAnimation = 30;
			item.useTime = 30;
			item.useStyle = 4;
			item.consumable = true;

		}

		public override bool CanUseItem(Player player) {
			return !NPC.AnyNPCs(NPCID.TravellingMerchant);
		}

		public override bool UseItem(Player player) {
			NPC.SpawnOnPlayer(player.whoAmI, NPCID.TravellingMerchant);
			Main.PlaySound(SoundID.Coins, player.position, 0);
			return true;
		}
	}
}
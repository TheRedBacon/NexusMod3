using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace NexusMod3.Items
{
    public class Bang : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Six Shooter");
            Tooltip.SetDefault("Yippee ki-yay, mother****er");
        }
		public override void SetDefaults()
        {
            item.damage = 35;  //gun damage
            item.crit = 4;
            item.ranged = true;   //its a gun so set this to true
            item.width = 50;     //gun image width
            item.height = 35;   //gun image  height   //gun description
            item.useTime = 10;  //how fast 
            item.useAnimation = 60;
	    item.reuseDelay = 75;
            item.useStyle = 5;
	    item.noMelee = true; //so the item's animation doesn't do damage
            item.knockBack = 1;
            item.value = 10000;
            item.rare = 5;
            item.UseSound = SoundID.Item11;
            item.autoReuse = false;
            item.shoot = 10; //idk why but all the guns in the vanilla source have this
            item.shootSpeed = 16f;
            item.useAmmo = AmmoID.Bullet;
        }
		public override bool ConsumeAmmo(Player player)
		{
			// Because of how the game works, player.itemAnimation will be 11, 7, and finally 3. (UseAmination - 1, then - useTime until less than 0.) 
			// We can get the Clockwork Assault Riffle Effect by not consuming ammo when itemAnimation is lower than the first shot.
			return !(player.itemAnimation < item.useAnimation - 5);
		}

        public override void AddRecipes()  //How to craft this gun
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.CobaltBar, 7);   //you need 1 DirtBlock
			recipe.AddIngredient(ItemID.PhoenixBlaster, 1);
            recipe.AddTile(TileID.MythrilAnvil);   //at work bench
            recipe.SetResult(this);
            recipe.AddRecipe();

			ModRecipe recipe2 = new ModRecipe(mod);
            recipe2.AddIngredient(ItemID.PalladiumBar, 7);   //you need 1 DirtBlock
			recipe2.AddIngredient(ItemID.PhoenixBlaster, 1);
            recipe2.AddTile(TileID.MythrilAnvil);   //at work bench
            recipe2.SetResult(this);
            recipe2.AddRecipe();
        }
    }
}

using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace smasher.Items
{
    public class Bang : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("6 Shooter");
            Tooltip.SetDefault("Yippie ki yay, mother****er");
        }
		public override void SetDefaults()
        {
            item.damage = 30;  //gun damage
            item.crit = 4;
            item.ranged = true;   //its a gun so set this to true
            item.width = 50;     //gun image width
            item.height = 35;   //gun image  height   //gun description
            item.useTime = 10;  //how fast 
            item.useAnimation = 60;
			item.reuseDelay = 90;
            item.useStyle = 5;
			item.noMelee = true; //so the item's animation doesn't do damage
            item.knockBack = 1;
            item.value = 1000000;
            item.rare = 12;
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
			return !(player.itemAnimation < item.useAnimation - 2);
		}

        public override void AddRecipes()  //How to craft this gun
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.DirtBlock, 1);   //you need 1 DirtBlock
            recipe.AddTile(TileID.WorkBenches);   //at work bench
            recipe.SetResult(this);
            recipe.AddRecipe();

        }
    }
}
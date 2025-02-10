using System.Collections.Generic;
using Humanizer;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Chat.Commands;
using Terraria.DataStructures;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;

namespace piratesplus.Content.Items.Weapons
{
    // This is a basic item template.
    // Please see tModLoader's ExampleMod for every other example:
    // https://github.com/tModLoader/tModLoader/tree/stable/ExampleMod
    public class PilferersDream : ModItem
    {
        // The Display Name and Tooltip of this item can be edited in the 'Localization/en-US_Mods.piratesplus.hjson' file.
        public override void SetDefaults()
        {

            Item.autoReuse = true;  // Whether or not you can hold click to automatically use it again.
            Item.damage = 60; // Sets the item's damage. Note that projectiles shot by this weapon will use its and the used ammunition's damage added together.
            Item.DamageType = DamageClass.Ranged; // What type of damage does this item affect?
            Item.knockBack = 4f; // Sets the item's knockback. Note that projectiles shot by this weapon will use its and the used ammunition's knockback added together.
            Item.noMelee = true; // So the item's animation doesn't do damage.
            Item.rare = ItemRarityID.Yellow; // The color that the item's name will be in-game.
            Item.shootSpeed = 10f; // The speed of the projectile (measured in pixels per frame.)
            Item.useAnimation = 35; // The length of the item's use animation in ticks (60 ticks == 1 second.)
            Item.useTime = 35; // The item's use time in ticks (60 ticks == 1 second.)
            Item.UseSound = SoundID.Item11; // The sound that this item plays when used.
            Item.useStyle = ItemUseStyleID.Shoot; // How you use the item (swinging, holding out, shoot, etc.)
            Item.value = Item.buyPrice(gold: 1);

            Item.shoot = ProjectileID.Bullet;
            Item.useAmmo = AmmoID.Bullet;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.DirtBlock, 10);
            recipe.AddTile(TileID.WorkBenches);
            recipe.Register();
        }

        public override void ModifyShootStats(
            Player player,
            ref Vector2 position,
            ref Vector2 velocity,
            ref int type,
            ref int damage,
            ref float knockback
        )
        {
            int coins = player.CountItem(ItemID.PlatinumCoin);
            if (coins > 1)
            {
                damage *= coins+1;
			}
            base.ModifyShootStats(player, ref position, ref velocity, ref type, ref damage, ref knockback);
        }
        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
			int coins = Main.player[Main.myPlayer].CountItem(ItemID.PlatinumCoin);
			Main.NewText(tooltips[8].Text = $"x{coins + 1}");
			
            base.ModifyTooltips(tooltips);
        }
    }
}

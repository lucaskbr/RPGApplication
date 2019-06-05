namespace RPGApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.item",
                c => new
                    {
                        ItemId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Image = c.String(),
                        Description = c.String(nullable: false, maxLength: 150),
                        RequiredLevel = c.Int(nullable: false),
                        Price = c.Int(nullable: false),
                        ItemRarity_ItemRarityId = c.Int(),
                    })
                .PrimaryKey(t => t.ItemId)
                .ForeignKey("dbo.item_rarity", t => t.ItemRarity_ItemRarityId)
                .Index(t => t.ItemRarity_ItemRarityId);
            
            CreateTable(
                "dbo.item_rarity",
                c => new
                    {
                        ItemRarityId = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 20),
                    })
                .PrimaryKey(t => t.ItemRarityId);
            
            CreateTable(
                "dbo.attack",
                c => new
                    {
                        AttackId = c.Int(nullable: false, identity: true),
                        DamageDone = c.Int(nullable: false),
                        Attacker_CharacterId = c.Int(nullable: false),
                        Combat_CombatId = c.Int(),
                    })
                .PrimaryKey(t => t.AttackId)
                .ForeignKey("dbo.character", t => t.Attacker_CharacterId, cascadeDelete: true)
                .ForeignKey("dbo.combat", t => t.Combat_CombatId)
                .Index(t => t.Attacker_CharacterId)
                .Index(t => t.Combat_CombatId);
            
            CreateTable(
                "dbo.character",
                c => new
                    {
                        CharacterId = c.Int(nullable: false, identity: true),
                        Image = c.String(),
                        Name = c.String(nullable: false, maxLength: 30),
                        LifePoints = c.Int(nullable: false),
                        Level = c.Int(nullable: false),
                        Experience = c.Double(nullable: false),
                        AttributePoints = c.Int(nullable: false),
                        Coins = c.Int(nullable: false),
                        RankingPoints = c.Int(nullable: false),
                        Bag_BagId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CharacterId)
                .ForeignKey("dbo.bag", t => t.Bag_BagId, cascadeDelete: true)
                .Index(t => t.Bag_BagId);
            
            CreateTable(
                "dbo.attribute_in_character",
                c => new
                    {
                        AttributeInCharacterId = c.Int(nullable: false, identity: true),
                        ProficiencyPoints = c.Int(nullable: false),
                        Proficiency_ProficiencyId = c.Int(nullable: false),
                        Character_CharacterId = c.Int(),
                    })
                .PrimaryKey(t => t.AttributeInCharacterId)
                .ForeignKey("dbo.Proficiency", t => t.Proficiency_ProficiencyId, cascadeDelete: true)
                .ForeignKey("dbo.character", t => t.Character_CharacterId)
                .Index(t => t.Proficiency_ProficiencyId)
                .Index(t => t.Character_CharacterId);
            
            CreateTable(
                "dbo.Proficiency",
                c => new
                    {
                        ProficiencyId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 20),
                    })
                .PrimaryKey(t => t.ProficiencyId);
            
            CreateTable(
                "dbo.bag",
                c => new
                    {
                        BagId = c.Int(nullable: false, identity: true),
                        slots = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BagId);
            
            CreateTable(
                "dbo.item_in_bag",
                c => new
                    {
                        ItemInBagId = c.Int(nullable: false, identity: true),
                        Equipped = c.Boolean(nullable: false),
                        Bag_BagId = c.Int(nullable: false),
                        Item_ItemId = c.Int(),
                    })
                .PrimaryKey(t => t.ItemInBagId)
                .ForeignKey("dbo.bag", t => t.Bag_BagId, cascadeDelete: true)
                .ForeignKey("dbo.item", t => t.Item_ItemId)
                .Index(t => t.Bag_BagId)
                .Index(t => t.Item_ItemId);
            
            CreateTable(
                "dbo.combat",
                c => new
                    {
                        CombatId = c.Int(nullable: false, identity: true),
                        CharacterOne_CharacterId = c.Int(),
                        CharacterTwo_CharacterId = c.Int(),
                        Winner_CharacterId = c.Int(),
                    })
                .PrimaryKey(t => t.CombatId)
                .ForeignKey("dbo.character", t => t.CharacterOne_CharacterId)
                .ForeignKey("dbo.character", t => t.CharacterTwo_CharacterId)
                .ForeignKey("dbo.character", t => t.Winner_CharacterId)
                .Index(t => t.CharacterOne_CharacterId)
                .Index(t => t.CharacterTwo_CharacterId)
                .Index(t => t.Winner_CharacterId);
            
            CreateTable(
                "dbo.user",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 20),
                        LastName = c.String(nullable: false, maxLength: 20),
                        Login = c.String(nullable: false, maxLength: 30),
                        Email = c.String(nullable: false, maxLength: 150),
                        Password = c.String(nullable: false, maxLength: 50),
                        AccessLevel = c.Int(nullable: false),
                        ActiveAccount = c.Boolean(nullable: false),
                        SignUpDate = c.DateTime(nullable: false),
                        Character_CharacterId = c.Int(),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.character", t => t.Character_CharacterId)
                .Index(t => t.Character_CharacterId);
            
            CreateTable(
                "dbo.armour",
                c => new
                    {
                        ItemId = c.Int(nullable: false),
                        Defense = c.Int(nullable: false),
                        Evasion = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.ItemId)
                .ForeignKey("dbo.item", t => t.ItemId)
                .Index(t => t.ItemId);
            
            CreateTable(
                "dbo.weapon",
                c => new
                    {
                        ItemId = c.Int(nullable: false),
                        Damage = c.Int(nullable: false),
                        Critical = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.ItemId)
                .ForeignKey("dbo.item", t => t.ItemId)
                .Index(t => t.ItemId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.weapon", "ItemId", "dbo.item");
            DropForeignKey("dbo.armour", "ItemId", "dbo.item");
            DropForeignKey("dbo.user", "Character_CharacterId", "dbo.character");
            DropForeignKey("dbo.combat", "Winner_CharacterId", "dbo.character");
            DropForeignKey("dbo.combat", "CharacterTwo_CharacterId", "dbo.character");
            DropForeignKey("dbo.combat", "CharacterOne_CharacterId", "dbo.character");
            DropForeignKey("dbo.attack", "Combat_CombatId", "dbo.combat");
            DropForeignKey("dbo.attack", "Attacker_CharacterId", "dbo.character");
            DropForeignKey("dbo.character", "Bag_BagId", "dbo.bag");
            DropForeignKey("dbo.item_in_bag", "Item_ItemId", "dbo.item");
            DropForeignKey("dbo.item", "ItemRarity_ItemRarityId", "dbo.item_rarity");
            DropForeignKey("dbo.item_in_bag", "Bag_BagId", "dbo.bag");
            DropForeignKey("dbo.attribute_in_character", "Character_CharacterId", "dbo.character");
            DropForeignKey("dbo.attribute_in_character", "Proficiency_ProficiencyId", "dbo.Proficiency");
            DropIndex("dbo.weapon", new[] { "ItemId" });
            DropIndex("dbo.armour", new[] { "ItemId" });
            DropIndex("dbo.user", new[] { "Character_CharacterId" });
            DropIndex("dbo.combat", new[] { "Winner_CharacterId" });
            DropIndex("dbo.combat", new[] { "CharacterTwo_CharacterId" });
            DropIndex("dbo.combat", new[] { "CharacterOne_CharacterId" });
            DropIndex("dbo.item_in_bag", new[] { "Item_ItemId" });
            DropIndex("dbo.item_in_bag", new[] { "Bag_BagId" });
            DropIndex("dbo.attribute_in_character", new[] { "Character_CharacterId" });
            DropIndex("dbo.attribute_in_character", new[] { "Proficiency_ProficiencyId" });
            DropIndex("dbo.character", new[] { "Bag_BagId" });
            DropIndex("dbo.attack", new[] { "Combat_CombatId" });
            DropIndex("dbo.attack", new[] { "Attacker_CharacterId" });
            DropIndex("dbo.item", new[] { "ItemRarity_ItemRarityId" });
            DropTable("dbo.weapon");
            DropTable("dbo.armour");
            DropTable("dbo.user");
            DropTable("dbo.combat");
            DropTable("dbo.item_in_bag");
            DropTable("dbo.bag");
            DropTable("dbo.Proficiency");
            DropTable("dbo.attribute_in_character");
            DropTable("dbo.character");
            DropTable("dbo.attack");
            DropTable("dbo.item_rarity");
            DropTable("dbo.item");
        }
    }
}

using BalanceModGenerator;

FileCreator.modName = "rebalance_XL_2";
FileCreator.Create(UnitHelpers.AllFactions, ["max_supply.levels.max_supply: *5"]);
FileCreator.Create(UnitHelpers.AllTitans, ["health.durability: +350"]);
FileCreator.Create(UnitHelpers.AllExtractors, ["structure.slots_required: 0"]);
FileCreator.Create(UnitHelpers.AllStarbases, ["health.durability: +600"]);
FileCreator.Create(UnitHelpers.Player, ["marginal_tax_rate_levels.credits.rate_taxable: *2", "marginal_tax_rate_levels.metal.rate_taxable: *2", "marginal_tax_rate_levels.crystal.rate_taxable: *2"]);
FileCreator.Create(UnitHelpers.AI, ["difficulties.unfair.fleet_will_probably_defeat_ratio_range: [0.7, 1.0]"]);
FileCreator.Create(UnitHelpers.AllStrikeCraft, ["health.levels.max_hull_points: *0.5", "health.levels.max_armor_points: *0.5"]);
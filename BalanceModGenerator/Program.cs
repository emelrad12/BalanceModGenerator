using BalanceModGenerator;

FileCreator.Create(UnitHelpers.AllFactions, ["max_supply.levels.max_supply: *5"]);
FileCreator.Create(UnitHelpers.AllTitans, ["health.durability: 1000"]);
FileCreator.Create(UnitHelpers.AllExtractors, ["structure.slots_required: 0"]);
FileCreator.Create(UnitHelpers.AllStarbases, ["health.durability: 1400"]);
FileCreator.Create(UnitHelpers.Player, ["marginal_tax_rate_levels.credits.tax_rate: *0.5"]);
FileCreator.Create(UnitHelpers.AI, ["difficulties.unfair.fleet_will_probably_defeat_ratio_range: [0.7, 1.0]"]);
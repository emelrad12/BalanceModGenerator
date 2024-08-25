using BalanceModGenerator;
using Newtonsoft.Json.Linq;

string[] factionChanges = ["max_supply.levels.max_supply: *5"];
string[] factionFiles = ["entities/trader_loyalist.player", "entities/trader_rebel.player", "entities/vasari_loyalist.player", "entities/vasari_rebel.player", "entities/advent_loyalist.player", "entities/advent_rebel.player"];
FileCreator.Create(factionFiles, factionChanges);

string[] titanChanges = ["health.durability: 1000"];
string[] titanFiles =
[
    "entities/advent_loyalist_titan.unit",
    "entities/advent_rebel_titan.unit",
    "entities/trader_rebel_titan.unit",
    "entities/trader_loyalist_titan.unit",
    "entities/vasari_rebel_titan.unit",
    "entities/vasari_loyalist_titan.unit"
];
FileCreator.Create(titanFiles, titanChanges);


string[] extractorChanges = ["structure.slots_required: 0"];
string[] extractorFiles =
[
    "entities/advent_crystal_extractor_structure.unit",
    "entities/advent_metal_extractor_structure.unit",
    "entities/trader_crystal_extractor_structure.unit",
    "entities/trader_metal_extractor_structure.unit",
    "entities/vasari_crystal_extractor_structure.unit",
    "entities/vasari_metal_extractor_structure.unit",
];
FileCreator.Create(extractorFiles, extractorChanges);

string[] starbaseChanges = ["health.durability: 1400"];
string[] starbaseFiles =
[
    "entities/advent_starbase.unit",
    "entities/trader_starbase.unit",
    "entities/vasari_starbase.unit",
];
FileCreator.Create(starbaseFiles, starbaseChanges);

string[] playerChanges = ["marginal_tax_rate_levels.credits.tax_rate: *0.5"];
string[] playerFiles = ["uniforms/player.uniforms"];
FileCreator.Create(playerFiles, playerChanges);

string[] aiChanges = ["difficulties.unfair.fleet_will_probably_defeat_ratio_range: [0.7, 1.0]"];
string[] aiFiles = ["uniforms/player_ai.uniforms"];
FileCreator.Create(aiFiles, aiChanges);
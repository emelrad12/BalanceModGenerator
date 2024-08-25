namespace BalanceModGenerator;

public static class UnitHelpers
{
    public static string[] AllExtractors =
    [
        "entities/advent_crystal_extractor_structure.unit",
        "entities/advent_metal_extractor_structure.unit",
        "entities/trader_crystal_extractor_structure.unit",
        "entities/trader_metal_extractor_structure.unit",
        "entities/vasari_crystal_extractor_structure.unit",
        "entities/vasari_metal_extractor_structure.unit",
    ];

    public static string[] AllStarbases =
    [
        "entities/advent_starbase.unit",
        "entities/trader_starbase.unit",
        "entities/vasari_starbase.unit",
    ];

    public static string[] AllTitans =
    [
        "entities/advent_loyalist_titan.unit",
        "entities/advent_rebel_titan.unit",
        "entities/trader_rebel_titan.unit",
        "entities/trader_loyalist_titan.unit",
        "entities/vasari_rebel_titan.unit",
        "entities/vasari_loyalist_titan.unit"
    ];

    public static string[] AllFactions = ["entities/trader_loyalist.player", "entities/trader_rebel.player", "entities/vasari_loyalist.player", "entities/vasari_rebel.player", "entities/advent_loyalist.player", "entities/advent_rebel.player"];
    public static string[] Player = ["uniforms/player.uniforms"];
    public static string[] AI = ["uniforms/player_ai.uniforms"];
}
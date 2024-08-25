using Newtonsoft.Json.Linq;

namespace BalanceModGenerator;

public class FileCreator
{
    static string targetFolder = "C:\\Users\\emelr\\AppData\\Local\\sins2\\mods\\rebalance_XL_2";
    static string sourceFolder = "C:\\Program Files (x86)\\Steam\\steamapps\\common\\Sins2";
    public static void Create(string[] files, string[] changes)
    {
        foreach (var item in files)
        {
            var file = File.ReadAllText(Path.Combine(sourceFolder, item));
            var json = JObject.Parse(file);
            FileChanges.ApplyChanges(json, changes);
            File.WriteAllText(Path.Combine(targetFolder, item), json.ToString());
        }
    }
}
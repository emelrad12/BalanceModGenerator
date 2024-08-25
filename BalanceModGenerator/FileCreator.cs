using Newtonsoft.Json.Linq;

namespace BalanceModGenerator;

public class FileCreator
{
    static string GetTargetFolderPath()
    {
        string userProfile = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
        string targetFolder = Path.Combine(userProfile, "AppData", "Local", "sins2", "mods", "rebalance_XL_2");
        return targetFolder;
    }

    // Function to get the source folder path
    static string GetSourceFolderPath()
    {
        string programFiles = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86);
        string sourceFolder = Path.Combine(programFiles, "Steam", "steamapps", "common", "Sins2");
        return sourceFolder;
    }

    public static void Create(string[] files, string[] changes)
    {
        foreach (var item in files)
        {
            var file = File.ReadAllText(Path.Combine(GetSourceFolderPath(), item));
            var json = JObject.Parse(file);
            FileChanges.ApplyChanges(json, changes);
            File.WriteAllText(Path.Combine(GetTargetFolderPath(), item), json.ToString());
        }
    }
}
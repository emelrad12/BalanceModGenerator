using Newtonsoft.Json.Linq;

namespace BalanceModGenerator;

public static class FileCreator
{
    public static string modName = "";

    public static string GetTargetFolderPath()
    {
        if (modName == "")
        {
            throw new("modName not set");
        }

        string userProfile = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
        string targetFolder = Path.Combine(userProfile, "AppData", "Local", "sins2", "mods", modName);
        return targetFolder;
    }

    public static string GetSourceFolderPath()
    {
        string programFiles = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86);
        string sourceFolder = Path.Combine(programFiles, "Steam", "steamapps", "common", "Sins2");
        return sourceFolder;
    }
    
    static void CreateTargetFolders(string targetFolderPath)
    {
        if (!Directory.Exists(targetFolderPath))
        {
            Directory.CreateDirectory(targetFolderPath);
            Console.WriteLine("Created target folder: " + targetFolderPath);
        }

        string entitiesFolderPath = Path.Combine(targetFolderPath, "entities");
        string uniformsFolderPath = Path.Combine(targetFolderPath, "uniforms");

        if (!Directory.Exists(entitiesFolderPath))
        {
            Directory.CreateDirectory(entitiesFolderPath);
            Console.WriteLine("Created 'entities' folder: " + entitiesFolderPath);
        }

        if (!Directory.Exists(uniformsFolderPath))
        {
            Directory.CreateDirectory(uniformsFolderPath);
            Console.WriteLine("Created 'uniforms' folder: " + uniformsFolderPath);
        }
    }


    public static void Create(string[] files, string[] changes)
    {
        CreateTargetFolders(GetTargetFolderPath());
        foreach (var item in files)
        {
            var file = File.ReadAllText(Path.Combine(GetSourceFolderPath(), item));
            var json = JObject.Parse(file);
            FileChanges.ApplyChanges(json, changes);
            File.WriteAllText(Path.Combine(GetTargetFolderPath(), item), json.ToString());
        }
    }
}
namespace BalanceModGenerator;

using System;
using Newtonsoft.Json.Linq;

public static class FileChanges
{
    public static void ApplyChanges(JObject json, string[] changes)
    {
        foreach (var change in changes)
        {
            ApplyChange(json, change);
        }
    }

    private static void ApplyChange(JObject json, string change)
    {
        // Split the change into path and value
        var parts = change.Split(':');
        if (parts.Length != 2)
        {
            Console.WriteLine($"Invalid change format: {change}");
            return;
        }

        var path = parts[0].Trim();
        var valueStr = parts[1].Trim();

        // Parse the value as a number or string
        JToken value;
        if (int.TryParse(valueStr, out int numInt))
        {
            value = new JValue(numInt);
        }
        else if (double.TryParse(valueStr, out double numDouble))
        {
            value = new JValue(numDouble);
        }
        else
        {
            if (valueStr.StartsWith("[") && valueStr.EndsWith("]"))
            {
                value = JArray.Parse(valueStr);
            }
            else
            {
                value = new JValue(valueStr);
            }
        }

        // Navigate through the JSON object to apply the change
        var tokens = path.Split('.');
        JObject currentObject = json;
        for (int i = 0; i < tokens.Length - 1; i++)
        {
            var token = tokens[i];
            if (currentObject[token] is JObject)
            {
                currentObject = (JObject)currentObject[token];
                if (i == tokens.Length - 2)
                {
                    currentObject[tokens[^1]] = value;
                }
            }

            if (currentObject[token] is JArray)
            {
                var array = (JArray)currentObject[token];
                for (int j = 0; j < array.Count; j++)
                {
                    array[j][tokens[i + 1]] = value;
                }
            }

            if (currentObject == null)
            {
                Console.WriteLine($"Invalid path in change: {change}");
                return;
            }
        }

        // Set the new value
    }
}
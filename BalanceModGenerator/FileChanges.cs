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

    private static double ApplyFunction(char functionChar, double functionValue, double value)
    {
        switch (functionChar)
        {
            case '*':
                return value * functionValue;
            case '/':
                return value / functionValue;
            case '+':
                return value + functionValue;
            case '-':
                return value - functionValue;
        }

        throw new("Invalid function character");
    }

    //For some reason JToken.contains is not working
    private static bool CheckIfContains(JToken target, string key)
    {
        try
        {
            target[key].Value<double>();
            return true;
        }
        catch
        {
            return false;
        }
    }

    private static void ApplyFunctionValue(JToken target, string key, bool isFunction, char functionChar, JToken value)
    {
        if (!isFunction)
        {
            target[key] = value;
        }
        else
        {
            if (!CheckIfContains(target, key))
            {
                Console.WriteLine($"Warning: missing key {key}, probably safe to ignore if expected");
                return;
            }

            var targetValue = target[key].Value<double>();
            var targetIsInt = target[key].Type == JTokenType.Integer;
            var finalValue = ApplyFunction(functionChar, value.Value<double>(), targetValue);
            if (targetIsInt) target[key] = (int)finalValue;
            else target[key] = finalValue;
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
        var tokenContainsFunction = false;
        var functionChar = '0'; // default value which is invalid
        if (valueStr.Contains("*") || valueStr.Contains("/") || valueStr.Contains("+") || valueStr.Contains("-"))
        {
            functionChar = valueStr[0];
            tokenContainsFunction = true;
            valueStr = valueStr[1..];
        }

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
                    ApplyFunctionValue(currentObject, tokens[^1], tokenContainsFunction, functionChar, value);
                    // currentObject[tokens[^1]] = value;
                }
            }

            if (currentObject[token] is JArray)
            {
                var array = (JArray)currentObject[token];
                for (int j = 0; j < array.Count; j++)
                {
                    ApplyFunctionValue(array[j], tokens[i + 1], tokenContainsFunction, functionChar, value);
                    // array[j][tokens[i + 1]] = value;
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
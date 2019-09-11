using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace Heroes.TextToJson
{
    class Program
    {
        private static readonly Dictionary<string, string> _keyValuePairs = new Dictionary<string, string>();

        static void Main(string[] args)
        {
            args = new string[] { @"F:\heroes\heroes_76003\gamestrings-76003\gamestrings_76003_enus.txt" };
            if (args != null && args.Length == 1)
            {
                string? fileNameNoExt = Path.GetFileNameWithoutExtension(args[0]);
                if (string.IsNullOrEmpty(fileNameNoExt))
                    return;

                using StreamReader reader = File.OpenText(args[0]);
                while (!reader.EndOfStream)
                {
                    string[]? line = reader.ReadLine()?.Split('=');
                    if (line != null)
                        _keyValuePairs.Add(line[0], line[1]);
                }

                using FileStream fileStream = new FileStream($"{fileNameNoExt}.json", FileMode.Create);

                Utf8JsonWriter utf8JsonWriter = new Utf8JsonWriter(fileStream, new JsonWriterOptions { Indented = true });

                utf8JsonWriter.WriteStartObject();

                foreach (var item in _keyValuePairs)
                {
                    utf8JsonWriter.WriteString(item.Key, item.Value);
                }

                utf8JsonWriter.WriteEndObject();

                utf8JsonWriter.Flush();
            }
        }
    }
}

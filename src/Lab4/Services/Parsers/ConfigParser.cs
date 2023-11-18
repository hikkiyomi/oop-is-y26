using System.Collections.Generic;
using System.IO;
using Itmo.ObjectOrientedProgramming.Lab4.Common.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services.Parsers;

public class ConfigParser
{
    private readonly Dictionary<string, string> _env = new();

    public ConfigParser(string path = "./config.cfg")
    {
        if (!File.Exists(path))
        {
            _env["file"] = "-";
            _env["directory"] = "#";
            _env["indentation"] = " ";

            return;
        }

        using (var reader = new StreamReader(path))
        {
            string? line;

            while ((line = reader.ReadLine()) is not null)
            {
                string[] args = line.Split(' ');

                if (args is not [_, "=", _])
                {
                    throw new ConfigException("Unexpected config declaration.");
                }

                _env[args[0]] = args[2];
            }
        }
    }

    public string? FindValueByKey(string key)
    {
        return _env.TryGetValue(key, out string? value)
            ? value
            : null;
    }
}
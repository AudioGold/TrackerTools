using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace TrackerTools;

public enum Tracker
{
    [Description("Redacted")]
    Redacted = 0,
    [Description("Orpheus")]
    Orpheus = 1
}

public class Config : Singleton<Config>
{
    private ConfigData? _configData;
    private Dictionary<Tracker, TrackerData>? _trackerData;

    private readonly Dictionary<string, Tracker> _trackerNameToTracker = new()
    {
        { "Redacted", Tracker.Redacted },
        { "Orpheus", Tracker.Orpheus },
    };

    public TrackerData GetConfigData(Tracker tracker)
    {
        return _trackerData[tracker];
    }

    public void Load()
    {
        using (StreamReader reader = new StreamReader("config.json"))
        {
            var json = reader.ReadToEnd();
            _configData = JsonConvert.DeserializeObject<ConfigData>(json);

            _trackerData = new Dictionary<Tracker, TrackerData>();
            foreach (var trackerData in _configData.Trackers)
            {
                var tracker = _trackerNameToTracker[trackerData.Name]; 
                _trackerData.Add(tracker, trackerData);
            }
        }
    }
}

public class ConfigData
{
    public List<TrackerData> Trackers { get; set; }
}

public class TrackerData
{
    public string Name { get; set; }
    public string Token { get; set; }
}
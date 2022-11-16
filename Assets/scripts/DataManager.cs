using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager
{
    public static DataManager Main { get; } = new();
    public bool Start { get; set; }
    public bool Active { get; set; }
    public Dictionary<string, float> CountriesCollectionTimes { get; } = new();
    public bool Finished { get; set; }
}

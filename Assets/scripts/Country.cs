using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Country
{
    public string name;
    public enum countriesNames
    {
        LUSORIA,
        MAMONIA,
        RESPUBLICA,
        STOMACHI,
        PRODIGALIA,
        VENEREA,
        BIBONIA,
        REGNUM
    }

    public countriesNames countryName;

    public int countCity;

    public int areaCountry;

    public int powerCountry;

}

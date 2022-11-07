using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Country
{
    public string name;
    public enum countriesNames
    {
        UNERIA,
        IMBERIAS,
        WALAH,
        NOTICS,
        ORENBERG,
        PLUTORAN,
        POLLON,
        UTOCAR
    }

    public countriesNames countryName;

    public int countCity;

    public int areaCountry;

    public int powerCountry;

}

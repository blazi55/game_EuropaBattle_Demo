using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(PolygonCollider2D))]
public class CountryHandler : MonoBehaviour {

    private SpriteRenderer spriteRenderer;

    private Color32 oldColor32;
    private Color32 hoverColor32;
    //public Color32 startColor32;
    public Country country;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        //spriteRenderer.color = startColor32;

    }
    
    void OnMouseEnter()
    {
        oldColor32 = spriteRenderer.color;
        if (country.countryName == Country.countriesNames.RESPUBLICA)
        {
            //hoverColor32 = new Color32(255, 255, 255, 120);
            hoverColor32 = new Color32(oldColor32.r, oldColor32.g, oldColor32.b, 240);
            spriteRenderer.color = hoverColor32;
        } else
        {
            hoverColor32 = new Color32(oldColor32.r, oldColor32.g, oldColor32.b, 240);
            spriteRenderer.color = hoverColor32;
        }
    }

    void OnMouseExit()
    {
        spriteRenderer.color = oldColor32;
    }

    void OnDrawGizmos()
    {
        country.name = name;
        this.tag = "Country";
    }

    void OnMouseUpAsButton()
    {
        if (!EventSystem.current.IsPointerOverGameObject())
        {
            ShowGUI();
        }

    }

    public void TintedCountry(Color32 color32)
    {
        spriteRenderer.color = color32;
    }

    void ShowGUI()
    {
        
        if (Country.countriesNames.RESPUBLICA == country.countryName)
        { 
           if (!GameManage.instance.nameOurCountry.Count.Equals(8))
           {
              CountryManager.instance.ShowPanelAttack("Change our Country! " + 
               country.countryName.ToString()
               , country.countCity, GameManage.instance.countCity, GameManage.instance.powerOurCountry, country.powerCountry,
               GameManage.instance.areaCountry, country.areaCountry);
           }
            
        } else if (Country.countriesNames.VENEREA == country.countryName)
        {
            if (!GameManage.instance.nameOurCountry.Count.Equals(0))
            {
                CountryManager.instance.ShowPanelAttack("Start War! with "+
                country.countryName.ToString()
                , country.countCity, GameManage.instance.countCity, GameManage.instance.powerOurCountry,
                GameManage.instance.powerCountryPLUTORAN, GameManage.instance.areaCountry, country.areaCountry);
            }
        } else if (Country.countriesNames.PRODIGALIA == country.countryName)
        {
            if (!GameManage.instance.nameOurCountry.Count.Equals(0))
            {
                CountryManager.instance.ShowPanelAttack("Start War! with " +
                country.countryName.ToString()
                , country.countCity, GameManage.instance.countCity, GameManage.instance.powerOurCountry,
                GameManage.instance.powerCountryORENBERG, GameManage.instance.areaCountry, country.areaCountry);
            }
        } else if (Country.countriesNames.BIBONIA == country.countryName)
        {
            if (!GameManage.instance.nameOurCountry.Count.Equals(0))
            {
                CountryManager.instance.ShowPanelAttack("Start War! with " +
                country.countryName.ToString()
                , country.countCity, GameManage.instance.countCity, GameManage.instance.powerOurCountry,
                GameManage.instance.powerCountryPOLLON, GameManage.instance.areaCountry, country.areaCountry);
            }
        } else if (Country.countriesNames.LUSORIA == country.countryName)
        {
            if (!GameManage.instance.nameOurCountry.Count.Equals(0))
            {
                CountryManager.instance.ShowPanelAttack("Start War! with " +
                country.countryName.ToString()
                , country.countCity, GameManage.instance.countCity, GameManage.instance.powerOurCountry,
                GameManage.instance.powerCountryUNERIA, GameManage.instance.areaCountry, country.areaCountry);
            }
        }
        else if (Country.countriesNames.MAMONIA == country.countryName)
        {
            if (!GameManage.instance.nameOurCountry.Count.Equals(0))
            {
                CountryManager.instance.ShowPanelAttack("Start War! with " +
                country.countryName.ToString()
                , country.countCity, GameManage.instance.countCity, GameManage.instance.powerOurCountry,
                GameManage.instance.powerCountryIMBERIAS, GameManage.instance.areaCountry, country.areaCountry);
            }
        }
        else if (Country.countriesNames.STOMACHI == country.countryName)
        {
            if (!GameManage.instance.nameOurCountry.Count.Equals(0))
            {
                CountryManager.instance.ShowPanelAttack("Start War! with " +
                country.countryName.ToString()
                , country.countCity, GameManage.instance.countCity, GameManage.instance.powerOurCountry,
                GameManage.instance.powerCountryNOTICS, GameManage.instance.areaCountry, country.areaCountry);
            }
        }
        else if (Country.countriesNames.REGNUM == country.countryName)
        {
            if (!GameManage.instance.nameOurCountry.Count.Equals(0))
            {
                CountryManager.instance.ShowPanelAttack("Start War! with " +
                country.countryName.ToString()
                , country.countCity, GameManage.instance.countCity, GameManage.instance.powerOurCountry,
                GameManage.instance.powerCountryUTOCAR, GameManage.instance.areaCountry, country.areaCountry);
            }
        }
        GameManage.instance.attackedCountry = country.name;
        GameManage.instance.battleHasEnded = false;
        GameManage.instance.battleWon = false;

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        if (country.countryName == Country.countriesNames.WALAH)
        {
            hoverColor32 = new Color32(255, 255, 255, 190);
            spriteRenderer.color = hoverColor32;
        } else
        {
            hoverColor32 = new Color32(oldColor32.r, oldColor32.g, oldColor32.b, 210);
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
        ShowGUI();

    }

    public void TintedCountry(Color32 color32)
    {
        spriteRenderer.color = color32;
    }

    void ShowGUI()
    {
        if (Country.countriesNames.WALAH == country.countryName)
        { 
           if (GameManage.instance.nameOurCountry.Count.Equals(8))
           {
               CountryManager.instance.ShowEndGamePanel();
           } 
           else
           {
               CountryManager.instance.ShowPanelAttack("Change our Country!", "This Country is owned " +
               country.countryName.ToString() + ". Are you sure? Do you want attack?"
               , country.countCity, GameManage.instance.countCity, GameManage.instance.powerOurCountry, country.powerCountry,
               GameManage.instance.areaCountry, country.areaCountry);
           }
            
        } else if (Country.countriesNames.PLUTORAN == country.countryName)
        {
            if (GameManage.instance.nameOurCountry.Count.Equals(0))
            {
                CountryManager.instance.ShowEndGamePanel();
            }
            else
            {
                CountryManager.instance.ShowPanelAttack("Start War!", "This Country is owned " +
                country.countryName.ToString() + ". Are you sure? Do you want attack?"
                , country.countCity, GameManage.instance.countCity, GameManage.instance.powerOurCountry,
                GameManage.instance.powerCountryPLUTORAN, GameManage.instance.areaCountry, country.areaCountry);
            }
        } else if (Country.countriesNames.ORENBERG == country.countryName)
        {
            if (GameManage.instance.nameOurCountry.Count.Equals(0))
            {
                CountryManager.instance.ShowEndGamePanel();

            }
            else
            {
                CountryManager.instance.ShowPanelAttack("Start War!", "This Country is owned " +
                country.countryName.ToString() + ". Are you sure? Do you want attack?"
                , country.countCity, GameManage.instance.countCity, GameManage.instance.powerOurCountry,
                GameManage.instance.powerCountryORENBERG, GameManage.instance.areaCountry, country.areaCountry);
            }
        } else if (Country.countriesNames.POLLON == country.countryName)
        {
            if (GameManage.instance.nameOurCountry.Count.Equals(0))
            {
                CountryManager.instance.ShowEndGamePanel();

            }
            else
            {
                CountryManager.instance.ShowPanelAttack("Start War!", "This Country is owned " +
                country.countryName.ToString() + ". Are you sure? Do you want attack?"
                , country.countCity, GameManage.instance.countCity, GameManage.instance.powerOurCountry,
                GameManage.instance.powerCountryPOLLON, GameManage.instance.areaCountry, country.areaCountry);
            }
        } else if (Country.countriesNames.UNERIA == country.countryName)
        {
            if (GameManage.instance.nameOurCountry.Count.Equals(0))
            {
                CountryManager.instance.ShowEndGamePanel();

            }
            else
            {
                CountryManager.instance.ShowPanelAttack("Start War!", "This Country is owned " +
                country.countryName.ToString() + ". Are you sure? Do you want attack?"
                , country.countCity, GameManage.instance.countCity, GameManage.instance.powerOurCountry,
                GameManage.instance.powerCountryUNERIA, GameManage.instance.areaCountry, country.areaCountry);
            }
        }
        else if (Country.countriesNames.IMBERIAS == country.countryName)
        {
            if (GameManage.instance.nameOurCountry.Count.Equals(0))
            {
                CountryManager.instance.ShowEndGamePanel();

            }
            else
            {
                CountryManager.instance.ShowPanelAttack("Start War!", "This Country is owned " +
                country.countryName.ToString() + ". Are you sure? Do you want attack?"
                , country.countCity, GameManage.instance.countCity, GameManage.instance.powerOurCountry,
                GameManage.instance.powerCountryIMBERIAS, GameManage.instance.areaCountry, country.areaCountry);
            }
        }
        else if (Country.countriesNames.NOTICS == country.countryName)
        {
            if (GameManage.instance.nameOurCountry.Count.Equals(0))
            {
                CountryManager.instance.ShowEndGamePanel();

            }
            else
            {
                CountryManager.instance.ShowPanelAttack("Start War!", "This Country is owned " +
                country.countryName.ToString() + ". Are you sure? Do you want attack?"
                , country.countCity, GameManage.instance.countCity, GameManage.instance.powerOurCountry,
                GameManage.instance.powerCountryNOTICS, GameManage.instance.areaCountry, country.areaCountry);
            }
        }
        else if (Country.countriesNames.UTOCAR == country.countryName)
        {
            if (GameManage.instance.nameOurCountry.Count.Equals(0))
            {
                CountryManager.instance.ShowEndGamePanel();

            }
            else
            {
                CountryManager.instance.ShowPanelAttack("Start War!", "This Country is owned " +
                country.countryName.ToString() + ". Are you sure? Do you want attack?"
                , country.countCity, GameManage.instance.countCity, GameManage.instance.powerOurCountry,
                GameManage.instance.powerCountryUTOCAR, GameManage.instance.areaCountry, country.areaCountry);
            }
        }
        GameManage.instance.attackedCountry = country.name;
        GameManage.instance.battleHasEnded = false;
        GameManage.instance.battleWon = false;

    }
}

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
        if (country.tribe == Country.tribes.PLAYER)
        {
            hoverColor32 = new Color32(255, 255, 255, 255);
            spriteRenderer.color = hoverColor32;
        } else
        {
            hoverColor32 = new Color32(oldColor32.r, oldColor32.g, oldColor32.b, 255);
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
            CountryManager.instance.ShowPanelAttack("This Country is owned " +
            country.tribe.ToString() + " . Are you sure? Do you want attack?"
            , country.moneyRewards, GameManage.instance.powerCountry, country.powerCountry);
            GameManage.instance.attackedCountry = country.name;
            GameManage.instance.battleHasEnded = false;
            GameManage.instance.battleWon = false;
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountryManager : MonoBehaviour
{
    public static CountryManager instance;

    public GameObject attackPanel;

    public List<GameObject> countries = new List<GameObject>();

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        attackPanel.SetActive(false);
        AddCountryData();

    }

    void AddCountryData()
    {
        GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("Country") as GameObject[];

        foreach(GameObject game in gameObjects)
        {
            countries.Add(game);
        }

        TintCounteries();
    }

    void TintCounteries()
    {
        for(int i = 0; i < countries.Count; i++)
        {
            CountryHandler countryHandler = countries[i].GetComponent<CountryHandler>();

            if(countryHandler.country.tribe == Country.tribes.ENEMY)
            {
                countryHandler.TintedCountry(new Color32(225, 0, 0, 155));

            } else if (countryHandler.country.tribe == Country.tribes.PLAYER)
            {
                countryHandler.TintedCountry(new Color32(0, 75, 0, 155));

            } else if (countryHandler.country.tribe == Country.tribes.FRIEND)
            {
                countryHandler.TintedCountry(new Color32(225, 225, 0, 155));
            }
        }
    }

    public void ShowPanelAttack(string description, int moneyReward)
    {
        attackPanel.SetActive(true);
        AttackPanel gui = attackPanel.GetComponent<AttackPanel>();
        gui.descriptionText.text = description.ToString();
        gui.moneyReward.text = "+ " + moneyReward.ToString() + " $";
    }

    public void DisablePanelAttack()
    {
        attackPanel.SetActive(false);
    }
}

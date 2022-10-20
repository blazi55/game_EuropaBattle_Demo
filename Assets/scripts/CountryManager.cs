using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

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
        for(int i = 0; i < countries.Count; i++)
        {
            CountryHandler countryHandler = countries[i].GetComponent<CountryHandler>();
            if (countryHandler.country.tribe == Country.tribes.PLAYER && GameManage.instance.startMoneyBudget == 0)
            {
                GameManage.instance.startMoneyBudget = countryHandler.country.moneyBudzet;
                print(GameManage.instance.startMoneyReward);
                GameManage.instance.startMoneyReward = countryHandler.country.moneyRewards;
            } else if (countryHandler.country.tribe == Country.tribes.FRIEND && GameManage.instance.powerCountryFriend == 0)
            {
                GameManage.instance.powerCountryFriend = (countryHandler.country.moneyBudzet + countryHandler.country.moneyRewards);
            } else if (countryHandler.country.tribe == Country.tribes.ENEMY && GameManage.instance.powerCountryEnemy == 0)
            {
                GameManage.instance.powerCountryEnemy = (countryHandler.country.moneyBudzet + countryHandler.country.moneyRewards);
            }
        }

        if (GameManage.instance.battleHasEnded && GameManage.instance.battleWon)
        {
            CountryHandler count = GameObject.Find(GameManage.instance.attackedCountry).GetComponent<CountryHandler>();
            count.country.tribe = Country.tribes.PLAYER;
            GameManage.instance.moneyBudget += count.country.moneyBudzet;
            GameManage.instance.moneyReward += count.country.moneyRewards;
            GameManage.instance.powerCountry += count.country.powerCountry;
            TintCounteries();
        }
        GameManage.instance.Saving();
    }

    public void AddCountryData()
    {
        GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("Country") as GameObject[];

        foreach(GameObject game in gameObjects)
        {
            countries.Add(game);
        }

        GameManage.instance.Loading();
        TintCounteries();
    }

    public void TintCounteries()
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

    public void ShowPanelAttack(string description, int moneyReward, int powerOurCountry, int powerAnotherCountry)
    {
        attackPanel.SetActive(true);
        AttackPanel gui = attackPanel.GetComponent<AttackPanel>();
        powerOurCountry = GameManage.instance.powerCountry;
        gui.descriptionText.text = description.ToString();
        gui.moneyReward.text = "+ " + moneyReward.ToString() + " $";
        gui.powerCountry.text = "+ " + powerOurCountry.ToString();
        gui.powerAnotherCountry.text = "+ " + powerAnotherCountry.ToString();
    }

    public void DisablePanelAttack()
    {
        attackPanel.SetActive(false);
    }

    public void ResetGame()
    {
        GameManage.instance.DeleteSavedFile();
        attackPanel.SetActive(false);
    }

    public void StartFight()
    {
        SceneManager.LoadScene("FightSimulator");
    }
}

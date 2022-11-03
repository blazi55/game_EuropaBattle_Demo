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
        ActiveCountries();
        attackPanel.SetActive(false);

        AddCountryData();
        AddGameNamesCountries();

        SetPowerCountry();

        WonBattle();
        LostBattle();

        GameManage.instance.Saving();
    }

    public void SetPowerCountry()
    {
        GameManage.instance.powerCountry = 0;
        GameManage.instance.powerCountryEnemy = 0;
        GameManage.instance.powerCountryFriend = 0;
        GameManage.instance.allCostRegionEnemy = 0;
        GameManage.instance.allCostRegionFriend = 0;
        GameManage.instance.startMoneyReward = 0;
        GameManage.instance.moneyReward = 0;

        if(GameManage.instance.powerCountry == 0 || GameManage.instance.powerCountryEnemy == 0 
            || GameManage.instance.powerCountryFriend == 0)
        for (int i = 0; i < countries.Count; i++)
        {
            CountryHandler countryHandler = countries[i].GetComponent<CountryHandler>();
            if (countryHandler.country.tribe == Country.tribes.PLAYER)
            {
               GameManage.instance.startMoneyBudget += countryHandler.country.moneyBudzet;
               GameManage.instance.startMoneyReward += countryHandler.country.moneyRewards;
            }
            else if (countryHandler.country.tribe == Country.tribes.FRIEND)
            {
                GameManage.instance.powerCountryFriend += (countryHandler.country.moneyBudzet + countryHandler.country.moneyRewards);
                GameManage.instance.allCostRegionFriend += countryHandler.country.moneyRewards;
            }
            else if (countryHandler.country.tribe == Country.tribes.ENEMY)
            {
                GameManage.instance.powerCountryEnemy += (countryHandler.country.moneyBudzet + countryHandler.country.moneyRewards);
                    GameManage.instance.allCostRegionEnemy += countryHandler.country.moneyRewards;
                }
        }
    }

    public void WonBattle()
    {
        if (GameManage.instance.battleHasEnded && GameManage.instance.battleWon)
        {
            CountryHandler count = GameObject.Find(GameManage.instance.attackedCountry).GetComponent<CountryHandler>();
            count.country.tribe = Country.tribes.PLAYER;
            GameManage.instance.moneyBudget += (count.country.moneyBudzet/2);
            GameManage.instance.moneyReward += (count.country.moneyRewards/2);
            GameManage.instance.powerCountry += (count.country.powerCountry/2);
            TintCounteries();
        }
    }

    public void LostBattle()
    {
        if (GameManage.instance.battleHasEnded && GameManage.instance.battleWon == false)
        {
            CountryHandler count = GameObject.Find(GameManage.instance.attackedCountry).GetComponent<CountryHandler>();
            int number = 0;
            if (GameManage.instance.nameCountry.Count > 0)
            {
                number = Random.Range(0, GameManage.instance.nameCountry.Count);
            }
            print(number + "Lost");
            print(GameManage.instance.nameCountry[number] + "Lost");

            if (count.country.tribe == Country.tribes.FRIEND)
            {
                CountryHandler result = GameObject.Find(GameManage.instance.nameCountry[number]).GetComponent<CountryHandler>();
                result.country.tribe = Country.tribes.FRIEND;
                GameManage.instance.nameCountryFriend.Add(GameManage.instance.nameCountry[number]);
                GameManage.instance.nameCountry.Remove(GameManage.instance.nameCountry[number]);
                GameManage.instance.powerCountry -= 20;
                print(GameManage.instance.powerCountry);
                TintCounteries();
            }
            else if (count.country.tribe == Country.tribes.ENEMY)
            {
                CountryHandler result = GameObject.Find(GameManage.instance.nameCountry[number]).GetComponent<CountryHandler>();
                result.country.tribe = Country.tribes.ENEMY;
                GameManage.instance.nameCountryEnemy.Add(GameManage.instance.nameCountry[number]);
                GameManage.instance.nameCountry.Remove(GameManage.instance.nameCountry[number]);
                GameManage.instance.powerCountry -= 20;
                TintCounteries();
            }
        }
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

    public void AddGameNamesCountries()
    {
        HashSet<string> nameEnemyCountry = new HashSet<string>();
        HashSet<string> nameFriendCountry = new HashSet<string>();
        HashSet<string> nameOurCountry = new HashSet<string>();

        for (int i = 0; i < countries.Count; i++)
        {
            CountryHandler countryHandler = countries[i].GetComponent<CountryHandler>();
            if (countryHandler.country.tribe == Country.tribes.PLAYER)
            {
                nameOurCountry.Add(countryHandler.country.name);
            }
            else if (countryHandler.country.tribe == Country.tribes.FRIEND)
            {
                nameFriendCountry.Add(countryHandler.country.name);
            } 
            else
            {
                nameEnemyCountry.Add(countryHandler.country.name);
            }
        }

        List<string> listOurCountry = new List<string>(nameOurCountry);
        List<string> listEnemyCountry = new List<string>(nameEnemyCountry);
        List<string> listFriendCountry = new List<string>(nameFriendCountry);

        GameManage.instance.nameCountry = listOurCountry;
        GameManage.instance.nameCountryEnemy = listEnemyCountry;
        GameManage.instance.nameCountryFriend = listFriendCountry;
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

    public void ShowEndWonPanel()
    {
        DisableCountries();
        attackPanel.SetActive(true);
        AttackPanel gui = attackPanel.GetComponent<AttackPanel>();
        gui.titleText.text = "We have all the world!";
        gui.descriptionText.text = "";
        gui.powerCountry.text = "+ " + GameManage.instance.powerCountry.ToString();
        gui.moneyReward.text = "";
        gui.powerAnotherCountry.text = "+ 0";
    }

    public void ShowEndLostPanel()
    {
        DisableCountries();
        attackPanel.SetActive(true);
        AttackPanel gui = attackPanel.GetComponent<AttackPanel>();
        gui.titleText.text = "We are lost!";
        gui.descriptionText.text = "Our Country is dead";
        gui.powerCountry.text = "";
        gui.moneyReward.text = "";
        gui.powerAnotherCountry.text = "";
    }

    public void ShowPanelAttack(string title, string description, int moneyReward, int powerOurCountry, int powerAnotherCountry)
    {
        DisableCountries();
        attackPanel.SetActive(true);
        AttackPanel gui = attackPanel.GetComponent<AttackPanel>();
        powerOurCountry = GameManage.instance.powerCountry;
        gui.titleText.text = title.ToString();
        gui.descriptionText.text = description.ToString();
        gui.moneyReward.text = "+ " + moneyReward.ToString() + " $";
        gui.powerCountry.text = "+ " + powerOurCountry.ToString();
        gui.powerAnotherCountry.text = "+ " + powerAnotherCountry.ToString();
    }

    public void DisableCountries()
    {
        for (int i = 0; i < countries.Count; i++)
        {
            countries[i].SetActive(false);
        }
    }

    public void ActiveCountries()
    {
        for (int i = 0; i < countries.Count; i++)
        {
            countries[i].SetActive(true);
        }
    }

    public void DisablePanelAttack()
    {
        attackPanel.SetActive(false);
        ActiveCountries();
    }

    public void ResetGame()
    {
        GameManage.instance.DeleteSavedFile();
        attackPanel.SetActive(false);
        GameManage.instance.powerCountry = 660;
        GameManage.instance.startMoneyBudget = 0;
        GameManage.instance.moneyBudget = 660;
        GameManage.instance.allCostRegionEnemy = 0;
        GameManage.instance.allCostRegionFriend = 0;
        ActiveCountries();
    }

    public void StartFight()
    {
        if(GameManage.instance.nameCountry.Count > 0 || GameManage.instance.nameCountry.Count == 8)
        {
            SceneManager.LoadScene("FightSimulator");
        }
    }
}

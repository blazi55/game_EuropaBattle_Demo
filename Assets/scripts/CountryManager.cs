
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;
using UnityEngine.EventSystems;

public class CountryManager : MonoBehaviour
{
    public static CountryManager instance;

    public GameObject attackPanel;
    public GameObject endPanel;
    public GameObject startPanel;

    public List<GameObject> countries = new List<GameObject>();

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        startPanel.SetActive(false);
        attackPanel.SetActive(false);
        endPanel.SetActive(false);

        if (DataManager.Main.Start == false)
        {
           ShowStartPanel();
        }

        AddCountryData();

        WonBattle();

        LostBattle();

        AddGameNamesCountries();

        SetPowerCountry();

        GameManage.instance.Saving();
    }

    public void SetPowerCountry()
    {
        for (int i = 0; i < countries.Count; i++)
        {
            CountryHandler countryHandler = countries[i].GetComponent<CountryHandler>();
            if (countryHandler.country.countryName == Country.countriesNames.RESPUBLICA &&
                GameManage.instance.nameOurCountry.Count == 1)
            {
               GameManage.instance.startAreaCountry = countryHandler.country.areaCountry;
               GameManage.instance.startCountCity = countryHandler.country.countCity;
            }
            else if (countryHandler.country.countryName == Country.countriesNames.PRODIGALIA)
            {
                GameManage.instance.powerCountryORENBERG = (countryHandler.country.areaCountry + (550 * countryHandler.country.countCity));
            }
            else if (countryHandler.country.countryName == Country.countriesNames.VENEREA)
            {
                GameManage.instance.powerCountryPLUTORAN = (countryHandler.country.areaCountry + (750 * countryHandler.country.countCity));
            }
            else if (countryHandler.country.countryName == Country.countriesNames.BIBONIA)
            {
                GameManage.instance.powerCountryPOLLON = (countryHandler.country.areaCountry + (90 * countryHandler.country.countCity));
            }
            else if (countryHandler.country.countryName == Country.countriesNames.LUSORIA)
            {
                GameManage.instance.powerCountryUNERIA = (countryHandler.country.areaCountry + (650 * countryHandler.country.countCity));
            }
            else if (countryHandler.country.countryName == Country.countriesNames.REGNUM)
            {
                GameManage.instance.powerCountryUTOCAR = (countryHandler.country.areaCountry + (565 * countryHandler.country.countCity));
            }
            else if (countryHandler.country.countryName == Country.countriesNames.STOMACHI)
            {
                GameManage.instance.powerCountryNOTICS = (countryHandler.country.areaCountry + (80 * countryHandler.country.countCity));
            }
            else if (countryHandler.country.countryName == Country.countriesNames.MAMONIA)
            {
                GameManage.instance.powerCountryIMBERIAS = (countryHandler.country.areaCountry + (285 * countryHandler.country.countCity));
            }
        }
    }

    public void WonBattle()
    {
        if (GameManage.instance.battleHasEnded && GameManage.instance.battleWon)
        {
            CountryHandler count = GameObject.Find(GameManage.instance.attackedCountry).GetComponent<CountryHandler>();
            string temporaryNameCountry = " (" + count.country.countryName.ToString() + " ) ";
            count.country.countryName = Country.countriesNames.RESPUBLICA;
            GameManage.instance.countCity += count.country.countCity;
            GameManage.instance.areaCountry += count.country.areaCountry;
            DataManager.Main.CountriesCollectionTimes.Add(GameManage.instance.attackedCountry + " " +
                temporaryNameCountry, Time.time);
            print(DataManager.Main.CountriesCollectionTimes);
            TintCounteries();
        }
    }

    public void LostBattle()
    {
        if (GameManage.instance.battleHasEnded && GameManage.instance.battleWon == false)
        {
            CountryHandler count = GameObject.Find(GameManage.instance.attackedCountry).GetComponent<CountryHandler>();
            int number = 0;
            if (GameManage.instance.nameOurCountry.Count > 0)
            {
                number = Random.Range(0, GameManage.instance.nameOurCountry.Count);
            }

            if (count.country.countryName == Country.countriesNames.PRODIGALIA)
            {
                CountryHandler result = GameObject.Find(GameManage.instance.nameOurCountry[number]).GetComponent<CountryHandler>();
                result.country.countryName = Country.countriesNames.PRODIGALIA;
                GameManage.instance.nameCountryORENBERG.Add(GameManage.instance.nameOurCountry[number]);
                GameManage.instance.nameCountryORENBERG.Remove(GameManage.instance.nameOurCountry[number]);
                print(GameManage.instance.powerOurCountry);
                TintCounteries();
            }
            else if (count.country.countryName == Country.countriesNames.VENEREA)
            {
                CountryHandler result = GameObject.Find(GameManage.instance.nameOurCountry[number]).GetComponent<CountryHandler>();
                result.country.countryName = Country.countriesNames.VENEREA;
                GameManage.instance.nameCountryPLUTORAN.Add(GameManage.instance.nameOurCountry[number]);
                GameManage.instance.nameCountryPLUTORAN.Remove(GameManage.instance.nameOurCountry[number]);
                TintCounteries();
            }
            else if (count.country.countryName == Country.countriesNames.REGNUM)
            {
                CountryHandler result = GameObject.Find(GameManage.instance.nameOurCountry[number]).GetComponent<CountryHandler>();
                result.country.countryName = Country.countriesNames.REGNUM;
                GameManage.instance.nameCountryUTOCAR.Add(GameManage.instance.nameOurCountry[number]);
                GameManage.instance.nameCountryUTOCAR.Remove(GameManage.instance.nameOurCountry[number]);
                TintCounteries();
            }
            else if (count.country.countryName == Country.countriesNames.LUSORIA)
            {
                CountryHandler result = GameObject.Find(GameManage.instance.nameOurCountry[number]).GetComponent<CountryHandler>();
                result.country.countryName = Country.countriesNames.LUSORIA;
                GameManage.instance.nameCountryUNERIA.Add(GameManage.instance.nameOurCountry[number]);
                GameManage.instance.nameCountryUNERIA.Remove(GameManage.instance.nameOurCountry[number]);
                TintCounteries();
            }
            else if (count.country.countryName == Country.countriesNames.STOMACHI)
            {
                CountryHandler result = GameObject.Find(GameManage.instance.nameOurCountry[number]).GetComponent<CountryHandler>();
                result.country.countryName = Country.countriesNames.STOMACHI;
                GameManage.instance.nameCountryNOTICS.Add(GameManage.instance.nameOurCountry[number]);
                GameManage.instance.nameCountryNOTICS.Remove(GameManage.instance.nameOurCountry[number]);
                TintCounteries();
            }
            else if (count.country.countryName == Country.countriesNames.BIBONIA)
            {
                CountryHandler result = GameObject.Find(GameManage.instance.nameOurCountry[number]).GetComponent<CountryHandler>();
                result.country.countryName = Country.countriesNames.BIBONIA;
                GameManage.instance.nameCountryPOLLON.Add(GameManage.instance.nameOurCountry[number]);
                GameManage.instance.nameCountryPOLLON.Remove(GameManage.instance.nameOurCountry[number]);
                TintCounteries();
            }
            else if (count.country.countryName == Country.countriesNames.MAMONIA)
            {
                CountryHandler result = GameObject.Find(GameManage.instance.nameOurCountry[number]).GetComponent<CountryHandler>();
                result.country.countryName = Country.countriesNames.MAMONIA;
                GameManage.instance.nameCountryIMBERIAS.Add(GameManage.instance.nameOurCountry[number]);
                GameManage.instance.nameCountryIMBERIAS.Remove(GameManage.instance.nameOurCountry[number]);
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

        HashSet<string> nameCountryORENBERG = new HashSet<string>();
        HashSet<string> nameCountryIMBERIAS = new HashSet<string>();
        HashSet<string> nameCountryUNERIA = new HashSet<string>();
        HashSet<string> nameCountryPOLLON = new HashSet<string>();
        HashSet<string> nameCountryNOTICS = new HashSet<string>();
        HashSet<string> nameOurCountry = new HashSet<string>();
        HashSet<string> nameCountryUTOCAR = new HashSet<string>();
        HashSet<string> nameCountryPLUTORAN = new HashSet<string>();

        for (int i = 0; i < countries.Count; i++)
        {
            CountryHandler countryHandler = countries[i].GetComponent<CountryHandler>();
            if (countryHandler.country.countryName == Country.countriesNames.RESPUBLICA)
            {
                nameOurCountry.Add(countryHandler.country.name);
            }
            else if (countryHandler.country.countryName == Country.countriesNames.PRODIGALIA)
            {
                nameCountryORENBERG.Add(countryHandler.country.name);
            }
            else if (countryHandler.country.countryName == Country.countriesNames.VENEREA)
            {
                nameCountryPLUTORAN.Add(countryHandler.country.name);
            }
            else if (countryHandler.country.countryName == Country.countriesNames.REGNUM)
            {
                nameCountryUTOCAR.Add(countryHandler.country.name);
            }
            else if (countryHandler.country.countryName == Country.countriesNames.LUSORIA)
            {
                nameCountryUNERIA.Add(countryHandler.country.name);
            }
            else if (countryHandler.country.countryName == Country.countriesNames.STOMACHI)
            {
                nameCountryNOTICS.Add(countryHandler.country.name);
            }
            else if (countryHandler.country.countryName == Country.countriesNames.BIBONIA)
            {
                nameCountryPOLLON.Add(countryHandler.country.name);
            }
            else if (countryHandler.country.countryName == Country.countriesNames.MAMONIA)
            {
                nameCountryIMBERIAS.Add(countryHandler.country.name);
            }
        }

        List<string> listOurCountry = new List<string>(nameOurCountry);
        List<string> listCountryORENBERG = new List<string>(nameCountryORENBERG);
        List<string> listCountryIMBERIAS = new List<string>(nameCountryIMBERIAS);
        List<string> listCountryUNERIA = new List<string>(nameCountryUNERIA);
        List<string> listCountryPOLLON = new List<string>(nameCountryPOLLON);
        List<string> listCountryNOTICS = new List<string>(nameCountryNOTICS);
        List<string> listCountryUTOCAR = new List<string>(nameCountryUTOCAR);
        List<string> listCountryPLUTORAN = new List<string>(nameCountryPLUTORAN);

        GameManage.instance.nameOurCountry = listOurCountry;
        GameManage.instance.nameCountryORENBERG = listCountryORENBERG;
        GameManage.instance.nameCountryIMBERIAS = listCountryIMBERIAS;
        GameManage.instance.nameCountryNOTICS = listCountryNOTICS;
        GameManage.instance.nameCountryPLUTORAN = listCountryPLUTORAN;
        GameManage.instance.nameCountryPOLLON = listCountryPOLLON;
        GameManage.instance.nameCountryUTOCAR = listCountryUTOCAR;
        GameManage.instance.nameCountryUNERIA = listCountryUNERIA;
    }

    public void TintCounteries()
    {
        for(int i = 0; i < countries.Count; i++)
        {
            CountryHandler countryHandler = countries[i].GetComponent<CountryHandler>();

            if(countryHandler.country.countryName == Country.countriesNames.VENEREA)
            {
                countryHandler.TintedCountry(new Color32(239, 140, 36, 155));

            } else if (countryHandler.country.countryName == Country.countriesNames.RESPUBLICA)
            {
                countryHandler.TintedCountry(new Color32(70, 75, 0, 155));

            } else if (countryHandler.country.countryName == Country.countriesNames.PRODIGALIA)
            {
                countryHandler.TintedCountry(new Color32(84, 113, 102, 155));
            }
            else if (countryHandler.country.countryName == Country.countriesNames.STOMACHI)
            {
                countryHandler.TintedCountry(new Color32(0, 51, 133, 155));
            }
            else if (countryHandler.country.countryName == Country.countriesNames.REGNUM)
            {
                countryHandler.TintedCountry(new Color32(91, 173, 255, 155));
            }
            else if (countryHandler.country.countryName == Country.countriesNames.MAMONIA)
            {
                countryHandler.TintedCountry(new Color32(210, 153, 0, 155));
            }
            else if (countryHandler.country.countryName == Country.countriesNames.BIBONIA)
            {
                countryHandler.TintedCountry(new Color32(204, 120, 255, 155));
            }
            else if (countryHandler.country.countryName == Country.countriesNames.LUSORIA)
            {
                countryHandler.TintedCountry(new Color32(243, 102, 217, 155));
            }
        }
    }

    public void ShowEndGamePanel()
    {
        DisableCountries();
        endPanel.SetActive(true);

        SummarizePanel gui = endPanel.GetComponent<SummarizePanel>();
        if (GameManage.instance.nameOurCountry.Count == 8)
        {
            gui.description.text = "Victory!";
        } else if (GameManage.instance.nameOurCountry.Count == 0)
        {
            gui.description.text = "You lost!";
        }

        if (DataManager.Main.CountriesCollectionTimes.Count != 0)
        {
            string result = DataManager.Main.CountriesCollectionTimes
            .OrderBy(entry => entry.Value)
            .Select(entry =>
                $"{entry.Key}:\t{System.TimeSpan.FromSeconds(entry.Value):g}")
            .Aggregate((line1, line2) => $"{line1}\n{line2}");

            FileStream file = new FileStream("C:/Users/user/Desktop/Game/Fiction World War/result.txt",
                FileMode.OpenOrCreate);
            StreamWriter stream = new StreamWriter(file);
            stream.Write(result);
            stream.Close();
            file.Close();

            if (result != null)
            {
                gui.resultGame.text = result;
            }
            else
            {
                gui.resultGame.text = "Null";
            }
        }
    }

    public void ShowPanelAttack(string title, int cityOtherCountry,
        int cityOurCountry, int powerOurCountry, int powerAnotherCountry, int areaOurCountry,
        int areaOtherCountry)
    {
        //DisableCountries();
        attackPanel.SetActive(true);
        AttackPanel gui = attackPanel.GetComponent<AttackPanel>();
        powerOurCountry = GameManage.instance.powerOurCountry;
        gui.titleText.text = title.ToString();
        gui.cityOtherCountry.text = "+ " + cityOtherCountry.ToString();
        gui.cityOurCountry.text = "+ " + cityOurCountry.ToString();
        gui.powerCountry.text = "+ " + powerOurCountry.ToString();
        gui.powerAnotherCountry.text = "+ " + powerAnotherCountry.ToString();
        gui.areaOurCountry.text = "+ " + areaOurCountry.ToString();
        gui.areaOtherCountry.text = "+ " + areaOtherCountry.ToString();
    }

    public void ShowStartPanel()
    {
        startPanel.SetActive(true);
        StartPanel gui = startPanel.GetComponent<StartPanel>();
        gui.titleText.text = "Welcome in Fictional World War!";
        gui.startGameText.text = "Start!";
        DataManager.Main.Start = true;
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

    public void DisableStartGame()
    {
        startPanel.SetActive(false);
        DataManager.Main.CountriesCollectionTimes.Add("Start Game ", Time.time);
    }

    public void DisablePanelAttack()
    {
        attackPanel.SetActive(false);
        //ActiveCountries();
    }

    public void ResetGame()
    {
        GameManage.instance.DeleteSavedFile();
        GameManage.instance.areaCountry =  GameManage.instance.startAreaCountry;
        GameManage.instance.countCity = GameManage.instance.startCountCity;
        DataManager.Main.CountriesCollectionTimes.Clear();
        DataManager.Main.Start = false;
    }

    public void StartFight()
    {
        if(GameManage.instance.nameOurCountry.Count > 0 || GameManage.instance.nameOurCountry.Count == 8)
        {
            SceneManager.LoadScene("FightSimulator");
        }
        GameManage.instance.Loading();
    }
}

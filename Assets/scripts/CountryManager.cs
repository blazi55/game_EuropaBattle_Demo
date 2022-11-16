
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;

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
        print("Game Start " +  DataManager.Main.Start);
        startPanel.SetActive(false);
        attackPanel.SetActive(false);
        endPanel.SetActive(false);

        if (DataManager.Main.Start == false)
        {
            ShowStartPanel();
        }

        ActiveCountries();

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
            if (countryHandler.country.countryName == Country.countriesNames.WALAH &&
                GameManage.instance.nameOurCountry.Count == 1)
            {
               GameManage.instance.startAreaCountry = countryHandler.country.areaCountry;
               GameManage.instance.startCountCity = countryHandler.country.countCity;
            }
            else if (countryHandler.country.countryName == Country.countriesNames.ORENBERG)
            {
                GameManage.instance.powerCountryORENBERG = (countryHandler.country.areaCountry + (120 * countryHandler.country.countCity));
            }
            else if (countryHandler.country.countryName == Country.countriesNames.PLUTORAN)
            {
                GameManage.instance.powerCountryPLUTORAN = (countryHandler.country.areaCountry + (120 * countryHandler.country.countCity));
            }
            else if (countryHandler.country.countryName == Country.countriesNames.POLLON)
            {
                GameManage.instance.powerCountryPOLLON = (countryHandler.country.areaCountry + (80 * countryHandler.country.countCity));
            }
            else if (countryHandler.country.countryName == Country.countriesNames.UNERIA)
            {
                GameManage.instance.powerCountryUNERIA = (countryHandler.country.areaCountry + (110 * countryHandler.country.countCity));
            }
            else if (countryHandler.country.countryName == Country.countriesNames.UTOCAR)
            {
                GameManage.instance.powerCountryUTOCAR = (countryHandler.country.areaCountry + (100 * countryHandler.country.countCity));
            }
            else if (countryHandler.country.countryName == Country.countriesNames.NOTICS)
            {
                GameManage.instance.powerCountryNOTICS = (countryHandler.country.areaCountry + (80 * countryHandler.country.countCity));
            }
            else if (countryHandler.country.countryName == Country.countriesNames.IMBERIAS)
            {
                GameManage.instance.powerCountryIMBERIAS = (countryHandler.country.areaCountry + (100 * countryHandler.country.countCity));
            }
        }
    }

    public void WonBattle()
    {
        if (GameManage.instance.battleHasEnded && GameManage.instance.battleWon)
        {
            CountryHandler count = GameObject.Find(GameManage.instance.attackedCountry).GetComponent<CountryHandler>();
            string temporaryNameCountry = " (" + count.country.countryName.ToString() + " ) ";
            count.country.countryName = Country.countriesNames.WALAH;
            GameManage.instance.countCity += count.country.countCity;
            GameManage.instance.areaCountry += count.country.areaCountry;
            GameManage.instance.powerOurCountry += count.country.powerCountry;
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
            print(number + "Lost");
            print(GameManage.instance.nameOurCountry[number] + "Lost");

            if (count.country.countryName == Country.countriesNames.ORENBERG)
            {
                CountryHandler result = GameObject.Find(GameManage.instance.nameOurCountry[number]).GetComponent<CountryHandler>();
                result.country.countryName = Country.countriesNames.ORENBERG;
                GameManage.instance.nameCountryORENBERG.Add(GameManage.instance.nameOurCountry[number]);
                GameManage.instance.nameCountryORENBERG.Remove(GameManage.instance.nameOurCountry[number]);
                print(GameManage.instance.powerOurCountry);
                TintCounteries();
            }
            else if (count.country.countryName == Country.countriesNames.PLUTORAN)
            {
                CountryHandler result = GameObject.Find(GameManage.instance.nameOurCountry[number]).GetComponent<CountryHandler>();
                result.country.countryName = Country.countriesNames.PLUTORAN;
                GameManage.instance.nameCountryPLUTORAN.Add(GameManage.instance.nameOurCountry[number]);
                GameManage.instance.nameCountryPLUTORAN.Remove(GameManage.instance.nameOurCountry[number]);
                TintCounteries();
            }
            else if (count.country.countryName == Country.countriesNames.UTOCAR)
            {
                CountryHandler result = GameObject.Find(GameManage.instance.nameOurCountry[number]).GetComponent<CountryHandler>();
                result.country.countryName = Country.countriesNames.UTOCAR;
                GameManage.instance.nameCountryUTOCAR.Add(GameManage.instance.nameOurCountry[number]);
                GameManage.instance.nameCountryUTOCAR.Remove(GameManage.instance.nameOurCountry[number]);
                TintCounteries();
            }
            else if (count.country.countryName == Country.countriesNames.UNERIA)
            {
                CountryHandler result = GameObject.Find(GameManage.instance.nameOurCountry[number]).GetComponent<CountryHandler>();
                result.country.countryName = Country.countriesNames.UNERIA;
                GameManage.instance.nameCountryUNERIA.Add(GameManage.instance.nameOurCountry[number]);
                GameManage.instance.nameCountryUNERIA.Remove(GameManage.instance.nameOurCountry[number]);
                TintCounteries();
            }
            else if (count.country.countryName == Country.countriesNames.NOTICS)
            {
                CountryHandler result = GameObject.Find(GameManage.instance.nameOurCountry[number]).GetComponent<CountryHandler>();
                result.country.countryName = Country.countriesNames.NOTICS;
                GameManage.instance.nameCountryNOTICS.Add(GameManage.instance.nameOurCountry[number]);
                GameManage.instance.nameCountryNOTICS.Remove(GameManage.instance.nameOurCountry[number]);
                TintCounteries();
            }
            else if (count.country.countryName == Country.countriesNames.POLLON)
            {
                CountryHandler result = GameObject.Find(GameManage.instance.nameOurCountry[number]).GetComponent<CountryHandler>();
                result.country.countryName = Country.countriesNames.POLLON;
                GameManage.instance.nameCountryPOLLON.Add(GameManage.instance.nameOurCountry[number]);
                GameManage.instance.nameCountryPOLLON.Remove(GameManage.instance.nameOurCountry[number]);
                TintCounteries();
            }
            else if (count.country.countryName == Country.countriesNames.IMBERIAS)
            {
                CountryHandler result = GameObject.Find(GameManage.instance.nameOurCountry[number]).GetComponent<CountryHandler>();
                result.country.countryName = Country.countriesNames.IMBERIAS;
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
            if (countryHandler.country.countryName == Country.countriesNames.WALAH)
            {
                nameOurCountry.Add(countryHandler.country.name);
            }
            else if (countryHandler.country.countryName == Country.countriesNames.ORENBERG)
            {
                nameCountryORENBERG.Add(countryHandler.country.name);
            }
            else if (countryHandler.country.countryName == Country.countriesNames.PLUTORAN)
            {
                nameCountryPLUTORAN.Add(countryHandler.country.name);
            }
            else if (countryHandler.country.countryName == Country.countriesNames.UTOCAR)
            {
                nameCountryUTOCAR.Add(countryHandler.country.name);
            }
            else if (countryHandler.country.countryName == Country.countriesNames.UNERIA)
            {
                nameCountryUNERIA.Add(countryHandler.country.name);
            }
            else if (countryHandler.country.countryName == Country.countriesNames.NOTICS)
            {
                nameCountryNOTICS.Add(countryHandler.country.name);
            }
            else if (countryHandler.country.countryName == Country.countriesNames.POLLON)
            {
                nameCountryPOLLON.Add(countryHandler.country.name);
            }
            else if (countryHandler.country.countryName == Country.countriesNames.IMBERIAS)
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

            if(countryHandler.country.countryName == Country.countriesNames.PLUTORAN)
            {
                countryHandler.TintedCountry(new Color32(255, 204, 102, 155));

            } else if (countryHandler.country.countryName == Country.countriesNames.WALAH)
            {
                countryHandler.TintedCountry(new Color32(0, 75, 0, 155));

            } else if (countryHandler.country.countryName == Country.countriesNames.ORENBERG)
            {
                countryHandler.TintedCountry(new Color32(153, 153, 102, 155));
            }
            else if (countryHandler.country.countryName == Country.countriesNames.NOTICS)
            {
                countryHandler.TintedCountry(new Color32(0, 51, 204, 155));
            }
            else if (countryHandler.country.countryName == Country.countriesNames.UTOCAR)
            {
                countryHandler.TintedCountry(new Color32(0, 204, 255, 155));
            }
            else if (countryHandler.country.countryName == Country.countriesNames.IMBERIAS)
            {
                countryHandler.TintedCountry(new Color32(255, 153, 0, 155));
            }
            else if (countryHandler.country.countryName == Country.countriesNames.POLLON)
            {
                countryHandler.TintedCountry(new Color32(204, 51, 255, 155));
            }
            else if (countryHandler.country.countryName == Country.countriesNames.UNERIA)
            {
                countryHandler.TintedCountry(new Color32(153, 102, 255, 155));
            }
        }
    }

    public void ShowStartPanel()
    {
        DisableCountries();
        startPanel.SetActive(true);
        attackPanel.SetActive(false);
        StartPanel gui = startPanel.GetComponent<StartPanel>();
        gui.titleText.text = "Welcome in Typerian War!";
        gui.startGameText.text = "Start!";
        DataManager.Main.Start = true;
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

            FileStream file = new FileStream("C:/Users/user/Desktop/Game/Fiction World War/result.txt", FileMode.OpenOrCreate);
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

    public void ShowPanelAttack(string title, string description, int cityOtherCountry,
        int cityOurCountry, int powerOurCountry, int powerAnotherCountry, int areaOurCountry,
        int areaOtherCountry)
    {
        DisableCountries();
        attackPanel.SetActive(true);
        AttackPanel gui = attackPanel.GetComponent<AttackPanel>();
        powerOurCountry = GameManage.instance.powerOurCountry;
        gui.titleText.text = title.ToString();
        gui.descriptionText.text = description.ToString();
        gui.cityOtherCountry.text = "+ " + cityOtherCountry.ToString();
        gui.cityOurCountry.text = "+ " + cityOurCountry.ToString();
        gui.powerCountry.text = "+ " + powerOurCountry.ToString();
        gui.powerAnotherCountry.text = "+ " + powerAnotherCountry.ToString();
        gui.areaOurCountry.text = "+ " + areaOurCountry.ToString();
        gui.areaOtherCountry.text = "+ " + areaOtherCountry.ToString();
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
        DataManager.Main.CountriesCollectionTimes.Add("Start Game: ", Time.time);
    }

    public void DisablePanelAttack()
    {
        attackPanel.SetActive(false);
        ActiveCountries();
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

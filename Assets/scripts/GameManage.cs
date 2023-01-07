using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine.SceneManagement;

public class GameManage : MonoBehaviour
{
    public static GameManage instance;

    public List<string> nameOurCountry;

    public List<string> nameCountryORENBERG;
    public List<string> nameCountryIMBERIAS;
    public List<string> nameCountryUNERIA;
    public List<string> nameCountryPOLLON;
    public List<string> nameCountryNOTICS;
    public List<string> nameCountryUTOCAR;
    public List<string> nameCountryPLUTORAN;

    public string attackedCountry;

    public string myCountry;

    public bool battleHasEnded;

    public bool battleWon;

    public int countCity;

    public int areaCountry;

    public int powerOurCountry;

    public int startCountCity;

    public int startAreaCountry;

    public int powerCountryORENBERG;
    public int powerCountryIMBERIAS;
    public int powerCountryUNERIA;
    public int powerCountryPOLLON;
    public int powerCountryNOTICS;
    public int powerCountryUTOCAR;
    public int powerCountryPLUTORAN;

    [System.Serializable]
    public class SaveData
    {
        public List<Country> countryList = new List<Country>();
        public int current_countCity;
        public int current_areaCountry;
        public int current_powerCountry;

        public List<string> nameCountryORENBERG;
        public List<string> nameCountryIMBERIAS;
        public List<string> nameCountryUNERIA;
        public List<string> nameCountryPOLLON;
        public List<string> nameCountryNOTICS;
        public List<string> nameCountryUTOCAR;
        public List<string> nameCountryPLUTORAN;
    }
    
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        } else if (instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    public void Saving()
    {
        SaveData saveData = new SaveData();
        for (int i = 0; i < CountryManager.instance.countries.Count; i++)
        {
            saveData.countryList
                .Add(CountryManager.instance.countries[i].GetComponent<CountryHandler>().country);
        }

        saveData.current_countCity = countCity;
        saveData.current_areaCountry = areaCountry;
        powerOurCountry = (areaCountry + (20 * countCity));
        saveData.current_powerCountry = powerOurCountry;

        BinaryFormatter binaryFormatter = new BinaryFormatter();
        FileStream fileStream = new FileStream(Application.persistentDataPath + "/SavedFile.octo", FileMode.Create);
        print(Application.persistentDataPath + " / SavedFile.octo");
        binaryFormatter.Serialize(fileStream, saveData);
        fileStream.Close();
        print("Saved Game!");
    }

    public void Loading()
    {
        if(File.Exists(Application.persistentDataPath + "/SavedFile.octo"))
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            FileStream fileStream = new FileStream(Application.persistentDataPath + "/SavedFile.octo", FileMode.Open);
            SaveData saveData = (SaveData)binaryFormatter.Deserialize(fileStream);
            fileStream.Close();

            for(int i = 0; i < saveData.countryList.Count; i++)
            {
                for(int j = 0; j < CountryManager.instance.countries.Count; j++)
                {
                    if (saveData.countryList[i].name == CountryManager.instance.countries[j].GetComponent<CountryHandler>().country.name)
                    {
                        CountryManager.instance.countries[i].GetComponent<CountryHandler>().country = saveData.countryList[i];
                    }
                }
            }

            countCity = saveData.current_countCity;
            areaCountry = saveData.current_areaCountry;
            powerOurCountry = saveData.current_powerCountry;

            CountryManager.instance.TintCounteries();
            print("Loaded");
        }
        else
        {
            print("No saved game :(");
        }
    }

    public void DeleteSavedFile()
    {
        if (File.Exists(Application.persistentDataPath + "/SavedFile.octo"))
        {
            File.Delete(Application.persistentDataPath + "/SavedFile.octo");
            Application.Quit();
            print("Deleted Saved File");
        }
    }
}

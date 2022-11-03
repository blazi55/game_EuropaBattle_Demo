using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine.SceneManagement;

public class GameManage : MonoBehaviour
{
    public static GameManage instance;

    public List<string> nameCountry;

    public List<string> nameCountryEnemy;

    public List<string> nameCountryFriend;

    public string attackedCountry;

    public string myCountry;

    public bool battleHasEnded;

    public bool battleWon;

    public int moneyReward;

    public int moneyBudget;

    public int powerCountry;

    public int startMoneyBudget;

    public int startMoneyReward;

    public int powerCountryFriend;

    public int powerCountryEnemy;

    public int allCostRegionEnemy;

    public int allCostRegionFriend;

    [System.Serializable]
    public class SaveData
    {
        public List<Country> countryList = new List<Country>();
        public int current_moneyReward;
        public int current_moneyBudget;
        public int current_powerCountry;

        public List<string> nameCountry;
        public List<string> nameCountryEnemy;
        public List<string> nameCountryFriend;
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

        saveData.current_moneyBudget = moneyBudget;
        saveData.current_moneyReward = moneyReward;
        powerCountry = (moneyReward + moneyBudget);
        saveData.current_powerCountry = powerCountry;

        BinaryFormatter binaryFormatter = new BinaryFormatter();
        FileStream fileStream = new FileStream(Application.persistentDataPath + "/SavedFile.octo", FileMode.Create);

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

            moneyBudget = saveData.current_moneyBudget;
            moneyReward = saveData.current_moneyReward;
            powerCountry = saveData.current_powerCountry;

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
            Loading();
            moneyBudget = startMoneyBudget;
            moneyReward = startMoneyReward;
            powerCountry = (moneyBudget + moneyReward);

            File.Delete(Application.persistentDataPath + "/SavedFile.octo");
            print("Deleted Saved File");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class GameManage : MonoBehaviour
{
    public static GameManage instance;

    public string attackedCountry;

    public bool battleHasEnded;

    public bool battleWon;

    public int money;
    public int budget;

    [System.Serializable]
    public class SaveData
    {
        public List<Country> countryList = new List<Country>();
        public int current_money;
        public int current_budget;
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

        saveData.current_budget = budget;
        saveData.current_money = money;

        BinaryFormatter binaryFormatter = new BinaryFormatter();
        FileStream fileStream = new FileStream(Application.persistentDataPath + "/SaveFile.octo", FileMode.Create);

        binaryFormatter.Serialize(fileStream, saveData);
        fileStream.Close();
        print("Saved Game!");
    }

    public void Loading()
    {
        if(File.Exists(Application.persistentDataPath + "/SaveFile.octo"))
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
        }
    }
}

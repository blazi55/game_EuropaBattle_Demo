using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class FightSimulator : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Fight());
    }

    IEnumerator Fight()
    {
        yield return new WaitForSeconds(0);

        print(GameManage.instance.powerOurCountry);

        for (int i = 0; i < GameManage.instance.nameCountryIMBERIAS.Count; i++)
        {
            if (GameManage.instance.attackedCountry.Equals(GameManage.instance.nameCountryIMBERIAS[i]))
            {
                if (GameManage.instance.powerCountryIMBERIAS > GameManage.instance.powerOurCountry)
                {
                    GameManage.instance.battleWon = false;
                }
                else
                {
                    GameManage.instance.battleWon = true;
                }
            }
        }
        for (int i = 0; i < GameManage.instance.nameCountryORENBERG.Count; i++)
        {
            if (GameManage.instance.attackedCountry.Equals(GameManage.instance.nameCountryORENBERG[i]))
            {
                if (GameManage.instance.powerCountryORENBERG > GameManage.instance.powerOurCountry)
                {
                    GameManage.instance.battleWon = false;
                }
                else
                {
                    GameManage.instance.battleWon = true;
                }
            }
        }
        for (int i = 0; i < GameManage.instance.nameCountryNOTICS.Count; i++)
        {
            if (GameManage.instance.attackedCountry.Equals(GameManage.instance.nameCountryNOTICS[i]))
            {
                if (GameManage.instance.powerCountryNOTICS > GameManage.instance.powerOurCountry)
                {
                    GameManage.instance.battleWon = false;
                }
                else
                {
                    GameManage.instance.battleWon = true;
                }
            }
        }
        for (int i = 0; i < GameManage.instance.nameCountryPLUTORAN.Count; i++)
        {
            if (GameManage.instance.attackedCountry.Equals(GameManage.instance.nameCountryPLUTORAN[i]))
            {
                if (GameManage.instance.powerCountryPLUTORAN > GameManage.instance.powerOurCountry)
                {
                    GameManage.instance.battleWon = false;
                }
                else
                {
                    GameManage.instance.battleWon = true;
                }
            }
        }
        for (int i = 0; i < GameManage.instance.nameCountryPOLLON.Count; i++)
        {
            if (GameManage.instance.attackedCountry.Equals(GameManage.instance.nameCountryPOLLON[i]))
            {
                if (GameManage.instance.powerCountryPOLLON > GameManage.instance.powerOurCountry)
                {
                    GameManage.instance.battleWon = false;
                }
                else
                {
                    GameManage.instance.battleWon = true;
                }
            }
        }
        for (int i = 0; i < GameManage.instance.nameCountryUNERIA.Count; i++)
        {
            if (GameManage.instance.attackedCountry.Equals(GameManage.instance.nameCountryUNERIA[i]))
            {
                if (GameManage.instance.powerCountryUNERIA > GameManage.instance.powerOurCountry)
                {
                    GameManage.instance.battleWon = false;
                }
                else
                {
                    GameManage.instance.battleWon = true;
                }
            }
        }
        for (int i = 0; i < GameManage.instance.nameCountryUTOCAR.Count; i++)
        {
            if (GameManage.instance.attackedCountry.Equals(GameManage.instance.nameCountryUTOCAR[i]))
            {
                if (GameManage.instance.powerCountryUTOCAR > GameManage.instance.powerOurCountry)
                {
                    GameManage.instance.battleWon = false;
                }
                else
                {
                    GameManage.instance.battleWon = true;
                }
            }
        }

        GameManage.instance.battleHasEnded = true;
        SceneManager.LoadScene("SampleScene");
    }
}

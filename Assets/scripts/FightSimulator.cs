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

        print(GameManage.instance.powerCountry);
        print(GameManage.instance.powerCountryFriend);

        if (GameManage.instance.attackedCountry.Equals(GameManage.instance.nameCountryEnemy)) 
        {
           if(GameManage.instance.powerCountryEnemy >= GameManage.instance.powerCountry)
           {
                GameManage.instance.battleWon = false;
           } else
           {
                GameManage.instance.battleWon = true;
           }
        }
        else if (GameManage.instance.attackedCountry.Equals(GameManage.instance.nameCountryFriend))
        {
            if (GameManage.instance.powerCountryFriend >= GameManage.instance.powerCountry)
            {
                GameManage.instance.battleWon = false;
            }
            else
            {
                GameManage.instance.battleWon = true;
            }
        }

        GameManage.instance.battleHasEnded = true;
        SceneManager.LoadScene("SampleScene");
    }
}

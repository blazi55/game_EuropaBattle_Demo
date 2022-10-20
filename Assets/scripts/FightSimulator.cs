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
        int powerCountryFriend = 0;
        int powerCountryEnemy = 0;

        print(GameManage.instance.attackedCountry);

        //int number = Random.Range(0, 5);
        if (GameManage.instance.attackedCountry.Equals("country_3"))
        {
            powerCountryEnemy = GameManage.instance.moneyBudget;
        }

        if (GameManage.instance.attackedCountry.Equals("country_2"))
        {
            powerCountryFriend = GameManage.instance.moneyBudget;
        }

        print(powerCountryFriend);
        print(powerCountryEnemy);

        if (GameManage.instance.powerCountry <= powerCountryFriend)
        {
          GameManage.instance.battleWon = false;
        }
        else
        {
          GameManage.instance.battleWon = true;
        }

        GameManage.instance.battleHasEnded = true;
        SceneManager.LoadScene("SampleScene");
    }
}

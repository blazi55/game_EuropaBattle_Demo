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
        int number = Random.Range(0, 2);

        print(GameManage.instance.powerCountry);
        print(GameManage.instance.powerCountryFriend);
        print("Cost: " + GameManage.instance.allCostRegionEnemy);
        print("Cost: " + GameManage.instance.allCostRegionFriend);

        for (int i = 0; i < GameManage.instance.nameCountryEnemy.Count; i++)
        {
            if (GameManage.instance.attackedCountry.Equals(GameManage.instance.nameCountryEnemy[i]))
            {
                if ((GameManage.instance.powerCountryEnemy - GameManage.instance.allCostRegionEnemy) > GameManage.instance.powerCountry)
                {
                    GameManage.instance.battleWon = false;
                }
                else if ((GameManage.instance.powerCountryEnemy - GameManage.instance.allCostRegionEnemy) == GameManage.instance.powerCountry)
                {
                    if (number == 2)
                    {
                        GameManage.instance.battleWon = true;
                    }
                    else
                    {
                        GameManage.instance.battleWon = false;
                    }
                }
                else
                {
                    GameManage.instance.battleWon = true;
                }
            }
        }
        for (int i = 0; i < GameManage.instance.nameCountryFriend.Count; i++)
        {
            if (GameManage.instance.attackedCountry.Equals(GameManage.instance.nameCountryFriend[i]))
            {
                if ((GameManage.instance.powerCountryFriend - GameManage.instance.allCostRegionFriend) > GameManage.instance.powerCountry)
                {
                    GameManage.instance.battleWon = false;
                }
                else if ((GameManage.instance.powerCountryFriend - GameManage.instance.allCostRegionFriend) == GameManage.instance.powerCountry)
                {
                    if (number >= 1)
                    {
                        GameManage.instance.battleWon = false;
                    }
                    else if (number == 0)
                    {
                        GameManage.instance.battleWon = true;
                    }
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

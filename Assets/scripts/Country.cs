using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Country
{
    public string name;
    public enum tribes
    {
        ENEMY,
        FRIEND,
        PLAYER
    }

    public tribes tribe;

    public int moneyBudzet;

    public int moneyRewards;
}

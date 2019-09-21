using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Stat {

    [SerializeField]
    private int baseValue;

    public int GetValue()
    {
        return baseValue;
    }

    public void SetValue(int damage)
    {
        baseValue = damage;
    }
	
}

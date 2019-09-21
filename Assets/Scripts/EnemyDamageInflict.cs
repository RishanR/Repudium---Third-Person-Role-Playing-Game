using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterStats))]
public class EnemyDamageInflict : MonoBehaviour {

    PlayerManager playerManager;
    CharacterStats myStats;
    CharacterCombat combat;
    void Start()
    {
        playerManager = PlayerManager.instance;
        myStats = GetComponent<CharacterStats>();
        
    }
    public void InflictDamage()
    {
        if (gameObject.tag == "Player")
        {
            combat = playerManager.enemy.GetComponent<CharacterCombat>();
        }
        else
        {
            combat = playerManager.player.GetComponent<CharacterCombat>();
        }
        
        if (combat != null)
        {
            combat.Attack(myStats);
        }
    }
}

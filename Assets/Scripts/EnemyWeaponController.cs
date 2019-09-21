using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

[RequireComponent(typeof(CharacterStats))]
public class EnemyWeaponController : MonoBehaviour {

    [HideInInspector] EnemyAnimationEvents enemyTrigger;
    [HideInInspector] EnemyController enemyController;
    [HideInInspector] CharacterStats myStats;

    public GameObject player;
    System.Random rand = new System.Random();
    PlayerManager playerManager;

    void Awake()
    {
        enemyTrigger = player.GetComponentInChildren<EnemyAnimationEvents>();
        playerManager = GameObject.Find("GameManager").GetComponent<PlayerManager>();
        myStats = player.GetComponent<CharacterStats>();
        enemyController = player.GetComponent<EnemyController>();
    }
    
    void OnTriggerStay(Collider colEnter)
    {
        if (colEnter.gameObject.tag == "Player")
        {
            enemyController.canDamage = true;
        }
        playerManager.SetCollision(colEnter.gameObject, player);
    }
    
    void OnTriggerExit(Collider colExit)
    {
        if (enemyController.canExit == false)
            enemyController.canDamage = false;
    }
    
}


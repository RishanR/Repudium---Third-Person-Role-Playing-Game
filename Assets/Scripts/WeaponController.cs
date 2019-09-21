using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

[RequireComponent(typeof(CharacterStats))]
public class WeaponController : MonoBehaviour {

    [HideInInspector] RPGCharacterAnims.RPGCharacterControllerFREE rpgCharacterController;
    [HideInInspector] CharacterStats myStats;

    public GameObject player;
    System.Random rand = new System.Random();
    PlayerManager playerManager;
    public int lowDamage = 5;
    public int highDamage = 10;

    void Awake()
    {
        rpgCharacterController = player.GetComponent<RPGCharacterAnims.RPGCharacterControllerFREE>();
        playerManager = GameObject.Find("GameManager").GetComponent<PlayerManager>();
        myStats = player.GetComponent<CharacterStats>();
    }

    void Update()
    {
        if (rpgCharacterController.weapon == RPGCharacterAnims.Weapon.TWOHANDSWORD)
        {
            lowDamage = 30;
            highDamage = 35;
        }
        else
        {
            lowDamage = 20;
            highDamage = 25;
        }
    }
    void OnTriggerStay(Collider colEnter)
    {
        myStats.damage.SetValue(rand.Next(lowDamage, highDamage));
        if (colEnter.gameObject.tag == "Enemy")
        {
            rpgCharacterController.canDamage = true;
        }
        playerManager.SetCollision(colEnter.gameObject, player);
    }
    
    void OnTriggerExit(Collider colExit)
    {
        if (rpgCharacterController.canExit == false)
            rpgCharacterController.canDamage = false;
    }
    
}


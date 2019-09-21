using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : CharacterStats {
    Animator animator;
    RPGCharacterAnims.RPGCharacterControllerFREE rpgCharacterController;

    public void Die()
    {
        rpgCharacterController = gameObject.GetComponent<RPGCharacterAnims.RPGCharacterControllerFREE>();
        animator = gameObject.GetComponent<Animator>();
        gameObject.GetComponent<RPGCharacterAnims.RPGCharacterInputControllerFREE>().enabled = false;
        rpgCharacterController.movementAnimationSpeed = 0f;
        animator.SetTrigger("Death1Trigger");
    }
}

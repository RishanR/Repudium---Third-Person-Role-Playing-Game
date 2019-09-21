using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : CharacterStats {

    Animator animator;

    public void Die()
    {
        animator = gameObject.GetComponentInChildren<Animator>();
        animator.SetTrigger("death");
    }
}

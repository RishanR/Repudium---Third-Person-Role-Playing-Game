using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemonBoss : MonoBehaviour {

    // Use this for initialization
    Animator animator;
    CharacterCombat combat;
    public GameObject player;
    EnemyStats enemyStats;
    int numAttacks = 0;
    int stunAttacks = 0;
    public int previousHealth;
	void Start () {
        animator = gameObject.GetComponent<Animator>();
        enemyStats = player.GetComponent<EnemyStats>();
	}
	
	// Update is called once per frame
	void Update () {
		if (numAttacks == 10)
        {
            animator.SetTrigger("stunned");
            previousHealth = enemyStats.currentHealth;
            numAttacks = 0;
        }
        if ((enemyStats.currentHealth < previousHealth) && animator.GetCurrentAnimatorStateInfo(0).IsName("Stunned"))
        {
            animator.Play("GetHit");
            previousHealth = enemyStats.currentHealth;
            stunAttacks++;
            if (stunAttacks >= 3)
            {
                animator.SetTrigger("attack");
                stunAttacks = 0;
            }
        }
	}

    public void Hit()
    {
        numAttacks++;
        Debug.Log(numAttacks);
    }

    public void GetHit()
    {
        animator.SetTrigger("stunned");
    }
}

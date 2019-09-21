using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimationEvents : MonoBehaviour {
    public CharacterStats targetStatsChild;
    public CharacterCombat combatChild;
    public EnemyController enemyController;
    public EnemyDamageInflict damageInflict;
    public GameObject player;

    void Awake()
    {
        enemyController = player.GetComponent<EnemyController>();
        damageInflict = player.GetComponent<EnemyDamageInflict>();
    }
    public void Hit()
    {
        if (enemyController.canDamage == true)
        {
            damageInflict.InflictDamage();
            enemyController.canExit = false;
        }
    }

    public void Kill()
    {
        Destroy(player);
    }
}

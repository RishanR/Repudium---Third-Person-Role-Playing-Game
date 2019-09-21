using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour {

    #region Singleton

    public static PlayerManager instance;

    void Awake()
    {
        instance = this;
    }
    #endregion

    public GameObject player;
    public GameObject enemy;
    public RPGCharacterAnims.RPGCharacterControllerFREE rpgCharacterController;
    public EnemyAnimationEvents enemyTrigger;

    void Start()
    {
        rpgCharacterController = player.GetComponent<RPGCharacterAnims.RPGCharacterControllerFREE>();

    }
    public void SetCollision(GameObject collideObject, GameObject original)
    {
            
        if (collideObject.tag == "Enemy" && original.tag == "Player")
        {
            enemy = collideObject;
            rpgCharacterController.damageInflict = enemy.GetComponent<EnemyDamageInflict>();
        }
        else if(collideObject.tag == "Player")
        {
            enemy = original;
            enemyTrigger = enemy.GetComponentInChildren<EnemyAnimationEvents>();
            enemyTrigger.damageInflict = player.GetComponent<EnemyDamageInflict>();
        }
    }

    public void KillPlayer()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
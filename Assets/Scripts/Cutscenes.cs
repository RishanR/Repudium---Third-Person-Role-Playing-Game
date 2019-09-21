using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cutscenes : MonoBehaviour {

    // Use this for initialization
    EnemyController enemyController;
    public GameObject enemy;
    public float Radius = 10f;
	void Start () {
        enemyController = enemy.GetComponent<EnemyController>();
	}
	
	// Update is called once per frame
	void Update () {
       /* if (enemyController.distance <= Radius)
        {
            Debug.Log("Working!");
        }
        */
	}
}

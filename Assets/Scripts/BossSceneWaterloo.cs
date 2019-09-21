using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossSceneWaterloo : MonoBehaviour {

    [SerializeField] private string loadLevel;

    void OnTriggerEnter(Collider theObject)
    {
        if (theObject.CompareTag("Player") && GameObject.Find("Lancer - Final Boss (2)") == null)
        {
            SceneManager.LoadScene(loadLevel);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossSceneChange : MonoBehaviour {

    [SerializeField] private string loadLevel;

    void OnTriggerEnter(Collider theObject)
    {
        if (theObject.CompareTag("Player") && GameObject.Find("Lancer - Final Boss (1)") == null)
        {
            SceneManager.LoadScene(loadLevel);
        }
    }
}

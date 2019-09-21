using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour {

    [SerializeField] private string loadLevel;

	void OnTriggerEnter(Collider theObject)
    {
        if (theObject.CompareTag("Player"))
        {
            SceneManager.LoadScene(loadLevel);
        }
    }
}

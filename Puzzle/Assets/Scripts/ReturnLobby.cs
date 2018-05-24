using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnLobby : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Frozy" || other.tag == "Sparky")
        {
            FindObjectOfType<AudioManager>().Stop("Lvl1");
            SceneManager.LoadScene(3);
        }
    }
}
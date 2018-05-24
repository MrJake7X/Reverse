using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLvl : MonoBehaviour
{
    public int numScene;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Frozy" || other.tag == "Sparky")
        {
            Debug.Log(numScene);

            SceneManager.LoadScene(numScene);

            FindObjectOfType<AudioManager>().Stop("Intro");
        }
    }
}
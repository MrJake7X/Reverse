using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HUD : MonoBehaviour {

    private void Start()
    {
        FindObjectOfType<AudioManager>().Play("Menu");
    }

    public void LoadLvl()
    {
        SceneManager.LoadScene(1);
        FindObjectOfType<AudioManager>().Stop("Menu");
    }

    public void Exit()
    {
        Application.Quit();
    }
}
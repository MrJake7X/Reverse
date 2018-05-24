using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HUDpause : MonoBehaviour {

    private GameManager manager;

	void Start ()
    {
        manager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }
    
    public void Resume()
    {
        manager.pause = false;
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }
}
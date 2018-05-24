using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SavePosition : MonoBehaviour {

    private GameManager manager;

    public Vector3 offset;

    public bool setActive;

    private void Awake()
    {
        if (GameObject.FindGameObjectsWithTag("Position").Length > 1)
        {
            Destroy(this.gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start ()
    {
        manager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    private void Update ()
    {
		if(setActive)
        {
            LoadPosition();

            setActive = false;
        }
	}

    public void LoadPosition()
    {
        manager.sparky.transform.position = transform.position + offset;

        manager.frozy.transform.position = transform.position;
    }
}
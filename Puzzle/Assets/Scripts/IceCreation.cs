using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceCreation : MonoBehaviour {

    public GameObject iceCubePrefab;

    public Vector3 offset;

    private bool inLocal = true;

    private GameManager manager;

    public GameObject icePartPrefab;

	void Start ()
    {
        manager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    void Update ()
    {
        if (manager.cameraFrozyOn)
        {
            if (Input.GetKeyDown(KeyCode.F) || Input.GetKeyDown(KeyCode.JoystickButton3))
            {
                    GameObject obj = GameObject.FindGameObjectWithTag("IceCube");
                    Destroy(obj);
                    Spawn();
            }
        }
    }

    public void Spawn()
    {
        GameObject iceCube = Instantiate(iceCubePrefab, transform.position, Quaternion.identity);
        GameObject icePart = Instantiate(icePartPrefab, transform.position + offset, Quaternion.identity);
        FindObjectOfType<AudioManager>().Play("iceBlock");
    }
}
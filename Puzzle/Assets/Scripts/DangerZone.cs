using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DangerZone : MonoBehaviour {

    private SphereCollider dangerCollider;

    private GameManager manager;

	void Start ()
    {
        dangerCollider = GetComponent<SphereCollider>();

        manager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Sparky" && manager.cameraFrozyOn)
        {
            Debug.Log("ESTA EL FUEGO CERCA");
        }
        if (other.tag == "Frozy" && manager.cameraSparkyOn)
        {
            Debug.Log("ESTA EL HIELO CERCA");
        }
    }
}

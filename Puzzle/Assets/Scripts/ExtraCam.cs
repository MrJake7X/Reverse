using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtraCam : MonoBehaviour {

    public bool extraCamActive;

    public bool sparkyIn;

    public bool frozyIn;

    //public bool isOnZone;

    public GameObject cam;

	void Start ()
    {
        
    }
	
	void Update ()
    {
        cam.SetActive(extraCamActive);
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Frozy")
        {
            frozyIn = true;

            //isOnZone = true;
            //extraCamActive = true;
        }
        if (other.tag == "Sparky")
        {
            sparkyIn = true;

            //isOnZone = true;
            //extraCamActive = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Frozy")
        {
            frozyIn = false;

            //isOnZone = false;
            //extraCamActive = false;
        }
        if (other.tag == "Sparky")
        {
            sparkyIn = false;

            //isOnZone = false;
            //extraCamActive = false;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PresionBoton : MonoBehaviour {

    private Animator animBttn;

    public Animator animReja;

	void Start ()
    {
        animBttn = GetComponent<Animator>();
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Sparky" || other.tag == "Frozy")
        {
            animBttn.SetTrigger("onBttn");

            animReja.SetTrigger("rejaDown");

            FindObjectOfType<AudioManager>().Play("reja");
        }
    }
}
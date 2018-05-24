using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gem : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Sparky" || other.tag == "Frozy")
        {
            FindObjectOfType<AudioManager>().Play("take");

            Destroy(gameObject);
        }
    }
}
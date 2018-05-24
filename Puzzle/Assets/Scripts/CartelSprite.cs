using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CartelSprite : MonoBehaviour {

    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        anim.SetTrigger("Start");
    }

    private void OnTriggerExit(Collider other)
    {
        anim.SetTrigger("Exit");
    }
}
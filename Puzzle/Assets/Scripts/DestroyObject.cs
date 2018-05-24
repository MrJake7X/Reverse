using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour {

    public GameObject obj;

    public GameObject firePartPrefab;

    public Vector3 offset;

    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Sparky")
        {
            Debug.Log("PUEDES MATARLO");

            if(Input.GetKeyDown(KeyCode.F) || Input.GetKeyDown(KeyCode.JoystickButton3))
            {
                GameObject firePart = Instantiate(firePartPrefab, transform.position + offset, Quaternion.identity);
                FindObjectOfType<AudioManager>().Play("quemar");
                Destroy(obj);
            }
        }
    }
}
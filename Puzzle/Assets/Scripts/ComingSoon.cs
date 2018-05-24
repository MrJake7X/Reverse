using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ComingSoon : MonoBehaviour {

    public Image sprite;

    public Image sprite2;

    private float alpha = 0.2f;

    private float contador = 0;

	void Update ()
    {
        contador += Time.deltaTime;

        if (contador >= 2)
        {
            sprite.color -= new Color(0, 0, 0, alpha) * Time.deltaTime;
            sprite2.color -= new Color(0, 0, 0, alpha) * Time.deltaTime;

            if (sprite.color.a <= 0)
            {
                gameObject.SetActive(false);
            }
        }
	}
}
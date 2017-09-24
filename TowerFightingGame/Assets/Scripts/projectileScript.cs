using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectileScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		
	}

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.collider.tag == "Floor")
        {
            Destroy(gameObject);
        }
        if (col.gameObject.name == "Projectile1(Clone)" || col.gameObject.name == "Projectile2(Clone)")
        {
            Destroy(col.gameObject);
        }
    }
}

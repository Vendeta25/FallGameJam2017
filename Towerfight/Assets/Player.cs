using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public float health;

	// Use this for initialization
	void Start () {
		health = 1f;
	}

	public float getHealth()
	{
		return health;
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetAxis("Fire1") == 1)
        {
            health -= .05f;
        }
	}
}

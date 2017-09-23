using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack1 : MonoBehaviour {
    SpriteRenderer sr;
    Collider damageCol;
    public bool isAttacking;
    public Sprite nPunch;
    public Sprite punch;
	// Use this for initialization
	void Start () {
        sr = gameObject.GetComponent<SpriteRenderer>();
        isAttacking = false;
        gameObject.GetComponent<PolygonCollider2D>().enabled = false;
    }
	
	// Update is called once per frame
	void Update () {

        

        if (Input.GetKeyDown("e"))
        {
            //Debug.Log("PUNCH");
            gameObject.GetComponent<PolygonCollider2D>().enabled = true;
            sr.sprite = punch;
            StartCoroutine(waitForTime(.25f, sr));
            
        }
	}

    IEnumerator waitForTime(float x, SpriteRenderer sr)
    {
        
        yield return new WaitForSeconds(x);
        //Debug.Log("waited");
        gameObject.GetComponent<PolygonCollider2D>().enabled = false;
        sr.sprite = nPunch;
    }
}

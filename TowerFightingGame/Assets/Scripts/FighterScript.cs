using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FighterScript : MonoBehaviour {
    Rigidbody2D rb;
    //public int flashdelay = 10;
    int flashcounter=0;
    float vertical;
    public float health;
    bool jmpKey;
    float jmpForce;
    float jmpDuration;
    public float jumpForce = .1f;
    public float jumpDuration = .1f;
    bool onFloor;
    bool toggle = true;
    bool flashing;
    SpriteRenderer sr;
    public string Sprite;
    
    GameObject enemy;
    Vector3 ePos;
    public float direction;
	// Use this for initialization
	void Start () {
        gameObject.AddComponent<PolygonCollider2D>();
        foreach (GameObject e in Object.FindObjectsOfType<GameObject>())
        {
            if(e.tag == "Player2")
            {
                enemy = e;
            }
        }
        
        health = 1;
        rb = GetComponent<Rigidbody2D>();
        sr = gameObject.GetComponent<SpriteRenderer>();
    }

    void FixedUpdate()
    {
        ePos = enemy.transform.position;
        direction = gameObject.transform.position.x - ePos.x;
        if(direction > 0)
            
        {
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x) *-1 , transform.localScale.y, transform.localScale.z);
        }
        else
        {
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }
        if (flashing)
        {
            //Debug.Log(flashcounter);
            if (flashcounter < 50)
            {
            
                toggle = !toggle;
                if (toggle)
                {
                    //Debug.Log("flash on");
                    sr.enabled = true;
                }
                else
                {
                    //Debug.Log("flash off");
                    sr.enabled = false;
                }
            flashcounter++;
            }
            else
            {
                flashcounter = 0;
                flashing = !flashing;
            }

    }
        if (Input.GetKeyDown("r"))
        {
            transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
        }

        if (Input.GetKeyDown("w") && onFloor && !GameObject.Find("Player1Arms").GetComponent<Attack1>().shooting)
        {
            jmpDuration = 0;
            jmpForce = 0;
            jmpDuration += Time.deltaTime;
            jmpForce += Time.deltaTime * jumpForce;
            if (jmpDuration < jumpDuration)
            {
           // Debug.Log("Jump jmpForce Report: " +  jmpForce);
                rb.velocity = new Vector2(rb.velocity.x, jmpForce);
                onFloor = false;
            }


        }
            var x = Input.GetAxis("Horizontal") * Time.deltaTime * 30.0f;

        if (!GameObject.Find("Player1Arms").GetComponent<Attack1>().shooting)
        {
        transform.Translate(x, 0, 0);
        }

        
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.collider.tag == "Floor")
        {
            onFloor = true;
        }
        if(col.collider.tag == "P2Attack" && !flashing)
        {
            health -= .2f;
            flashing = true;
        }
        if(col.gameObject.name == "Projectile2(Clone)")
        {
            Destroy(col.gameObject);
        }
    }

   
}

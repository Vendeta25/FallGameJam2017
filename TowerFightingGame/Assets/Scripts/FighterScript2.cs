using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FighterScript2 : MonoBehaviour
{
    Rigidbody2D rb;
    float vertical;
    bool flashing = false;
    int flashcounter;
    SpriteRenderer sr;
    bool toggle;
    public float health;
    bool jmpKey;
    float jmpForce;
    float jmpDuration;
    public float jumpForce = .2f;
    public float jumpDuration = .1f;
    bool onFloor;
    Vector3 ePos;
    GameObject enemy;
    public float direction;
    // Use this for initialization
    void Start()
    {
        gameObject.AddComponent<PolygonCollider2D>();
        foreach (GameObject e in Object.FindObjectsOfType<GameObject>())
        {
            if (e.tag == "Player1")
            {
                enemy = e;
            }
        }
        flashing = false;
        sr = gameObject.GetComponent<SpriteRenderer>();
        health = 1;
        rb = GetComponent<Rigidbody2D>();

    }

    void FixedUpdate()
    {

        ePos = enemy.transform.position;
        direction = gameObject.transform.position.x - ePos.x;

        if (direction > 0)

        {
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x) , transform.localScale.y, transform.localScale.z);
        }
        else
        {
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x)*-1, transform.localScale.y, transform.localScale.z);
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
                sr.enabled = true;
                flashing = false;
            }
        }
        if (Input.GetKeyDown("i") && onFloor && !GameObject.Find("Player2Arms").GetComponent<Attack2>().shooting)
        {
            jmpDuration = 0;
            jmpForce = 0;
            jmpDuration += Time.deltaTime;
            jmpForce += Time.deltaTime * jumpForce;
            if (jmpDuration < jumpDuration)
            {
                //Debug.Log("Jump jmpForce Report: " + jmpForce);
                rb.velocity = new Vector2(rb.velocity.x, jmpForce);
                onFloor = false;
            }


        }
        var x = Input.GetAxis("Player2") * Time.deltaTime * 30.0f;
        if (!GameObject.Find("Player2Arms").GetComponent<Attack2>().shooting) {
            transform.Translate(x, 0, 0);
        }


    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.collider.tag == "Floor")
        {
            onFloor = true;
        }
        if (col.collider.tag == "P1Attack" && !flashing)
        {
            health -= .2f;
            flashing = true;
        }
        if (col.gameObject.name == "Projectile1(Clone)")
        {
            Destroy(col.gameObject);
        }
    }
}

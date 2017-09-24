using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack2 : MonoBehaviour
{
    SpriteRenderer sr;
    Collider damageCol;
    public bool isAttacking;
    public Sprite nPunch;
    public Sprite punch;
    public Sprite shoot;
    Vector3 pos;
    public bool shooting;
    public GameObject fireball;
    float direction;
    // Use this for initialization
    void Start()
    {
        sr = gameObject.GetComponent<SpriteRenderer>();
        isAttacking = false;
        gameObject.GetComponent<PolygonCollider2D>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

        

        direction = GameObject.Find("Player2").GetComponent<FighterScript2>().direction;
        if (direction > 0)

        {
            pos = new Vector3(this.transform.position.x - 2.75f, this.transform.position.y, this.transform.position.z);
        }
        else
        {
            pos = new Vector3(this.transform.position.x + 2.75f, this.transform.position.y, this.transform.position.z);
        }

        if (Input.GetKeyDown("u"))
        {
            //Debug.Log("PUNCH");
            gameObject.GetComponent<PolygonCollider2D>().enabled = true;
            sr.sprite = punch;
            StartCoroutine(waitForTime(.25f, sr));

        }
        if (Input.GetKeyDown("k") && Input.GetKeyDown("o") && !shooting)
        {
            //Debug.Log("shoot");
            sr.sprite = shoot;
            shooting = true;
            GameObject projectile = Instantiate(fireball, pos, this.transform.rotation);
            if (direction > 0)

            {
                projectile.GetComponent<Rigidbody2D>().velocity = transform.right * -10;
            }
            else
            {
                projectile.GetComponent<Rigidbody2D>().velocity = transform.right * 10;
            }
            StartCoroutine(shootTime(1f, sr));
        }
    }

    IEnumerator waitForTime(float x, SpriteRenderer sr)
    {

        yield return new WaitForSeconds(x);
        //Debug.Log("waited");
        gameObject.GetComponent<PolygonCollider2D>().enabled = false;
        sr.sprite = nPunch;
    }

    IEnumerator shootTime(float x, SpriteRenderer sr)
    {

        yield return new WaitForSeconds(x);
        //Debug.Log("waited");
        sr.sprite = nPunch;
        shooting = false;

    }
}

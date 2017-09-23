using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GUI : MonoBehaviour {

	public UnityEngine.UI.Slider health1;
	public UnityEngine.UI.Slider health2;
    
    public GameObject p1, p2;
    public UnityEngine.UI.Text txtGame;
    FighterScript p1Script; 
    FighterScript2 p2Script;
    bool game;
    public float time;
    public Text timer;
    public Text shout;
    
    

	// Use this for initialization
	void Start () {
        p1 = GameObject.Find("Player1");
        p1Script = p1.GetComponent<FighterScript>();
        p2 = GameObject.Find("Player2");
        p2Script = p2.GetComponent<FighterScript2>();
        game = true;
        time = 60;
		foreach (UnityEngine.UI.Slider t in Object.FindObjectsOfType<UnityEngine.UI.Slider>()) {
			if (t.name.Equals ("Player1Health")) {
				health1 = (UnityEngine.UI.Slider) t;
			}
			if (t.name.Equals ("Player2Health")) {
				health2 = (UnityEngine.UI.Slider) t;
			}
		}

        foreach (UnityEngine.UI.Text t in Object.FindObjectsOfType<UnityEngine.UI.Text>())
        {
            if (t.name.Equals("Timer"))
            {
               timer = t;
          }
          if (t.name.Equals("Shout"))
            {
                shout = t;
            }
        }
        
        shout.text = "Fight!";
        StartCoroutine(waitForTime(3, shout));
        
    }

	

	// Update is called once per frame
	void FixedUpdate () {
        if (game)
        {
            
            health1.value = p1Script.health;
            health2.value = p2Script.health;
            time -= Time.deltaTime;
            timer.text = time.ToString("F2");
            if(p1Script.health <= 0)
            {
                game = false;
                shout.text = "Player 2 Wins";
                shout.enabled = true;

            }
            else if(p2Script.health <= 0){
                game = false;
                shout.text = "Player 1 Wins";
                shout.enabled = true;
            }
            else if(time <= 0)
            {
                if(p1Script.health > p2Script.health)
                {
                    game = false;
                    shout.text = "Player 1 Wins";
                    shout.enabled = true;
                }
                else if(p1Script.health < p2Script.health)
                {
                    game = false;
                    shout.text = "Player 2 Wins";
                    shout.enabled = true;
                }
                else
                {
                    timer.enabled = false;

                }
                
            }
            
        }
        
	}

    IEnumerator waitForTime(float x, Text t)
    {

        yield return new WaitForSeconds(x);
        t.enabled = false;
        //Debug.Log("waited");
        
        
    }
}

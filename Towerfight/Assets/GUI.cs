using UnityEngine;
using System.Collections;

public class GUI : MonoBehaviour {

	public UnityEngine.UI.Slider health1;
	public UnityEngine.UI.Slider health2;
    public UnityEngine.UI.Text timer;
    public GameObject p1, p2;
    public UnityEngine.UI.Text txtGame;
    Player p1Script, p2Script;
    bool game = true;
    int time = 3;
    int i = 0;
    

	// Use this for initialization
	void Start () {
        
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
            if (t.name.Equals("GameOver"))
            {
                txtGame = t;
            }
        }
        
        p1 = GameObject.Find("Player1");
		p1Script = p1.GetComponent<Player>();
        p2 = GameObject.Find("Player2");
        p2Script = p2.GetComponent<Player>();
    }

	float CheckHealth(Player p)
	{
		return p.health;
	}

	// Update is called once per frame
	void Update () {
        if (game)
        {
            i++;
            health1.value = CheckHealth(p1Script);
            health2.value = CheckHealth(p2Script);
            if (i == 60)
            {
                time--;
                timer.text = time.ToString();
                i = 0;
            }

            if (time == 0)
            {
                game = false;
                
            }
        }
        
	}
}

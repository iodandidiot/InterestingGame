using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreCount : MonoBehaviour {

    private int __countScore;
    public Text __score;
    public GameObject __Generator;
    public Text __time;
    public float __timer;
	// Use this for initialization
	void Start () 
    {
        switch (PlayerPrefs.GetString("PlayMod"))
        {
            case "Light":
                __countScore = 15;
                break;
            case "Normal":
                __countScore = 22;
                break;
            case "Hard":
                __countScore = 27;
                break;
        }

        __timer = 0;
        //__countScore = 0;
        __score.text = string.Format("Purpose {0} coins", __countScore);
	}
	
	// Update is called once per frame
	void Update () 
    {
        __timer += Time.deltaTime;
        __time.text = string.Format("Time {0:.#} s.", __timer);
        __score.text = string.Format("Purpose {0} coins", __countScore);
        if (__countScore == 0 && __Generator!=null)
        {
            Generator win = __Generator.GetComponent<Generator>();
            win.WinGame();
            Destroy(gameObject);
        }
	}
    public void plus()
    {
        __countScore--;
    }
    public void minus()
    {
        __countScore++;
    }

    

}

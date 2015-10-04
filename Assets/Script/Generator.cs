using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Generator : MonoBehaviour {

    public float __StartX, __StartY;
    public GameObject [] __GameObject;
    public GameObject[] __ChangeGameObject;
    public float Timer; //Время в секундах которое отсчитает таймер
    private float TimerDown; //Изменяемая переменная для внутренних операций 
    public bool endGame = false;
    private GameObject ball;
    public Text finalText;
    public GameObject finalImage;
    public ScoreCount __score;
    public Text __checkScore;
    public Text __bestScore;
    public Text mod;
    // Use this for initialization
	void Start () 
    {
        switch (PlayerPrefs.GetString("PlayMod"))
        {
            case "Light":
                Timer = 20;
                break;
            case "Normal":
                Timer = 13;
                break;
            case "Hard":
                Timer = 9;
                break;
        }        
        AddGameObject(__StartX, __StartY);
        TimerDown = Timer;
        mod.text = PlayerPrefs.GetString("PlayMod");
	}
	
	// Update is called once per frame
    void Update()
    {
        if (endGame) LoseGame();
        __ChangeGameObject = GameObject.FindGameObjectsWithTag("GameObject");
        if(TimerDown > 0) TimerDown -= Time.deltaTime; //Если время которое нужно отсчитать еще осталось убавляем от него время обновления экрана (в одну секунду будет убавляться полная единица)
        if(TimerDown < 0) TimerDown = 0; //Если временная переменная ушла в отрицательное число (все возможно) то приравниваем ее к нулю
        if (TimerDown == 0)
        {
            StartCoroutine("movePattern");
            TimerDown = Timer;
        }
        CheckEndGame();
    }

    void AddGameObject(float __addX,float __addY )
    {
        
        for (float __Y = 0; __Y < __addY; __Y++)
        {
            for (float __X = 0; __X < __addX; __X++)
            {
                Instantiate(__GameObject[Random.Range(0, (__GameObject.Length))], new Vector3(-(__StartX/2)+0.5f+__X,-__Y+4, 0), Quaternion.identity);
            }
        }   
    }
    IEnumerator movePattern()
    {
        for (int i = 0; i < 10; i++)
        {
            foreach(GameObject j in __ChangeGameObject)
            {
                j.transform.position = new Vector2(j.transform.position.x, j.transform.position.y - 0.1f);
            }
            yield return new WaitForSeconds(0.1f);
        }
        AddGameObject(__StartX,1);
    }
    void LoseGame()
    {
        StopAllCoroutines();
        foreach (GameObject i in __ChangeGameObject)
        {
            explotion __animAndDestroy = i.gameObject.GetComponent<explotion>();
            __animAndDestroy.__AnimAndDestroy();
            //Destroy(i);
        }
        ball = GameObject.FindGameObjectWithTag("Player");
        Destroy(ball);
        finalImage.SetActive(true);
        finalText.text = "Sorry,You Lose";
        Destroy(gameObject);
    }
    public void WinGame()
    {
        StopAllCoroutines();
        foreach (GameObject i in __ChangeGameObject)
        {
            explotion __animAndDestroy = i.gameObject.GetComponent<explotion>();
            __animAndDestroy.__AnimAndDestroy();
            //Destroy(i);
        }
        ball = GameObject.FindGameObjectWithTag("Player");
        Destroy(ball);
        finalImage.SetActive(true);
        finalText.text = "You won!!!";
        __checkScore.gameObject.SetActive(true);
        __bestScore.gameObject.SetActive(true);
        __checkScore.text = string.Format("Score {0} {1}",PlayerPrefs.GetString("PlayMod"), __score.__timer);
        switch (PlayerPrefs.GetString("PlayMod"))
        {
            case "Light":
                if (PlayerPrefs.HasKey("BestScoreLight")) __bestScore.text = string.Format("Best Score Light {0}", PlayerPrefs.GetFloat("BestScoreLight"));
                else __bestScore.text = string.Format("Best Score Light {0}", 0);
                if (__score.__timer > PlayerPrefs.GetFloat("BestScoreLight")) PlayerPrefs.SetFloat("BestScoreLight", __score.__timer);
                Destroy(gameObject);
                break;
            case "Normal":
                if (PlayerPrefs.HasKey("BestScoreNormal")) __bestScore.text = string.Format("Best Score Normal {0}", PlayerPrefs.GetFloat("BestScoreNormal"));
                else __bestScore.text = string.Format("Best Score Normal {0}", 0);
                if (__score.__timer > PlayerPrefs.GetFloat("BestScoreNormal")) PlayerPrefs.SetFloat("BestScoreNormal", __score.__timer);
                Destroy(gameObject);
                break;
            case "Hard":
                if (PlayerPrefs.HasKey("BestScoreHard")) __bestScore.text = string.Format("Best Score Hard {0}", PlayerPrefs.GetFloat("BestScoreHard"));
                else __bestScore.text = string.Format("Best Score Hard {0}", 0);
                if (__score.__timer > PlayerPrefs.GetFloat("BestScoreHard")) PlayerPrefs.SetFloat("BestScoreHard", __score.__timer);
                Destroy(gameObject);
                break;
        }        




        //if (PlayerPrefs.HasKey("BestScore")) __bestScore.text = string.Format("Best Score {0}", PlayerPrefs.GetFloat("BestScore"));
        //else __bestScore.text = string.Format("Best Score {0}", 0);
        //if (__score.__timer > PlayerPrefs.GetFloat("BestScore")) PlayerPrefs.SetFloat("BestScore", __score.__timer);
        //Destroy(gameObject);
    }
    void CheckEndGame()
    {
        foreach (GameObject i in __ChangeGameObject)
        {
            if (i.transform.position.y < -3.5)
            {
                endGame = true;
            }
        }
    }
    


}

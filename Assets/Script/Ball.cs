using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Ball : MonoBehaviour {

    private Vector2 __position=new Vector2(0,-4.5f);
    private bool __isClick=false;
    public bool __Left=false;
    public bool __Right = true;
    public float __dir=1;
    private float __koefMoveBall=1f;
    public Sprite[] skin;
    public GameObject __backObject;
    public GameObject[] __GameObject;
    SpriteRenderer __skin;
    public GameObject __scoreCount;
    ScoreCount __countScore;
    public float Timer; //Время в секундах которое отсчитает таймер
    private float TimerDown; 
	// Use this for initialization
	void Start () 
    {
        __countScore = __scoreCount.GetComponent<ScoreCount>();
        __skin = GetComponent<SpriteRenderer>();
        transform.position = __position;
        __skin.sprite = skin[Random.Range(0, skin.Length)];
        TimerDown = Timer;

	}
	
	// Update is called once per frame
	void Update () 
    {
        if(TimerDown > 0) TimerDown -= Time.deltaTime; 
        if(TimerDown < 0) TimerDown = 0; 
        if (TimerDown == 0)
        {
            TimerDown = Timer;
            __koefMoveBall += 0.2f;
        }
     }
    void FixedUpdate()
    {
        if (transform.position.x > 6 && __Right)
        {
            __dir *= -1;
            __Right = false;
            __Left = true;
        }
        if (transform.position.x < -6 && __Left)
        {
            __dir *= -1;
            __Right = true;
            __Left = false;
        }
        if (Input.GetMouseButton(0) || Input.GetKeyDown(KeyCode.Space))
        {
            __isClick = true;
        }
        if (transform.position.y > 5)
        {
            __Destroy();
        }
        if (!__isClick)
        {
            rigidbody2D.velocity = new Vector2(__dir * __koefMoveBall, 0);
        }
        else
        {
            rigidbody2D.velocity = new Vector2(0,Mathf.Abs(__dir)*2);
        }
    }
    void __Destroy()
    {
        Instantiate(__backObject);
        Destroy(gameObject);
        
    }
    void OnTriggerEnter2D(Collider2D coll)
    {
        explotion __animAndDestroy = coll.gameObject.GetComponent<explotion>();
        //SpriteRenderer GetImage=coll.GetComponent<SpriteRenderer>();
        if (__skin.sprite == skin[0] && coll.gameObject.name == "CoinSprite(Clone)")
        {
            __countScore.plus();
            Destroy(coll.gameObject);
            __Destroy();
        }
        else if (__skin.sprite == skin[1] && coll.gameObject.name == "BowlSprite(Clone)")
        {
            __animAndDestroy.__AnimAndDestroy();
            //Destroy(coll.gameObject);
            __Destroy();
        }
        else if (__skin.sprite == skin[1] && coll.gameObject.name == "CoinSprite(Clone)")
        {
            __countScore.minus();
            __animAndDestroy.__AnimAndDestroy();
            //Destroy(coll.gameObject);
            __Destroy();
        }
        else
        {
            Instantiate(__GameObject[0], new Vector3(coll.gameObject.transform.position.x, coll.gameObject.transform.position.y - 1, 0), Quaternion.identity);
            __Destroy();
        }
    }
}

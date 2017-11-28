using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {
    private float vertical, horizontal;
    public Rigidbody2D rb2D;
    public PolygonCollider2D coll2D;
    public int speed;
    //public int isHit;
    private Text breatheText;
    private int breatheCount;
    private float initialTime;
    private Collider2D sky;
    private bool breatheSwitch;
    public bool playerDead;
    public GameManager gameManager;
    
	// Use this for initialization
	void Start () {
        //isHit = 0;
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        breatheText = GameObject.Find("BreatheText").GetComponent<Text>();
        sky = GameObject.Find("Sky").GetComponent<Collider2D>();
        rb2D = GetComponent<Rigidbody2D>();
        coll2D = GetComponent<PolygonCollider2D>();
        breatheCount = 5;
        playerDead = false;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        
        if (coll2D.IsTouching(sky))
        {
            if(breatheSwitch == false)
            {
                initialTime = Time.time;
                breatheSwitch = true;
            }
            breatheCount = Mathf.RoundToInt((5 - (Time.time - initialTime)));
            breatheText.text = "You will die in " + breatheCount + " seconds";
            if(breatheCount == 0)
            {
                playerDeath();
            }

        }
        else
        {
            breatheCount = 5;
            breatheSwitch = false;
            breatheText.text = "";
        }
        vertical = Input.GetAxis("Vertical");
        horizontal = Input.GetAxis("Horizontal");
        rb2D.velocity = speed*(new Vector2(horizontal, vertical));
        rb2D.position = new Vector2(Mathf.Clamp(rb2D.position.x, -16, 17), Mathf.Clamp(rb2D.position.y, 0, 14));
	}

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Sharky" || other.tag == "Jelly" || other.tag == "Volcano" || other.tag == "Lightning" || other.tag == "BigSmoke")
            if (gameManager.gamePlaying == true)
            {
                
                playerDeath();
                
            }
    }

    private void playerDeath()
    {

        breatheText.text = "";
        playerDead = true;
        Destroy(this.gameObject);
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sharky : MonoBehaviour {
    public GameManager gameManager;
    private Rigidbody2D rb2D;
    private bool left;
    private bool playedSound;
    private float startTime;
    private float currTime;
    private AudioSource roar;
    private float randomTime;

	// Use this for initialization
	void Start () {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        rb2D = GetComponent<Rigidbody2D>();
        if(rb2D.position.x == gameManager.enemySpawnX[0])
        {
            left = true;
        }
        else
        {
            left = false;
        }
        playedSound = false;
        roar = GetComponent<AudioSource>();
        randomTime = Random.Range(0f, 4f);
        startTime = currTime = 0;
	}
	
	// Update is called once per frame
	void Update () {
        if (gameManager.gameStart == false)
        {
            if(startTime == 0)
            {
                startTime = Time.time;
            }
            currTime = Time.time - startTime;
            if(currTime > randomTime)
            {
                if (left == true)
                {
                    rb2D.velocity = new Vector2(7, 0);
                }
                else
                {
                    rb2D.velocity = new Vector2(-7, 0);
                }
                if (playedSound == false)
                {
                    playedSound = true;
                    roar.Play();
                }
            }

            

            
            
            if(left == true && rb2D.position.x > gameManager.enemySpawnX[1] + 5 || left == false && rb2D.position.x < gameManager.enemySpawnX[0] - 5)
            {
                Destroy(this.gameObject);
            }
        }
        
        if(gameManager.destroyEnemies == true)
        {
            Destroy(this.gameObject);
        }
	}
}

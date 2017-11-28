using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jelly : MonoBehaviour {
    public GameManager gameManager;
    private Rigidbody2D rb2D;
    public GameObject lightning;
    private bool spawned;
    private float randomTime;
    private float initialTime;
    private bool timeSet;
    private float timeDifference;
    private bool playedSound;

    private AudioSource elec;


    // Use this for initialization
    void Start () {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        spawned = false;
        rb2D = GetComponent<Rigidbody2D>();
        randomTime = Random.Range(0f, 8f);
        initialTime = 0;
        timeSet = false;
        timeDifference = 0;
        playedSound = false;
        elec = GetComponent<AudioSource>();

    }
	
	// Update is called once per frame
	void Update () {
        if (gameManager.gameStart == false)
        {
            if (timeSet == false)
            {
                initialTime = Time.time;
                timeSet = true;
            }
            timeDifference = Time.time - initialTime;
            if (timeDifference > randomTime && spawned == false)
            {
                Instantiate(lightning, new Vector2((float)(rb2D.position.x + 4.75), (float)(rb2D.position.y - 5)), Quaternion.identity);
                spawned = true;
                if (playedSound == false)
                {
                    playedSound = true;
                    elec.Play();
                }

            }
          
            
        }
        if (gameManager.destroyEnemies == true)
        {
            Destroy(this.gameObject);
        }

    }
}

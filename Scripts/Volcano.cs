using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Volcano : MonoBehaviour {
    public GameManager gameManager;
    private Rigidbody2D rb2D;
    public GameObject bigSmoke;
    private bool spawned;
    private float randomTime;
    private float initialTime;
    private bool timeSet;
    private float timeDifference;
    private bool playedSound;

    private AudioSource smoke;

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
        smoke = GetComponent<AudioSource>();

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
                Instantiate(bigSmoke, new Vector2((float)(rb2D.position.x + 6.5), (float)(rb2D.position.y+ 1.5)), Quaternion.identity);
                spawned = true;
                if (playedSound == false)
                {
                    playedSound = true;
                    smoke.Play();
                }
            }


        }
        if (gameManager.destroyEnemies == true)
        {
            Destroy(this.gameObject);
        }
    }
}

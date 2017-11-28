using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lightning : MonoBehaviour {
    private float initialTime;
    private float timeDifference;
    private GameManager gameManager;

	// Use this for initialization
	void Start () {
        initialTime = Time.time;
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
	}
	
	// Update is called once per frame
	void Update () {
        timeDifference = Time.time - initialTime;
        if(timeDifference > 1)
        {
            Destroy(this.gameObject);
        }
        if (gameManager.destroyEnemies == true)
        {
            Destroy(this.gameObject);
        }
    }
}

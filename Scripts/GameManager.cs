using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    

    private Text announce;
    private int gameLevel;
    public bool gameStart;
    public bool gameOver;
    public bool gamePlaying;
    private float initialTime;
    private float endTime;
    private float initialTimeGame;
    private float endTimeGame;
    public GameObject[] enemies;
    private bool enemySetup;
    public int[] enemySpawnX = { -6, 20 };
    private int levelCount;
    private GameObject currEnemy;
    public Player player;
    private Player currPlayer;

    public bool destroyEnemies;

    // Use this for initialization
    void Start () {
        announce = GameObject.Find("AnnounceText").GetComponent<Text>();
        gameStart = true;
        gameLevel = 1;
        initialTime = 0;
        endTime = 0;
        initialTimeGame = 0;
        endTimeGame = 0;
        enemySetup = true;
        levelCount = 0;
        gameOver = false;
        gamePlaying = false;
        destroyEnemies = false;
        currPlayer = Instantiate(player, new Vector2(0, 2), Quaternion.identity);
    }
	
	// Update is called once per frame
    
	void Update () {
        if (gameStart == true)
        {

            if (initialTime == 0)
            {
                destroyEnemies = false;
                
                
                initialTime = Time.time;
            }
            announce.text = "Welcome to level " + gameLevel;
            endTime = Time.time - initialTime;
            if (enemySetup == true)
            {
                enemySetup = false;
                while (levelCount < gameLevel + 2)
                {

                    currEnemy = Instantiate(enemies[Random.Range(0, enemies.Length)]);
                    if (currEnemy.tag == "Sharky")
                    {
                        currEnemy.transform.position = new Vector3(enemySpawnX[Random.Range(0, 2)], Random.Range(-2, 10), 0f);
                        if (currEnemy.transform.position.x == enemySpawnX[1])
                        {
                            currEnemy.GetComponent<Transform>().localRotation = Quaternion.Euler(0, 180, 0);
                        }
                    }
                    else if (currEnemy.tag == "Jelly")
                    {
                        currEnemy.transform.position = new Vector3(Random.Range(-13, 13), 8, 0f);
                    }
                    else if (currEnemy.tag == "Volcano")
                    {
                        currEnemy.transform.position = new Vector3(Random.Range(-13, 13), 0, 0f);
                    }



                    levelCount += 1;
                }
            }

            if (endTime >= 3)
            {
                gameStart = false;
                initialTime = 0;
                announce.text = "";
                enemySetup = true;
                levelCount = 0;
                endTime = 0;
                gamePlaying = true;
            }
        }
        if (gamePlaying == true)
        {
           

            if (initialTimeGame == 0)
            {
                initialTimeGame = Time.time;
            }
            endTimeGame = Time.time - initialTimeGame;
            if(endTimeGame >= 8)
            {
                gamePlaying = false;
                gameStart = true;
                gameLevel += 1;
                initialTimeGame = 0;
                endTimeGame = 0;
                destroyEnemies = true;
             
            }

            if (currPlayer.playerDead == true)
            {
                gameOver = true;
                gamePlaying = false;
            }
            
        }
        if (gameOver == true)
        {
            if (initialTime == 0)
            {
                initialTime = Time.time;
                gameLevel = 1;
                destroyEnemies = true;
            }
            announce.text = "Game over :(";
            endTime = Time.time - initialTime;
            
            if (endTime >= 3)
            {
                gameStart = true;
                initialTime = 0;
                announce.text = "";
                endTime = 0;
                initialTimeGame = 0;
                endTimeGame = 0;
                gameOver = false;
                currPlayer = Instantiate(player, new Vector2(0, 2), Quaternion.identity);
                player.playerDead = false;
                destroyEnemies = true;

            }
        }




	}
}

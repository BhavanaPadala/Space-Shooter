
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gamecontroller : MonoBehaviour
{
    public GameObject hazard;
    public Vector3 spawnValues;
    public int hazardCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;
    public Text scoretext;
    private int score;
    public Text restarttext;
    public Text gameovertext;
    private bool gameover;
    private bool restart;


    void Start ()
    {
        gameover= false;
        restart= false;
        gameovertext.text = "";
        restarttext.text = "";
        score=0;
        updatescore();
        StartCoroutine (SpawnWaves ());
    }
    void Update()
    {
        if(restart)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                Application.LoadLevel(Application.loadedLevel);
            }
        }
    }

    IEnumerator SpawnWaves ()
    {
        yield return new WaitForSeconds (startWait);
        while (true)
        {
            for (int i = 0; i < hazardCount; i++)
            {
                Vector3 spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate (hazard, spawnPosition, spawnRotation);
                yield return new WaitForSeconds (spawnWait);
            }
            yield return new WaitForSeconds (waveWait);

            if (gameover)
            {
                restarttext.text=" Press 'R' to restart";
                restart= true;
                break;
            }
        }
    }
    public void addscorevalue( int newscorevalue)
    {
        score += newscorevalue;
        updatescore();
    }
    void updatescore()
    {
        scoretext.text="Score: " + score;
    }
    public void gameover()
    {
        gameovertext.text="Game Over!";
        gameover= true;
    }
}


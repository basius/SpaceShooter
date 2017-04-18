using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Game_Controller : MonoBehaviour {

    public GameObject hazard;
    public Vector3 spawnValues;
    //Total asteroides
    public int hazardCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;

    private int score;
    public Text scoreText;

    public Text gameOverText;
    private bool gameOver;
    public Text restartGameText;
    private bool restart;
    // Use this for initialization
    void Start () {
        restart = false;
        gameOver = false;
        gameOverText.gameObject.SetActive(false);
        restartGameText.gameObject.SetActive(false);
        score = 0;
        UpdateScore();
        StartCoroutine(SpawnWaves());
    }

    void Update()
    {
        if(restart && Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(0);
            //SceneManager.LoadScene("Main");
        }
    }
	
	// Grups de enemics amb temps d'espera de regeneració.
	IEnumerator SpawnWaves() {
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            for (int i = 0; i < hazardCount; i++)
            {
                Vector3 spwanPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Instantiate(hazard, spwanPosition, Quaternion.identity);
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);
            if (gameOver)
            {
                restartGameText.gameObject.SetActive(true);
                restart = true;
                break;
            }
        }
	}

    public void AddScore(int value)
    {
        score += value;
        UpdateScore();
    }
    void UpdateScore()
    {
        scoreText.text = "Score: " + score;
    }
    public void GameOver()
    {
        gameOverText.gameObject.SetActive(true);
        gameOver = true;
    }
}

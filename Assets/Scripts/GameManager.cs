using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameObject foodPrefab;
    public GameObject scorePanel;
    public GameObject deadPanel;
    Text _scoreText;

    GameObject _food; 
    
    float widthX = 10f;
    float widthZ = 7f;
    Vector3 randomSpawn;
    int score = 0;
    bool dead = false;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        randomSpawn = RandomPosition();
        _food = Instantiate(foodPrefab, randomSpawn, Quaternion.identity);
        _scoreText = scorePanel.GetComponentInChildren<Text>();
    }

    private void Update()
    {
        if (_food.Equals(null))
        {
            randomSpawn = RandomPosition();//WTF?!
            _food = Instantiate(foodPrefab, randomSpawn, Quaternion.identity);
        }
        if (Input.GetKeyDown(KeyCode.R) && dead)
        {
            SceneManager.LoadScene(0);
        }
    }

    Vector3 RandomPosition()
    {
        Vector3 randomPosition = new Vector3(Random.Range(-widthX, widthX), 0.2f, Random.Range(-widthZ, widthZ));
        return randomPosition;
    }
    public void AddScore()
    {
        ++score;
        _scoreText.text = "Score: " + score.ToString();
    }
    public void GameOver()
    {
        dead = true;
        scorePanel.SetActive(false);
        deadPanel.SetActive(true);
    }
}

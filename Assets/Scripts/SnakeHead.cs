using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeHead : MonoBehaviour
{
    SnakeControll _snake;
    private void Start()
    {
        _snake = GameObject.Find("Snake").GetComponent<SnakeControll>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Food")
        {
            GameManager.instance.AddScore();
            _snake.AddTail();
            Destroy(other.gameObject);
        }
        else if (other.tag == "Wall" || other.tag == "SnakeTail" && other.gameObject.name != "FrstTailSkip")
        {
            GameManager.instance.GameOver();
            _snake.speed = 0;
        }
    }
}

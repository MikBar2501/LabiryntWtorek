using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;
    [SerializeField] int timeToEnd;

    bool gamePause = false;

    bool endGame = false;
    bool win = false;

    public int points = 0;

    public int redKey = 0;
    public int greenKey = 0;
    public int goldKey = 0;

    // Start is called before the first frame update
    void Start()
    {
        if(instance == null)
        {
            instance = this;
        }

        if(timeToEnd <= 0)
        {
            timeToEnd = 100;
        }

        InvokeRepeating("Stopper", 2, 1);


    }

    // Update is called once per frame
    void Update()
    {
        PauseCheck();
        PickUpCheck();
    }

    void Stopper()
    {
        timeToEnd--;
        Debug.Log($"Time: {timeToEnd} s");

        if(timeToEnd <= 0)
        {
            timeToEnd = 0;
            endGame = true;
        }

        if(endGame)
        {
            EndGame();
        }
   
    }

    public void PauseGame()
    {
        Debug.Log("Pause Game");
        Time.timeScale = 0f;
        gamePause = true;
    }

    public void ResumeGame()
    {
        Debug.Log("Resume Game");
        Time.timeScale = 1f;
        gamePause = false;
    }

    void PauseCheck()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            if (gamePause) ResumeGame();
            else PauseGame();
        }
    }

    public void EndGame()
    {
        CancelInvoke("Stopper");
        if(win)
        {
            Debug.Log("You Win!!! Reload?");
        } else
        {
            Debug.Log("You Lose!!! Reload?");
        }
    }

    public void FreezTime(int freez)
    {
        CancelInvoke("Stopper");
        InvokeRepeating("Stopper", freez, 1);
    }

    public void AddTime(int addTime)
    {
        timeToEnd += addTime;
    }

    public void AddPoints(int point = 5)
    {
        points += point;
    }

    public void AddKey(KeyColor color)
    {
        if(color == KeyColor.Red) redKey++;
        else if (color == KeyColor.Green) greenKey++;
        else if (color == KeyColor.Gold) goldKey++;
    }

    void PickUpCheck()
    {
        if(Input.GetKeyDown(KeyCode.L))
        {
            Debug.Log("Actual Time: " + timeToEnd);
            Debug.Log("Key red: " + redKey + " green: " + greenKey + " gold: " + goldKey);
            Debug.Log("Points: " + points);
        }
    }
}

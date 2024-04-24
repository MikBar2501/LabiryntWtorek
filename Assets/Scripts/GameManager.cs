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

    AudioSource audioSource;

    public AudioClip resumeClip;
    public AudioClip pauseClip;
    public AudioClip winClip;
    public AudioClip loseClip;

    public MusicScript music;
    bool lessTime = false;

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
        audioSource = GetComponent<AudioSource>();
        InvokeRepeating("Stopper", 2, 1);


    }

    // Update is called once per frame
    void Update()
    {
        PauseCheck();
        PickUpCheck();
    }


    public void LessTimeOn()
    {
        music.PitchThis(1.58f);
    }

    public void LessTimeOff()
    {
        music.PitchThis(1f);
    }

    public void PlayClip(AudioClip playClip)
    {
        audioSource.clip = playClip;
        audioSource.Play();
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

        if(timeToEnd < 20 && !lessTime)
        {
            LessTimeOn();
            lessTime = true;
        }

        if (timeToEnd > 20 && lessTime)
        {
            LessTimeOff();
            lessTime = false;
        }


    }

    public void PauseGame()
    {
        PlayClip(pauseClip);
        Debug.Log("Pause Game");
        Time.timeScale = 0f;
        gamePause = true;
    }

    public void ResumeGame()
    {
        PlayClip(resumeClip);
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
            PlayClip(winClip);
            Debug.Log("You Win!!! Reload?");
        } else
        {
            PlayClip(loseClip);
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

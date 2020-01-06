using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using System;
using System.Timers;
using System.Threading;


public class GameManager : MonoBehaviour 
{
    static private List<ExitScript> listOfExits = new List<ExitScript>();
    private System.Timers.Timer timer;
    // wait 3 seconds at the exit to pass the level.
    private const int TimeOfWaiting = 3000;
    public Animator animator;
    public Canvas canvas;

    public bool backToMain = false;

    public GameObject PauseMenuUI;
    public static bool IsPaused = false;

    void Start() 
    {
    }

    public void AddExit(ExitScript exit) 
    {
        listOfExits.Add(exit);
    }

    //Method added in case of multiple exits.
    public void ExitEntered(ExitScript exit) 
    {
        Debug.Log("ENTERED");

        this.timer = new System.Timers.Timer(TimeOfWaiting);

        this.timer.Elapsed += OnTimedEvent;
        this.timer.AutoReset = false;
        this.timer.Enabled = true;
        this.timer.Start();
    }

    public void ExitLeft(ExitScript exit) 
    {
        this.timer.Stop();
/*        Debug.Log("EXITED");*/
    }

    private void OnTimedEvent(object sender, EventArgs e) 
    {
        Debug.Log("Time Elapsed :(");
        try 
        {
            UnityMainThreadDispatcher.Instance().Enqueue(AnimationOfPanel());
        } 
        catch (Exception ex) 
        {
            Debug.Log(ex.ToString());
        }
    }

    private IEnumerator AnimationOfPanel() 
    {
//        this.completeLevelUI.SetActive(true);
        animator.SetTrigger("LevelComplete");
        yield return null;
    }

    public void LoadScene()
    {
        if (backToMain)
        {
            SceneManager.LoadScene(0);
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    void FixedUpdate() 
    {
        if (Input.GetKeyDown("escape"))
        {
            if (IsPaused) 
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
            /*
//            print("escape key was pressed");
//            animator.SetTrigger("GamePaused");
            
            Transform panel = canvas.transform.Find("AnimationCanvas");
            //            Transform image = panel.transform.Find("FadeImage");
            //            Transform MenuPanel = panel.transform.Find("MenuPanel");
            Transform image = panel.Find("FadeImage");


            image.GetComponent<image>().a = 0.25;
            MenuPanel.IsActive = true;
            */
        }
    }

    public void ResumeGame()
    {
        Debug.Log("ResumeGame");
        IsPaused = false;
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1;
    }

    public void PauseGame()
    {
        Debug.Log("PauseGame");
        IsPaused = true;
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0;
    }

    public void BackToMain()
    {
        Debug.Log("BackToMain");
        backToMain = true;
        Time.timeScale = 1;
        animator.SetTrigger("FadeOut");
    }
}
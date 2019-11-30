using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using System;
using System.Timers;
using System.Threading;


public class GameManager : MonoBehaviour {
    static private List<ExitScript> listOfExits = new List<ExitScript>();
    private System.Timers.Timer timer;
    // wait 3 seconds at the exit to pass the level.
    private const int TimeOfWaiting = 3000;

    public GameObject completeLevelUI;

    void Start() {
        this.completeLevelUI.SetActive(false);
    }

    public void AddExit(ExitScript exit) {
        listOfExits.Add(exit);
    }

    //Method added in case of multiple exits.
    public void ExitEntered(ExitScript exit) {
        Debug.Log("ENTERED");

        this.timer = new System.Timers.Timer(TimeOfWaiting);

        this.timer.Elapsed += OnTimedEvent;
        this.timer.AutoReset = false;
        this.timer.Enabled = true;
        this.timer.Start();
    }

    public void ExitLeft(ExitScript exit) {
        this.timer.Stop();
/*        Debug.Log("EXITED");*/
    }

    private void OnTimedEvent(object sender, EventArgs e) {
        try {
            UnityMainThreadDispatcher.Instance().Enqueue(ShowUserPanel());
        } 
        catch (Exception ex) {
            Debug.Log(ex.ToString());
        }
    }

    private IEnumerator ShowUserPanel() {
        this.completeLevelUI.SetActive(true);
        yield return null;
    }

    public void CompleteLevel() {
        /*        Debug.Log("Awake:" + SceneManager.GetActiveScene().name);
                String scene_name = SceneManager.GetActiveScene().name;
                string[] names = scene_name.Split(' ', '\t');*/
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
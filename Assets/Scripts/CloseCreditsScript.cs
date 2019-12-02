using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using System;
using System.Timers;
using System.Threading;

public class CloseCreditsScript : MonoBehaviour {
    public static int TimeOfWaiting = 1000;
    public Animator animator;

    private System.Timers.Timer timer;
    
    void Update() {
        if (Input.anyKey)
        {
            Debug.Log("A key or mouse click has been detected");
            SwitchToMainMenu();
        }
    }

    private void OnTimedEvent(object sender, EventArgs e) {
        try
        {
            UnityMainThreadDispatcher.Instance().Enqueue(ShowUserPanel());
        }
        catch (Exception ex)
        {
            Debug.Log(ex.ToString());
        }
    }

    void SwitchToMainMenu() {
     //   this.timer = new System.Timers.Timer(TimeOfWaiting);

        animator.SetTrigger("FadeOut");
//        this.timer.Elapsed += OnTimedEvent;
 //       this.timer.AutoReset = false;
  //      this.timer.Enabled = true;
   //     this.timer.Start();
    }

    private IEnumerator ShowUserPanel() {
        SceneManager.LoadScene(0);
        yield return null;
    }
}
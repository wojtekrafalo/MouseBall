using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using System;
using System.Timers;
using System.Threading;

public class CloseCreditsScript : MonoBehaviour {
    public Animator animator;
    
    void Update() {
        if (Input.GetKeyDown("escape")) {
            Debug.Log("A key or mouse click has been detected");
            SendTrigger();
        }
    }

    void LoadScene() {
        SceneManager.LoadScene(0);
    }

    void SendTrigger() {
        animator.SetTrigger("FadeOut");
    }

}
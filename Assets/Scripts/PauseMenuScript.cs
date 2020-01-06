using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenuScript : MonoBehaviour
{
    public Button resumeButton;
    public Button mainMenuButton;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("BackToMain");
        Button btnRes = resumeButton.GetComponent<Button>();
        btnRes.onClick.AddListener(ResumeGame);

        Button btnBack = mainMenuButton.GetComponent<Button>();
        btnBack.onClick.AddListener(BackToMain);
    }

    void ResumeGame()
    {
        FindObjectOfType<GameManager>().ResumeGame();
    }

    void BackToMain()
    {
        FindObjectOfType<GameManager>().BackToMain();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

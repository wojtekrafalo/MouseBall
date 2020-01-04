using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class MainMenuScript : MonoBehaviour {
    public Button tiltButton;
    public Button golfButton;
    public Button creditsButton;
    public Button optionsButton;
    public Button exitButton;
    public Animator animator;

    private int sceneNumber = 0;

    /*
    void Update()
    {
        if (Input.anyKey)
        {
            Debug.Log("A key or mouse click has been detected");
        }
    }
    */

    void Start() {
        Button btnTilt = tiltButton.GetComponent<Button>();
        btnTilt.onClick.AddListener(TiltOnClick);
        
        Button btnGolf = golfButton.GetComponent<Button>();
        btnGolf.onClick.AddListener(GolfOnClick);
        
        Button btnCred = creditsButton.GetComponent<Button>();
        btnCred.onClick.AddListener(CreditsOnClick);
        
        Button btnOpt = optionsButton.GetComponent<Button>();
        btnOpt.onClick.AddListener(OptionsOnClick);
        
        Button btnExit = exitButton.GetComponent<Button>();
        btnExit.onClick.AddListener(ExitOnClick);
    }

    void TiltOnClick() {
        Debug.Log("CLICKED");
        animator.SetTrigger("FadeOut");
        //Change these lines on liken: SceneManager.LoadScene("Tilt_001");
        sceneNumber = 3;
//        SceneManager.LoadScene("Tilt_001");
    }

    void GolfOnClick() {
        Debug.Log("CLICKED");
        animator.SetTrigger("FadeOut");
        sceneNumber = 4;
//        SceneManager.LoadScene("Golf_001");
    }

    void CreditsOnClick() {
        Debug.Log("CLICKED");
        animator.SetTrigger("FadeOut");
        sceneNumber = 1;
        //        SceneManager.LoadScene("Credits");
    }

    void OptionsOnClick() {
        Debug.Log("CLICKED");
        animator.SetTrigger("FadeOut");
        sceneNumber = 2;
        //        SceneManager.LoadScene("Options");
    }

    void ExitOnClick() {
        Debug.Log("EXIT_CLICKED");
        animator.SetTrigger("FadeOut");
        sceneNumber = -1;
    }

    public void LoadScene()
    {
        if (sceneNumber == -1)
            Application.Quit();
        else 
            SceneManager.LoadScene(sceneNumber);
    }
}

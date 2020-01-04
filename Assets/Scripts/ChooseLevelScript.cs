using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ChooseLevelScript : MonoBehaviour
{
    public Canvas canvas;
    private string sceneName;
    public Animator animator;
    public int TiltFirstLevel = 5;

    // Start is called before the first frame update
    void Start()
    {
        Transform panel = canvas.transform.Find("Panel");
        Transform buttonsParent = panel.transform.Find("ButtonsParent");

        foreach (Transform ch in buttonsParent) {
            Debug.Log(ch.name);

            Button b = ch.GetComponent<Button>();
            b.onClick.AddListener(LevelChosen);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void LevelChosen () {
        string name = EventSystem.current.currentSelectedGameObject.name;
        Debug.Log(name);

        sceneName = name;
        animator.SetTrigger("FadeOut");
    }

    public void LoadScene()
    {
        SceneManager.LoadScene(sceneName);
    }
}
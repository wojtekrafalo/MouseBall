using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class MeinMenuScript : MonoBehaviour
{
    //I guess it's a menu button to run first level of game.
    //Set an object.
    public Button yourButton;

    void Start()
    {
        Button btn = yourButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        Debug.Log("CLICKED");
        SceneManager.LoadScene("Level1");
    }
}

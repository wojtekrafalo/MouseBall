using UnityEngine;

public class CameraScript : MonoBehaviour
{
    //Set these objects.
    public GameObject player;
    public GameObject mainCamera;
    public GameObject ground;

    private Vector3 offset = new Vector3(0, 15, -30);

    void Start()
    {
        Cursor.visible = false;

        mainCamera.transform.position = ground.transform.position + offset;
        //        offset = mainCamera.transform.position - player.transform.position;
    }

    void Update()
    {

        mainCamera.transform.position = ground.transform.position + offset;
        //Change the camera position to follow the player.
        //        mainCamera.transform.position = player.transform.position + offset;
    }
}

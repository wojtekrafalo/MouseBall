using UnityEngine;

public class groundScript : MonoBehaviour
{
    public GameObject ground;

    public const float XMaxAngle = 0.4f;
    public const float YMaxAngle = 0.4f;
	
	
    private float XPrevious = 0.0f;
    private float YPrevious = 0.0f;
	
    void Start()
    {
//          Hide cursor of a mouse.

        XPrevious = Input.mousePosition.x;
        YPrevious = Input.mousePosition.y;
    }

    void FixedUpdate()
    {
        Rigidbody rigidbodyGround = ground.GetComponent<Rigidbody>();

        float xAngle = Input.mousePosition.x - XPrevious;
        float yAngle = Input.mousePosition.y - YPrevious;

        
        rigidbodyGround.angularVelocity = new Vector3 (-yAngle * Time.deltaTime * YMaxAngle, 0.0f, xAngle * Time.deltaTime * XMaxAngle);

        XPrevious = Input.mousePosition.x;
        YPrevious = Input.mousePosition.y;
    }
}
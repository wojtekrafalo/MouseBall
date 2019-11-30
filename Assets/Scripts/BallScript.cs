using UnityEngine;

public class BallScript : MonoBehaviour
{
    public float forceMultiple = 500f;
    public float velocityMultiple = 20f;

    //Set an object.
    public GameObject player;        //Public variable to store a reference to the player Ball GameObject



    void Start()
    {
//        player.GetComponent<Rigidbody>().collisionDetectionMode = CollisionDetectionMode.Continuous;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Store the current vertical and horizontal input in the float moveVertical.
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        //Use the two store floats to create a new Vector3 variable movement.
        Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical);

        //add a force to a player depending on input
        player.GetComponent<Rigidbody>().AddForce(movement * forceMultiple * Time.deltaTime);
        //player.GetComponent<Rigidbody>().velocity += movement *velocityMultiple * Time.deltaTime;
    }
}

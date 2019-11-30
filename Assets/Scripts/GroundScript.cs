using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundScript : MonoBehaviour
{
    //Set an object.
    public GameObject ground;

    public const float XAcceleration = 15.0f;			//original value
    public const float YAcceleration = 15.0f;			//original value


    public const float XStep = 1.0f;
    public const float YStep = 1.0f;

    public const float XAngleMax = 400.8126474f;		//original value
    public const float YAngleMax = 400.8126474f;		//original value

    private float XCursorPosition = 0.0f;
    private float YCursorPosition = 0.0f;

    void FixedUpdate()
    {
        Rigidbody rigidbodyGround = ground.GetComponent<Rigidbody>();



        float XPrev = XCursorPosition, YPrev = YCursorPosition;

        XCursorPosition += XStep * Input.GetAxis("Mouse X");
        YCursorPosition += YStep * Input.GetAxis("Mouse Y");

        if (XCursorPosition >= XAngleMax) XCursorPosition = XAngleMax;
        if (XCursorPosition <= -XAngleMax) XCursorPosition = -XAngleMax;

        if (YCursorPosition >= YAngleMax) YCursorPosition = YAngleMax;
        if (YCursorPosition <= -YAngleMax) YCursorPosition = -YAngleMax;

        float XMove = XCursorPosition - XPrev, YMove = YCursorPosition - YPrev;

        // rather something related with this. But I need something like cursor with exact scope, what starts at (0, 0) position.
        rigidbodyGround.angularVelocity = new Vector3(-YAcceleration * Time.deltaTime * YMove, 0.0f, XAcceleration * Time.deltaTime * XMove);

    }
}

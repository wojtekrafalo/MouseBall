using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Timers;
using System.Threading;

public class ExitScript : MonoBehaviour
{
    //Set this object.
    public GameObject exitObject;

    void Start()
    {
        Debug.Log("START");
        FindObjectOfType< GameManager>().AddExit(this);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("ENTERED");
        try
        {
            if (other.tag == exitObject.tag)
            {
                Debug.Log("ENTERED_PLAYER");
                FindObjectOfType<GameManager>().ExitEntered(this);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("{0} Exception caught.", e);
        }
    }

    void OnTriggerStay(Collider other)
    {
//        Debug.Log("STAYED");
    }

    void OnTriggerExit(Collider other)
    {
        FindObjectOfType<GameManager>().ExitLeft(this);
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public float throttle;
    public float steer;
    public Joystick joystick;

    // Update is called once per frame
    void Update()
    {
        //throttle = Input.GetAxis("Vertical");
        //steer = Input.GetAxis("Horizontal");
        throttle = joystick.Vertical;
        steer = joystick.Horizontal;
    }
}

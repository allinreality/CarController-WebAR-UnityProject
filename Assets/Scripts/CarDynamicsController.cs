using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(InputManager))]
public class CarDynamicsController : MonoBehaviour
{
    public InputManager im;
    public List<WheelCollider> throttleWheels;
    public List<WheelCollider> steeringWheels;
    public float strengthCoefficient = 20000f;
    public float maxTurn = 20f;
    public GameObject wheel_fLeft;
    public GameObject wheel_fRight;
    public GameObject wheel_rLeft;
    public GameObject wheel_rRight;

    WheelCollider wheel_fLeftCollider;
    WheelCollider wheel_fRightCollider;
    WheelCollider wheel_rLeftCollider;
    WheelCollider wheel_rRightCollider;

    Rigidbody _rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        im = GetComponent<InputManager>();

        wheel_fLeftCollider = wheel_fLeft.GetComponent<WheelCollider>();
        wheel_fRightCollider = wheel_fRight.GetComponent<WheelCollider>();
        wheel_rLeftCollider = wheel_rLeft.GetComponent<WheelCollider>();
        wheel_rRightCollider = wheel_rRight.GetComponent<WheelCollider>();

        this.transform.localScale = new Vector3(1f, 1f, 1f);

        _rigidbody = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        _rigidbody.mass = this.GetComponent<Rigidbody>().mass;
        Vector3 currentVelocity = _rigidbody.velocity;

        // Auto Break
        if (im.throttle == 0 && _rigidbody.velocity != Vector3.zero)
        {
            _rigidbody.velocity -= 0.01f * currentVelocity * Time.deltaTime;

        }

        foreach (WheelCollider wheel in throttleWheels)
        {
            float X = this.transform.localScale.x;
            float throttleScaler = Mathf.Exp(3f * (X - 1));
            wheel.motorTorque = strengthCoefficient * Time.deltaTime * im.throttle * throttleScaler;
           
        }

        foreach (WheelCollider wheel in steeringWheels)
        {
            wheel.steerAngle = maxTurn * im.steer;
        }
    }

    void Update()
    {
        wheel_fLeft.transform.localEulerAngles = new Vector3(wheel_fLeft.transform.localEulerAngles.x, wheel_fLeftCollider.steerAngle - wheel_fLeft.transform.localEulerAngles.z, wheel_fLeft.transform.localEulerAngles.z);
        wheel_fRight.transform.localEulerAngles = new Vector3(wheel_fRight.transform.localEulerAngles.x, wheel_fRightCollider.steerAngle - wheel_fRight.transform.localEulerAngles.z, wheel_fRight.transform.localEulerAngles.z);

        wheel_fLeft.transform.Rotate(wheel_fLeftCollider.rpm / 60 * 360 * Time.deltaTime, 0, 0);
        wheel_fRight.transform.Rotate(wheel_fRightCollider.rpm / 60 * 360 * Time.deltaTime, 0, 0);
        wheel_rLeft.transform.Rotate(wheel_rLeftCollider.rpm / 60 * 360 * Time.deltaTime, 0, 0);
        wheel_rRight.transform.Rotate(wheel_rRightCollider.rpm / 60 * 360 * Time.deltaTime, 0, 0);
    }
}

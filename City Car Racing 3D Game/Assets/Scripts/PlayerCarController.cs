using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCarController : MonoBehaviour
{
    [Header("Wheels Collider")]
    public WheelCollider frontRightWheelCollider;
    public WheelCollider frontLeftWheelCollider;
    public WheelCollider rearRightWheelCollider;
    public WheelCollider rearLeftWheelCollider;

    [Header("Wheels Transform")]
    public Transform frontRightWheelTransform;
    public Transform frontLeftWheelTransform;
    public Transform rearRightWheelTransform;
    public Transform rearLeftWheelTransform;

    [Header("Car Engine")]
    public float accelerationForce = 300f;
    public float breakingForce = 3000f;
    private float presentBreakForce = 0f;
    private float presentAcceleration = 0f;

    [Header("Car Steering")]
    public float wheelsTorque = 35f;
    private float presentTurnAngle = 40f;

    [Header("Car Sounds")]
    public AudioSource audioSource;
    public AudioClip accelerationSound;
    public AudioClip slowAccelerationSound;
    public AudioClip stopSound;

    private void Update()
    {
        MoveCar();
        CarSteering();
        ApplyBreaks();
    }

    private void MoveCar()
    {
        //FWD
        frontLeftWheelCollider.motorTorque = presentAcceleration;
        frontRightWheelCollider.motorTorque = presentAcceleration;
        rearLeftWheelCollider.motorTorque = presentAcceleration;
        rearRightWheelCollider.motorTorque = presentAcceleration;

        presentAcceleration = accelerationForce * SimpleInput.GetAxis("Vertical");

        if(presentAcceleration > 0) audioSource.PlayOneShot(accelerationSound, 0.25f);
        else if(presentAcceleration < 0) audioSource.PlayOneShot(slowAccelerationSound, 0.2f);
        else audioSource.PlayOneShot(stopSound, 0.1f);
    }

    private void CarSteering()
    {
        presentTurnAngle = wheelsTorque * SimpleInput.GetAxis("Horizontal");
        frontLeftWheelCollider.steerAngle = presentTurnAngle;
        frontRightWheelCollider.steerAngle = presentTurnAngle;

        SteeringWheels(frontLeftWheelCollider, frontLeftWheelTransform);
        SteeringWheels(frontRightWheelCollider, frontRightWheelTransform);
        SteeringWheels(rearLeftWheelCollider, rearLeftWheelTransform);
        SteeringWheels(rearRightWheelCollider, rearRightWheelTransform);
    }

    void SteeringWheels(WheelCollider wC, Transform wT)
    {
        Vector3 position;
        Quaternion rotation;

        wC.GetWorldPose(out position, out rotation);
        wT.position = position;
        wT.rotation = rotation;
    }

    public void ApplyBreaks()
    {
        StartCoroutine(CarBreaks());
    }

    IEnumerator CarBreaks()
    {
        presentBreakForce = breakingForce;
        
        frontLeftWheelCollider.brakeTorque = presentBreakForce;
        frontRightWheelCollider.brakeTorque = presentBreakForce;
        rearLeftWheelCollider.brakeTorque = presentBreakForce;
        rearRightWheelCollider.brakeTorque = presentBreakForce;

        yield return new WaitForSeconds(2f);

        presentBreakForce = 0f;

        frontLeftWheelCollider.brakeTorque = presentBreakForce;
        frontRightWheelCollider.brakeTorque = presentBreakForce;
        rearLeftWheelCollider.brakeTorque = presentBreakForce;
        rearRightWheelCollider.brakeTorque = presentBreakForce;
    }
}

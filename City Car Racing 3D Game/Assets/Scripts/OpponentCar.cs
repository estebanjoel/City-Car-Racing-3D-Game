using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpponentCar : MonoBehaviour
{
    [Header("Car Engine")]
    public float movingSpeed = 1f;
    public float movingSpeedModifier;
    public float turningSpeed = 50f;
    public float breakSpeed = 12f;

    [Header("Destination var")]
    public Vector3 destination;
    public bool destinationReached;

    private void Update() 
    {
        Drive();
    }
    
    public void Drive()
    {
        if(transform.position != destination)
        {
            Vector3 destinationDirection = destination - transform.position;
            destinationDirection.y = 0;
            float destinationDistance = destinationDirection.magnitude;

            if(destinationDistance>= breakSpeed)
            {
                //Steering
                destinationReached = false;
                Quaternion targetRotation = Quaternion.LookRotation(destinationDirection);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, turningSpeed * Time.deltaTime);

                //Move Vehicle
                transform.Translate(Vector3.forward * (movingSpeed * movingSpeedModifier) * Time.deltaTime);
            }

            else destinationReached = true;

        }
    }
    public void LocateDestination(Vector3 destination)
    {
            this.destination = destination;
            destinationReached = false;
    }
}

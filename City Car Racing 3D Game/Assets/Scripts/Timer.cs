using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [Header("Timer")]
    public int countdownTimer = 5;

    [Header("Things to Stop")]
    public PlayerCarController[] playerCarControllers;
    public OpponentCar[] opponentCars;
    public TextMeshProUGUI timerTMP;
    void Start()
    {
        StartCoroutine("TimerCo");
    }

    void Update()
    {
        if(countdownTimer > 1)
        {
            foreach(PlayerCarController car in playerCarControllers) car.accelerationForce = 0f;
            foreach(OpponentCar car in opponentCars) car.movingSpeed = 0f;
        }

        else if(countdownTimer == 0)
        {
            foreach(PlayerCarController car in playerCarControllers) car.accelerationForce = 300f;
            foreach(OpponentCar car in opponentCars) car.movingSpeed = 1f;
        }
    }


    IEnumerator TimerCo()
    {
        while(countdownTimer > 0)
        {
            timerTMP.text = countdownTimer.ToString();
            yield return new WaitForSeconds(1f);
            countdownTimer--;
        }

        timerTMP.text = "GO";
        yield return new WaitForSeconds(1f);
        timerTMP.gameObject.SetActive(false);
    }
}

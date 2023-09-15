using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

public class Finish : MonoBehaviour
{
    [Header("Finish UI Var")]
    public GameObject finishUI;
    public GameObject playerUI;
    public GameObject playerCar;

    [Header("Win/Lose Status")]
    public TextMeshProUGUI status;

    void Start()
    {
        StartCoroutine(WaitForTheFinishUI());
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            gameObject.GetComponent<BoxCollider>().enabled = false;
            status.text = "You Win!";
            status.color = Color.white;
            StartCoroutine(FinishZoneTimer());            
        }

        else if(other.gameObject.tag == "OpponentCar")
        {
            gameObject.GetComponent<BoxCollider>().enabled = false;
            status.text = "You Lose!";
            status.color = Color.red;
            StartCoroutine(FinishZoneTimer());
        }
    }

    IEnumerator WaitForTheFinishUI()
    {
        gameObject.GetComponent<BoxCollider>().enabled = false;
        yield return new WaitForSeconds(25f);
        gameObject.GetComponent<BoxCollider>().enabled = true;
    }

    IEnumerator FinishZoneTimer()
    {
        finishUI.SetActive(true);
        status.gameObject.SetActive(true);
        playerUI.SetActive(false);
        playerCar.SetActive(false);

        yield return new WaitForSeconds(5f);
        Time.timeScale = 0f;
    }
}

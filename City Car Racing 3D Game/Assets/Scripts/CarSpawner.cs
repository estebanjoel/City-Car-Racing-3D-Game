using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSpawner : MonoBehaviour
{
    public GameObject[] carsToSpawn;

    void Awake()
    {
        carsToSpawn = new GameObject[transform.childCount];
        for(int i = 0; i < carsToSpawn.Length; i++)
        {
            carsToSpawn[i] = transform.GetChild(i).gameObject;
            carsToSpawn[i].SetActive(i == PlayerPrefs.GetInt("CarSelected"));
        } 
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CarSelection : MonoBehaviour
{
    [Header("Button and Canvas")]
    public Button nextButton;
    public Button previousButton;
    public GameObject selectionCanvas;
    public GameObject skipButton;
    public GameObject playButton;

    [Header("Cameras")]
    public GameObject cam1;
    public GameObject cam2;

    [Header("Scene to Load")]
    public string sceneNameToLoad;
    private int _currentCar = 0;
    private GameObject[] _carList;


    private void Awake()
    {
        ChooseCar(_currentCar);
        _carList = new GameObject[transform.childCount];
        selectionCanvas.SetActive(false);
        playButton.SetActive(false);
        cam2.SetActive(false);
    }
    
    void Start()
    {
        _currentCar = PlayerPrefs.GetInt("CarSelected");
        
        for(int i = 0; i < transform.childCount; i++)    
        {
            _carList[i] = transform.GetChild(i).gameObject;
        }

        foreach(GameObject go in _carList) go.SetActive(false);
        if(!_carList[_currentCar].activeInHierarchy) _carList[_currentCar].SetActive(true);
    }

    private void ChooseCar(int index)
    {
        previousButton.interactable = (_currentCar != 0);
        nextButton.interactable = (_currentCar != transform.childCount - 1);
        for(int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(i == index);
        }
    }

    public void SwitchCar(int carToSwitch)
    {
        _currentCar += carToSwitch;
        ChooseCar(_currentCar);
    }

    public void PlayGame()
    {
        PlayerPrefs.SetInt("CarSelected", _currentCar);
        SceneManager.LoadScene(sceneNameToLoad);
    }

    public void SkipButton()
    {
        selectionCanvas.SetActive(true);
        playButton.SetActive(true);
        skipButton.SetActive(false);
        cam1.SetActive(false);
        cam2.SetActive(true);
    }
}

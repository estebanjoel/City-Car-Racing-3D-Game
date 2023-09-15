using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionCameraController : MonoBehaviour
{
    public CarSelection carSelection;

    public void EndTransition()
    {
        carSelection.SkipButton();
    }
}

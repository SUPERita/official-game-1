using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonClickMovement : MonoBehaviour
{
    [SerializeField] RectTransform background;
    private Vector3 startingRectTransformPosition;

    private void Start()
    {
        startingRectTransformPosition = GetComponent<RectTransform>().position;
        if (background == null) { Debug.Log("no background RectTransform set for: " + name); }
    }

    public void ShiftBack()
    {
        GetComponent<RectTransform>().position = background.position;
        GetComponent<Button>().enabled = false;
        //Invoke("ShiftForward", 1);
    }

    public void ShiftForward()
    {
        GetComponent<RectTransform>().position = startingRectTransformPosition;
        GetComponent<Button>().enabled = true;
    }
    
}

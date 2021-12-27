using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopButtonShift : MonoBehaviour
{
    [SerializeField] RectTransform background;
    private Vector3 startingRectTransformPosition;

    private void Start()
    {
        startingRectTransformPosition = GetComponent<RectTransform>().localPosition;
        if (background == null) { Debug.Log("no background RectTransform set for: " + name); }
        //Debug.Log("saved position " + startingRectTransformPosition);
    }

    public void ShiftBack()
    {
        GetComponent<RectTransform>().position = background.position;
        GetComponent<Button>().enabled = false;
        Invoke("ShiftForward", 0.5f);
    }

    public void ShiftForward()
    {
        GetComponent<RectTransform>().localPosition = startingRectTransformPosition;
        GetComponent<Button>().enabled = true;
    }
}

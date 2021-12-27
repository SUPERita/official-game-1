using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestClass : MonoBehaviour
{


    public void ShakeCamera(int A)
    {
        CameraShakeV2.Instance.Shake(A, 0.025f, 0.125f);
        Debug.Log("HELLO");
    }
}

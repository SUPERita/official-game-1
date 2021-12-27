using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeetTouchingScript : MonoBehaviour
{

    [SerializeField] ButtonClickMovement bcm;

    private void OnTriggerEnter(Collider other)
    {
        bcm.ShiftForward();
        CameraShakeV2.Instance.Shake(1, 0.025f, 0.1f);
    }

}

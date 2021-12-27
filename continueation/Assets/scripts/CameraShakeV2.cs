using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShakeV2 : MonoBehaviour
{
    public static CameraShakeV2 Instance { get; private set; }
    private Quaternion startingRotation;

    private float amplitude, speed, time;
    private float stopTime = 0;
    

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        startingRotation = transform.rotation;
    }

    public void Shake(float amplitude, float speed, float time)
    {
        this.amplitude = amplitude;
        this.speed = speed;
        this.time = time;
        stopTime = Time.time + time;
        StartCoroutine("shake");
        //transform.Rotate = new Quaternion(transform.rotation.x, transform.rotation.y + 10, transform.rotation.z, transform.rotation.w);
    }

    IEnumerator shake()
    {
        RotateBack();
        Vector3 RotateTo = new Vector3(Random.Range(0, amplitude), Random.Range(0, amplitude), Random.Range(0, amplitude));
        transform.Rotate(RotateTo);
        if (amplitude > 0)
        {
            amplitude -= 0.1f;
        }

        yield return new WaitForSeconds(speed);

        if (Time.time < stopTime)
        {
            StartCoroutine("shake");
        } else
        {
            RotateBack();
        }

    }

    private void RotateBack()
    {
        transform.rotation = startingRotation;
    }

}

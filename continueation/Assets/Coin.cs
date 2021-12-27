using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Coin : MonoBehaviour
{
    [SerializeField] AudioClip sound;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerMovement>() != false)
        {
            GameManager.Instance.AddCash(20);
            gameObject.AddComponent<AudioSource>();
            gameObject.GetComponent<AudioSource>().clip = sound;
            gameObject.GetComponent<AudioSource>().Play();
            //WORDS BUT DIES BEFORE IT CAN START, make an outside audioManager (script already there) and do it there . also follow brakey's tutorial
            Destroy(gameObject);
        }
    }
}

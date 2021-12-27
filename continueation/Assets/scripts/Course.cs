using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Course : MonoBehaviour
{
    private Transform trans;
    private Transform player;

    private void Start()
    {
        trans = this.transform;
        player = GameManager.Instance.GetPlayerTransform();
    }
    void Update()
    {
        if (trans.position.z + 60 < player.position.z)
        {
            Destroy(gameObject);
        }
    }
}

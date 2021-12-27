using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraObjectDeleting : MonoBehaviour
{
    
    private Transform trans;
    [SerializeField] Transform playerTrans;
    [SerializeField] Material obstMat;
    private Color startingObstColor;

    private void Start()
    {
        trans = this.GetComponent<Transform>();
        startingObstColor = obstMat.color;
    }

    void Update()
    {
        RaycastHit hit;
        Vector3 fromPosition = trans.position;
        Vector3 toPosition = playerTrans.position;
        Vector3 direction = toPosition - fromPosition;


        if (Physics.Raycast(fromPosition, direction, out hit))
        {
            if (hit.collider.gameObject.GetComponent<Obstacle>() != null)
            {
                print("ray just hit the gameobject: " + hit.collider.gameObject.name);
                obstMat.color = new Color(startingObstColor.r, startingObstColor.b, startingObstColor.g, 0);
                print("set");
            } else
            {
                obstMat.color = startingObstColor;
            }
        }

          
    }
        

}

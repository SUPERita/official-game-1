using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float speed = 40f;
    [SerializeField] float turnSpeed = 25f;
    [SerializeField] float jumpForce = 1000f;
    [SerializeField] Joystick joystick;
    [SerializeField] float speedUpTimer = 10f;
    public float startingSpeed;
    
    
    private Vector2 movement;

    Rigidbody rb;
    private void Awake()
    {
        startingSpeed = speed;
    }
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        NullChecks();
       
    }

    void Update()
    {
        
        //Debug.Log(rb.velocity);


        movement.x = joystick.Horizontal;
        movement.y = joystick.Vertical;


    }

    private void FixedUpdate()
    {

        movement.x = joystick.Horizontal * turnSpeed;
        movement.y = joystick.Vertical * turnSpeed;

        //Debug.Log(movement.x);

        rb.AddForce(new Vector3(movement.x, 0, speed));

        if (transform.position.y < -10f)
        {
            Die();
        }
    }

    public void Jump()
    {
        
        rb.AddForce(new Vector3(0, jumpForce, 0));
    }

    private void NullChecks()
    {
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Obstacle>() != null)
        {
            Die();

        }
    }

    private void Die()
    {
        GameManager.Instance.PlayerDied();
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<Rigidbody>().isKinematic = true;

        CameraShakeV2.Instance.Shake(5, 0.05f, 1f);

        this.enabled = false;
    }

    public void Respawn()
    {
        GetComponent<MeshRenderer>().enabled = true;
        GetComponent<Rigidbody>().isKinematic = false;
        speed = startingSpeed;
    }

    public void SpeedUp()
    {
        speed += 0.1f;
    }



}

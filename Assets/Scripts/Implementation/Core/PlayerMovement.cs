using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controls;

    public float speed = 12f;
    public float grav = -9.81f;
    public float jumph = 1f;

    public Transform groundcheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    
    Vector3 velocity;
    bool isgrounded;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        updateLocation();
    }

    void updateLocation()
    {
        isgrounded = Physics.CheckSphere(groundcheck.position, groundDistance, groundMask);

        if (isgrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        if (velocity.x > 0 || velocity.z > 0)
        {

        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controls.Move(move * speed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isgrounded)
        {
            velocity.y = Mathf.Sqrt(jumph * -2f * grav);
        }

        velocity.y += grav * Time.deltaTime;

        controls.Move(velocity * Time.deltaTime);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{

    public float speed_y = 0.0f;
    float speed_z = 3.5f;
    CharacterController controller;

    Vector2 input;
    float camera_rotation_speed = 15.0f;
    Camera my_camera;

    public bool is_grounded = false;
    float gravity = 20.0f;
    float jump_speed = 11.0f;

    // Start is called before the first frame update
    void Start()
    {
        controller = gameObject.GetComponent<CharacterController>();
        my_camera = Camera.main;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        
    }

    // Update is called once per frame
    void Update()
    {
        input.x = Input.GetAxis("Horizontal");
        input.y = Input.GetAxis("Vertical");


        float finalSpeedY = speed_z;
        controller.Move(transform.forward * finalSpeedY * Time.deltaTime);
        

        if(!is_grounded)
        {
            speed_y -= gravity * Time.deltaTime;
        }

        if (is_grounded && Input.GetButtonDown("Jump"))
        {
            speed_y = jump_speed;
            is_grounded = false;
        }

        controller.Move(transform.up * speed_y * Time.deltaTime);
    }

    private void FixedUpdate()
    {
        float yaw = my_camera.transform.rotation.eulerAngles.y;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, yaw, 0), camera_rotation_speed * Time.fixedDeltaTime);
    }
}

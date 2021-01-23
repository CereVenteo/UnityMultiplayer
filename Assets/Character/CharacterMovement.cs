using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{

    public float speed_x = 6.0f;
    public float speed_y = 0.0f;
    public float speed_z = 6.0f;
    CharacterController controller;

    Vector2 input;
    float camera_rotation_speed = 15.0f;
    Camera my_camera;

    public bool is_grounded = false;
    public float gravity = 9.8f;
    public float jump_speed = 20.0f;

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


        if (input.y != 0)
        {
            float finalSpeedY = input.y >= 0.01f ? speed_z : 0.0f;
            controller.Move(transform.forward * finalSpeedY * Time.deltaTime);
        }

        if (input.x != 0)
        {
            float finalSpeedX = input.x >= 0.01f ? speed_x : -speed_x;
            controller.Move(transform.right * finalSpeedX * Time.deltaTime);
        }

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

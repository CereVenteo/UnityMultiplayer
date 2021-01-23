using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundChecker : MonoBehaviour
{

    CharacterMovement character_movement;
    // Start is called before the first frame update
    void Start()
    {
        character_movement = gameObject.GetComponentInParent<CharacterMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            character_movement.is_grounded = true;
            character_movement.speed_y = 0;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            character_movement.is_grounded = false;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            character_movement.is_grounded = true;
        }
    }
}

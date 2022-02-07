using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverDoorController : MonoBehaviour
{
    [SerializeField] private Animator myDoor = null;
    [SerializeField] private bool openTrigger = false;
    [SerializeField] private bool closeTrigger = false;
    private bool doorOpen = false;
    private bool playerInRadius = false;

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.F) && playerInRadius == true)
        {
          
            if (doorOpen == false)
            {
                myDoor.Play("DoorOpen", 0, 0.0f);
                doorOpen = true;
            }
            else if (doorOpen == true)
            {
                myDoor.Play("DoorClose", 0, 0.0f);
                doorOpen = false;

            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player") || other.CompareTag("Shadow"))
        {
            playerInRadius = true;

        }
    }

    private void OnTriggerExit(Collider other)
    {

        if (other.CompareTag("Player") || other.CompareTag("Shadow"))
        {
            playerInRadius = false;

        }
    }
}


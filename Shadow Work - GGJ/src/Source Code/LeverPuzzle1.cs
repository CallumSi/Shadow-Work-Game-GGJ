using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverPuzzle1 : MonoBehaviour
{
    [SerializeField] private Animator myWall = null;
 
    [SerializeField] private bool openTrigger = false;
    [SerializeField] private bool closeTrigger = false;
    private bool wallUp = false;
    private bool playerInRadius = false;
    


    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.F) && playerInRadius == true)
        {
          
            if (wallUp == false)
            {
                myWall.Play("wardrobeUp", 0, 0.0f);
                wallUp = true;
            }
            else if (wallUp == true)
            {
                myWall.Play("wardrobeDown", 0, 0.0f);
                wallUp = false;

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


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DDControllerA : MonoBehaviour
{
    [SerializeField] private Animator myDoor1 = null;
    [SerializeField] private Animator myDoor2 = null;
    [SerializeField] private bool Door1Triggered = false;
    [SerializeField] private bool DoorsOpened= false;
    public GameObject Door1;
    public GameObject Door2;
    public GameObject pressureplateB;
    private DDControllerB controller;
    public GameObject jenny;
    private ChangePlayer jennycontroller;
    private void Start()
    {
        
        jennycontroller = jenny.GetComponent<ChangePlayer>();
        controller = pressureplateB.GetComponent<DDControllerB>();
        

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
                Door1Triggered = true;
                Debug.Log("1 triggered");
           
         
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
           
                Door1Triggered = false;
                Debug.Log("1 untri  ggered ");
 
        }
    }

    private void Update()
    {
        //if (Input.GetKeyDown(KeyCode.E))
        //{

            if (Door1Triggered == true && controller.Door2Triggered == true && DoorsOpened == false)
            {


                Door1.GetComponentInChildren<MeshCollider>().enabled = false;
                Door2.GetComponentInChildren<MeshCollider>().enabled = false;
                Debug.Log("Opening door");
                myDoor1.Play("DOpen", 0, 0.0f);
                myDoor2.Play("DOpen", 0, 0.0f);
                DoorsOpened = true;
                jennycontroller.syncPlayers();
            }
        //}



    }
}

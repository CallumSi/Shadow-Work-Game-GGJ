using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class ChangePlayer : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject otherPlayer;
    public GameObject g1;
    public CinemachineVirtualCamera vcam;
    public Transform tFollowTarget;
    private void OnMouseDown()
    {

        otherPlayer.GetComponent<PlayerMovement>().enabled = false;
        GetComponent<PlayerMovement>().enabled = true;

        if (gameObject.tag == "Shadow")
        {
            g1 = GameObject.Find("ShadowJenny");
            tFollowTarget = g1.transform;
            vcam.Follow = tFollowTarget;
        }
        else if (gameObject.tag == "Player")
        {
            g1 = GameObject.Find("Jenny");
            tFollowTarget = g1.transform;
            vcam.Follow = tFollowTarget;

        }
    }
    private void Start()
    {
        
    }
    void Update()
        {
            if (Input.GetKeyDown(KeyCode.E))
            {

            syncPlayers();

            }
    }

    public void syncPlayers()
    {
        otherPlayer.GetComponent<PlayerMovement>().enabled = true;
        GetComponent<PlayerMovement>().enabled = true;
        g1 = GameObject.Find("Jenny");
        tFollowTarget = g1.transform;
        vcam.Follow = tFollowTarget;
    }
}

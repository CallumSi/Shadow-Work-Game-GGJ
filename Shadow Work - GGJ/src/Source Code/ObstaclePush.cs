using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclePush : MonoBehaviour
{
    [SerializeField] private float forceMagnitude;
    private CharacterController controller;
    private Animator anim;
    public bool CanPush = false;
    private void Start()
    {
        controller = GetComponent<CharacterController>();
        anim = GetComponentInChildren<Animator>();

    }


    void Update()
    {
        CanPush = false;
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Rigidbody rigidbody = hit.collider.attachedRigidbody;
        if (rigidbody != null)
        {
            CanPush= true;
            Vector3 forceDirection = hit.gameObject.transform.position - transform.position;
            forceDirection.y = 0;
            forceDirection.Normalize();
            rigidbody.AddForceAtPosition(forceDirection * forceMagnitude, transform.position, ForceMode.Impulse);
        }

        //if (Input.GetKey(KeyCode.D))
        //{
        //    pushingRight();
        //}

        //else if (!Input.GetKey(KeyCode.D))
        //{
        //    anim.SetBool("pushingRight", false);
        //}
        //if (Input.GetKey(KeyCode.A))
        //{
        //    pushingLeft();
        //}

        //else if (!Input.GetKey(KeyCode.A))
        //{
        //    anim.SetBool("pushingLeft", false);
        //}
    }



    private void pushingLeft()
    {
        anim.SetBool("pushingLeft", true);
    }
    private void pushingRight()
    {
        anim.SetBool("pushingRight", true);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DDControllerB : MonoBehaviour
{
 
    [SerializeField] public bool Door2Triggered = false;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Shadow"))
        {
           
       
                Door2Triggered = true;
                Debug.Log("2 triggered");
      
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Shadow"))
        {
         

                Door2Triggered = false;
                Debug.Log("2 untriggered");
            
        }
    }


}

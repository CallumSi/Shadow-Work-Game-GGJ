using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectKey : MonoBehaviour
{
    private LevelController pm;
    public GameObject player; 
    private void Start()
    {
        pm = player.GetComponent<LevelController>();
    }
    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Shadow") && gameObject.tag == "shadowKey")
        {
            Debug.Log("collide");
            pm.shadowKey = true;
            Destroy(gameObject);

        }
        if (other.CompareTag("Player") && gameObject.tag == "realKey")
        {
            Debug.Log("collide");
            pm.realKey = true;
            Destroy(gameObject);

        }
    }
 
}

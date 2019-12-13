using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    float yRotation;
    float charRot;
    //public GameObject player;
    void Start()
    {
        
    }

    void Update()
    {
        yRotation = FindObjectOfType<PlayerMovement>().transform.eulerAngles.y;
        //charRot = GetComponent<PlayerMovement>().characterRotation.transform.eulerAngles.y;
        //Debug.Log(charRot);
    }
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Player") && (yRotation == 90 || yRotation >= 270))
        {
            FindObjectOfType<PlayerMovement>().rotate();
            //Debug.Log("Entered Trigger!");
        }        
    }
}

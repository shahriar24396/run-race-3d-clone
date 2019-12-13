using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiveAnimation : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Player"))
        {
            Debug.Log("PLAY DIVE ANIMATION");
            FindObjectOfType<PlayerMovement>().dive();
        }
    }
}

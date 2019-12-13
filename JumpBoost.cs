using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpBoost : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject player;
    public float jumpForce;
    public float horizontalJumpForce;
    public bool playerTriggered = false;
    void Start()
    {
        player = GameObject.Find("PlayerWorking");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Player"))
        {
            Debug.Log("JUMP BOOST");
            jump();
            playerTriggered = true;
        }
        
        //if (collider.CompareTag("Player"))
        //{
        //    Debug.Log("JUMP BOOST");
        //    FindObjectOfType<PlayerMovement>().jump();
        //}
    }

    public void jump()
    {
        //rb.AddForce(new Vector3(0f, jumpForce, 0f));
        player.GetComponent<Rigidbody>().velocity = (new Vector3(-horizontalJumpForce, jumpForce, 0f));        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBoost : MonoBehaviour
{
    // Start is called before the first frame update
    float playerVelocity;
    GameObject playerChar;
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
            playerChar = collider.gameObject;
            boost(playerChar);
        }
    }

    public void boost(GameObject player)
    {
        player.GetComponentInParent<Rigidbody>().AddRelativeForce(Vector3.right * 100f);
        //Debug.Log("BOOSTED!");
    }
}

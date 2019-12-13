using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{
    // Start is called before the first frame update
    public int lapCount = 1;
    public int finishLap = 1;
    public bool isLevelComplete;
    public GameObject player;
    void Start()
    {
        isLevelComplete = FindObjectOfType<PlayerMovement>().levelComplete;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Player"))
        {
            lapCount++;
            //Debug.Log("Crossed finish line!");
            //Debug.Log("Lap " + lapCount);

            if (lapCount == finishLap + 1)
            {
                lapCount--;
                //Debug.Log("LEVEL COMPLETE!!!");
                player.GetComponent<PlayerMovement>().enabled = false;
                isLevelComplete = true;
            }
        }
    }
}

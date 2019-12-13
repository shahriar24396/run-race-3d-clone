using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class End : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject levelCompleteText;
    private GameObject player;
    private GameObject splashEffect;
    public float dragValue = 5f;
    public float floatSpeed = 5f;
    private bool isUnderwater = false;
    private Vector3 playerVelocity;
    private Rigidbody playerRb;
    public Material playerMat;
    public float floatDelay = 5f;
    void Start()
    {
        splashEffect = GameObject.Find("WaterSplash");
        player = GameObject.Find("PlayerWorking");
        splashEffect.SetActive(false);
        playerVelocity = player.GetComponent<Rigidbody>().velocity;
        playerRb = player.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isUnderwater)
        {
            //playerVelocity = new Vector3(0f, 500f * 0.95f * Time.deltaTime, 500f * 0.95f * Time.deltaTime);
            //Invoke("UnderwaterFloatMovementLeft", 0.25f);
            //Invoke("UnderwaterFloatMovementRight", 0.5f);
            Invoke("UnderwaterFloatMovementUp", floatDelay);
        }
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Player"))
        {
            //FindObjectOfType<PlayerMovement>().moveSpeed = 0f;
            //FindObjectOfType<Animator>().enabled = false;
            isUnderwater = true;
            splashEffect.SetActive(true);
            splashEffect.transform.position = player.transform.position;
            levelCompleteText.SetActive(true);
            player.GetComponent<Rigidbody>().drag = dragValue;
            Debug.Log("END");            
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider.CompareTag("Player"))
        {
            isUnderwater = false;
            GameObject.Find("FloatBarrier").GetComponent<BoxCollider>().enabled = true;
        }
    }

    void UnderwaterFloatMovementLeft()
    {
        playerRb.AddRelativeForce(Vector3.right * floatSpeed * Time.deltaTime);
    }

    void UnderwaterFloatMovementRight()
    {
        playerRb.AddRelativeForce(Vector3.left * floatSpeed * Time.deltaTime);
    }

    void UnderwaterFloatMovementUp()
    {
        playerRb.AddRelativeForce(Vector3.up * floatSpeed * Time.deltaTime);
        floatDelay = 0.2f;
    }
}
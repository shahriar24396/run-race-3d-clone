using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationAdjust : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject character;
    private float charRotation;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //charRotation = character.transform.eulerAngles.y;
        //Debug.Log(charRotation);
    }

    private void OnTriggerEnter(Collider collider)
    {
        charRotation = character.transform.eulerAngles.y;
        //Debug.Log(charRotation);

        if (collider.CompareTag("Player") && (charRotation < 1))
        {
            character.transform.Rotate(new Vector3(0f, 180f, 0f));
            //Debug.Log("ROTATION ADJUSTED!");
        }
    }
}

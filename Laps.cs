using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Laps : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject lapCounter;
    public Text lapText;

    // Update is called once per frame
    void Update()
    {
        lapText.text = "LAP " + lapCounter.GetComponent<Finish>().lapCount.ToString() + "/" + lapCounter.GetComponent<Finish>().finishLap.ToString();
    }
}

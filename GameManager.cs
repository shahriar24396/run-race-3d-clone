using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject finishLine;
    public GameObject levelCompleteText;
    public GameObject youWinText;
    public GameObject youLoseText;
    public GameObject retryButton;
    public GameObject nextButton;

    void Start()
    {
        levelCompleteText.SetActive(false);
        retryButton.SetActive(false);
        nextButton.SetActive(false);
        youWinText.SetActive(false);
        youLoseText.SetActive(false);
    }

    void Update()
    {
        if (finishLine.GetComponent<Finish>().isLevelComplete)
        {
            levelCompleteText.SetActive(true);
            retryButton.SetActive(true);
            nextButton.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }            
    }

    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Next()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}

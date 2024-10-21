using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    Quiz_scr quiz;
    EndScreen_scr endScreen;
    void Awake()
    {
        quiz = FindAnyObjectByType<Quiz_scr>();
        endScreen = FindAnyObjectByType<EndScreen_scr>();
    }
    void Start()
    {
        quiz.gameObject.SetActive(true);
        endScreen.gameObject.SetActive(false);        
    }
    void Update()
    {
        if (quiz.isFinish)
        {
            quiz.gameObject.SetActive(false);
            endScreen.gameObject.SetActive(true);
            endScreen.ShowFinalScore();
        }
    }
    public void OnReplayLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}

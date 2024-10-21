using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EndScreen_scr : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI finalScoreText;
    ScoreKeeper_scr scoreKeep;
    void Awake()
    {
        scoreKeep = FindAnyObjectByType<ScoreKeeper_scr>();        
    }
    public void ShowFinalScore()
    {
        finalScoreText.text = "Congratulations!\nYou got a score of " +
                                scoreKeep.CalculateScore();
    }
}

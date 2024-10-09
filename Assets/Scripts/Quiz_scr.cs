using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Quiz_scr : MonoBehaviour
{
    [SerializeField] QuestionSO question;
    [SerializeField] TextMeshProUGUI questionText;

    void Start()
    {
        questionText.text = question.GetQuestion();
    }
}

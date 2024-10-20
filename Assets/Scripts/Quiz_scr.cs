using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Quiz_scr : MonoBehaviour
{
    [Header("Questions")]
    [SerializeField] QuestionSO question;
    [SerializeField] TextMeshProUGUI questionText;
    [Header("Answers")]
    [SerializeField] GameObject[] answerButtons;
    int correctAnswerIndex;
    bool answeredEarly;
    [Header("Buttons")]
    [SerializeField] Sprite defaultAnswerSprite;
    [SerializeField] Sprite correctAnswerSprite;
    [Header("Timer")]
    [SerializeField] Image timerImage;
    Timer_scr timer;

    void Start()
    {
        GetNextQuestion();
        timer = FindObjectOfType<Timer_scr>();
    }
    void Update()
    {
        timerImage.fillAmount = timer.fillFraction;
        if (timer.loadNextQ)
        {
            answeredEarly = false;
            GetNextQuestion();
            timer.loadNextQ = false;
        }
        else if (!answeredEarly && !timer.isAnswering)
        {
            DisplayAnswer(-1);
            SetButtonState(false);
        }
    }
    public void OnAnswerSelected(int index)
    {
        answeredEarly = true;
        DisplayAnswer(index);
        SetButtonState(false);
        timer.CancelTimer();
    }
    void DisplayAnswer(int index)
    {
        Image buttonImage;
        if (index == question.GetCorrectIndex())
        {
            questionText.text = "Correct!";
            buttonImage = answerButtons[index].GetComponent<Image>();
            buttonImage.sprite = correctAnswerSprite;
        }
        else
        {
            correctAnswerIndex = question.GetCorrectIndex();
            string correctAnswer = question.GetAnswer(correctAnswerIndex);
            questionText.text = "Sorry, the correct answer was\n" + correctAnswer;
            buttonImage = answerButtons[correctAnswerIndex].GetComponent<Image>();
            buttonImage.sprite = correctAnswerSprite;
        }
    }
    private void GetNextQuestion()
    {
        SetButtonState(true);
        SetDefaultButtonSprites();
        DisplayQuestion();
    }
    private void DisplayQuestion()
    {
        questionText.text = question.GetQuestion();
        for(int i = 0; i < answerButtons.Length; i++)
        {
            TextMeshProUGUI buttonText = answerButtons[i].GetComponentInChildren<TextMeshProUGUI>();
            buttonText.text = question.GetAnswer(i);
        }
    }
    private void SetButtonState(bool state)
    {
        for(int i = 0; i < answerButtons.Length; i++)
        {
            Button button = answerButtons[i].GetComponent<Button>();
            button.interactable = state;
        }
    }
    private void SetDefaultButtonSprites()
    {
        for(int i = 0; i < answerButtons.Length; i++)
        {
            Image buttonImage = answerButtons[i].GetComponent<Image>();
            buttonImage.sprite = defaultAnswerSprite;
        }
    }
}

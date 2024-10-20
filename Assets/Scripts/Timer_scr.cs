using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Timer_scr : MonoBehaviour
{
    [SerializeField] float timeToComplete = 30f;
    [SerializeField] float timeToReveal = 10f;
    public bool isAnswering = false;
    float timerVal;

    void Update()
    {
        UpdateTimer();
    }
    void UpdateTimer()
    {
        timerVal -= Time.deltaTime;
        if (timerVal <= 0)
        {
            if (isAnswering)
            {
                timerVal = timeToReveal;
                isAnswering = false;
            }
            else
            {
                timerVal = timeToComplete;
                isAnswering = true;
            }
        }
        Debug.Log(timerVal);
    }
}

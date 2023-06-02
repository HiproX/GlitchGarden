using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class ScoreDisplay : MonoBehaviour
{
    public enum Status { Success, Failure }
    public int count = 5;
    private Text scoreLabel;
    void Start()
    {
        if (count == 0)
        {
            Debug.LogWarning("Когда начальный счет равен нулю, игрок не сможет спавнить защитников");
        }

        scoreLabel = GetComponent<Text>();
        scoreLabel.text = count.ToString();
    }
    
    public void AddStars(int amount)
    {
        count += amount;
        UpdateDisplay();
    }

    public Status UseStars(int amount)
    {
        if (count >= amount)
        {
            count -= amount;
            UpdateDisplay();
            return Status.Success;
        }
        return Status.Failure;
    }

    private void UpdateDisplay()
    {
        scoreLabel.text = count.ToString();
    }
}

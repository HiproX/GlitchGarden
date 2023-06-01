using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class ScoreDisplay : MonoBehaviour
{
    private Text scoreLabel;
    public int count;
    void Start()
    {
        scoreLabel = GetComponent<Text>();
        scoreLabel.text = count.ToString();
    }
    
    public void AddStars(int amount)
    {
        count += amount;
        UpdateDisplay();
    }

    public void UseStars(int amount)
    {
        count -= amount;
        UpdateDisplay();
    }

    private void UpdateDisplay()
    {
        scoreLabel.text = count.ToString();
    }
}

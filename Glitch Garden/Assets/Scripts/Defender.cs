using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class Defender : MonoBehaviour
{
    public int scoreCost = 1;
    private ScoreDisplay score;

    private void Start()
    {
        score = GameObject.FindObjectOfType<ScoreDisplay>();
        if (!score)
        {
            Debug.LogError("Счётчик очков отсутсвует");
        }
    }

    private void AddStars(int amount)
    {
        score.AddStars(amount);
    }
}

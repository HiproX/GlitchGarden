using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseCollider : MonoBehaviour
{
    public int MaxNumberOfPasses = 1;
    private int count;
    LevelManager levelManager;

    private void Start()
    {
        levelManager = GameObject.FindObjectOfType<LevelManager>();
        if (!levelManager)
        {
            Debug.LogWarning($"LevelManager отсуствует в текущей сцене #{SceneManager.sceneCount}");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var entity  = collision.gameObject;
        if (entity.GetComponent<Attacker>())
        {
            ++count;
            if (count >= MaxNumberOfPasses)
            {
                if (levelManager)
                {
                    levelManager.LoadLevel("03b Lose");
                }
                else
                {
                    Debug.LogWarning($"Экран порожения не будет загружен, т.к. LevelManager отсуствует в текущей сцене #{SceneManager.sceneCount}");
                }
            }

        }
    }
}

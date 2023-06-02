using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
    public float levelSeconds = 100f;
    private AudioSource audioSource;
    private Slider slider;
    private LevelManager levelManager;
    private GameObject winLabel;
    private bool isEndOfLevel = false;

    void Start()
    {
        slider = GetComponent<Slider>();
        audioSource = GetComponent<AudioSource>();
        
        winLabel = GameObject.Find("You Win");
        if (!winLabel)
        {
            Debug.LogWarning("В текущей сцене отсутствует игровой объект 'You Win' типа Text");
        }
        winLabel.SetActive(false);

        levelManager = GameObject.FindObjectOfType<LevelManager>();
        if (!levelManager)
        {
            Debug.LogWarning($"LevelManager отсуствует в текущей сцене #{SceneManager.sceneCount}");
        }
        
    }

    void Update()
    {
        UpdateTimer();

        bool timeIsUp = Time.timeSinceLevelLoad >= levelSeconds;
        if (timeIsUp && !isEndOfLevel)
        {
            isEndOfLevel = true;
            audioSource.Play();
            StopSpawning();
            StopAttacking();
            winLabel.SetActive(true);
            Invoke("LoadNextLevel", audioSource.clip.length);
        }
    }

    private void StopAttacking()
    {
        foreach(var entity in GameObject.FindObjectsOfType<Attacker>())
        {
            Debug.Log(entity.name);
            var animator = entity.GetComponent<Animator>();
            animator.SetTrigger("Stop Trigger");
        }

    }

    private void StopSpawning()
    {
        foreach(var spawner in GameObject.FindObjectsOfType<Spawner>())
        {
            spawner.gameObject.SetActive(false);
        }
    }

    private void UpdateTimer()
    {
        float value = Time.timeSinceLevelLoad / levelSeconds;
        slider.value = value;
    }

    private void LoadNextLevel()
    {
        if (!levelManager)
        {
            Debug.LogWarning($"Следующий уровень не будет загружен, т.к. LevelManager отсуствует в текущей сцене #{SceneManager.sceneCount}");
            return;
        }
        levelManager.LoadNextLevel();
    }
}

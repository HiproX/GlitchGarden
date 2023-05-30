using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public float autoLoadNextLevelAfter;
    private void Start()
    {

        if (autoLoadNextLevelAfter <= 0)
        {
            Debug.Log("Автозагрузка уровней отключена, используйте положительное число");
        }
        else
        {
            Invoke("LoadNextLevel", autoLoadNextLevelAfter);
        }
    }
    public void LoadLevel(string name)
    {
        Debug.Log($"Запрошена загрузка уровня для {name}");
        SceneManager.LoadScene(name);
    }
    public void QuitRequest()
    {
        Debug.Log($"Я хочу выйти");
        Application.Quit();
    }
    public void BackToMenu()
    {
        SceneManager.LoadScene("Start");
    }
    public void LoadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}

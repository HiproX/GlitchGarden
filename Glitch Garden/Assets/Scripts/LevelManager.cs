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
        Invoke("LoadNextLevel", autoLoadNextLevelAfter);
    }
    public void LoadLevel(string name)
    {
        Debug.Log($"«апрошена загрузка уровн€ дл€ {name}");
        SceneManager.LoadScene(name);
    }
    public void QuitRequest()
    {
        Debug.Log($"я хочу выйти");
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

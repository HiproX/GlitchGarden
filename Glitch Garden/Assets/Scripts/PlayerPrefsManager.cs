using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerPrefsManager : MonoBehaviour
{
    const string MASTER_VOLUME_KEY = "master_volume";
    const string DIFFICULTY_KEY = "difficulty";
    const string LEVEL_KEY = "level_unlocked_";
    public static void SetMasterVolume(float volume)
    {
        if (volume >= 0f && volume <= 1.0f)
        {
            PlayerPrefs.SetFloat(MASTER_VOLUME_KEY, volume);
        }
        else
        {
            Debug.LogError("Громкость вне диапазона");
        }
    }
    public static float GetMasterVolume()
    {
        return PlayerPrefs.GetFloat(MASTER_VOLUME_KEY);
    }
    public static void UnlockLevel(int level)
    {
        if (level >= 0 && level <= SceneManager.sceneCount - 1)
        {
            PlayerPrefs.SetInt($"{LEVEL_KEY}{level}", 1); // 1 == true
        }
        else
        {
            Debug.LogError("Попытка разблокировки некоректного уровня");
        }
    }
    public static bool IsLevelUnlocked(int level)
    {
        if (level < 0 || level > SceneManager.sceneCount - 1)
        {
            Debug.LogError("Попытка запросить некоректный уровень");
        }
        return level >= 0 && level <= SceneManager.sceneCount - 1 &&
            PlayerPrefs.GetInt($"{LEVEL_KEY}{level}") == 1;
    }
    public static void SetDifficulty(float difficulty)
    {
        if (difficulty >= 1f && difficulty <= 3.0f)
        {
            PlayerPrefs.SetFloat(DIFFICULTY_KEY, difficulty);
        }
        else
        {
            Debug.LogError("Сложность вне диапазано");
        }
    }
    public static float GetDifficulty()
    {
        return PlayerPrefs.GetFloat(DIFFICULTY_KEY);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class OptionsController : MonoBehaviour
{
    public Slider volumeSlider;
    public Slider difficultySlider;
    public LevelManager levelManager;
    private PersistentMusicManager musicManager;
    // Start is called before the first frame update
    void Start()
    {
        musicManager = GameObject.FindObjectOfType<PersistentMusicManager>();
        if (musicManager)
        {
            Debug.Log($"[PersistentMusicManager:{musicManager.GetInstanceID()}] найден!");
        }
        else
        {
            Debug.LogError("PersistentMusicManager в текущей сцене не найден");
        }

        volumeSlider.value = PlayerPrefsManager.GetMasterVolume();
        difficultySlider.value = PlayerPrefsManager.GetDifficulty();
    }

    // Update is called once per frame
    void Update()
    {
        musicManager.ChangeVolume(volumeSlider.value);
    }
    public void SaveAndExit()
    {
        PlayerPrefsManager.SetMasterVolume(volumeSlider.value);
        PlayerPrefsManager.SetDifficulty(difficultySlider.value);

        levelManager.LoadLevel("01a Start");
    }
    public void SetDefautls()
    {
        volumeSlider.value = 0.8f;
        difficultySlider.value = 2.0f;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetStartVolume : MonoBehaviour
{
    private PersistentMusicManager musicManager;
    // Start is called before the first frame update
    void Start()
    {
        musicManager = GameObject.FindObjectOfType<PersistentMusicManager>();
        if (musicManager)
        {
            Debug.Log($"[PersistentMusicManager:{musicManager.GetInstanceID()}] найден!");
            musicManager.ChangeVolume(PlayerPrefsManager.GetMasterVolume());
        }
        else
        {
            Debug.LogError("PersistentMusicManager в текущей сцене не найден");
        }

    }
}

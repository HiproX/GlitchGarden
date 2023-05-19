using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersistentMusicManager : MonoBehaviour
{
    public AudioClip[] levelMusicChangeArray;
    private void Awake()
    {
        GameObject.DontDestroyOnLoad(gameObject);
        Debug.Log($"[{gameObject.name}:{gameObject.GetInstanceID()}] Don't destroy on load");
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

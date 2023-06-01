using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] attackerPrefabArray;

    void Update()
    {
        foreach (var attacker in attackerPrefabArray)
        {
            if (attacker)
            {
                if (IsTimeToSpawn(attacker))
                {
                    Spawn(attacker);
                }
            }
        }
    }

    private bool IsTimeToSpawn(GameObject attackerObject)
    {
        var attacker = attackerObject.GetComponent<Attacker>();
        float meanSpawnDelay = attacker.seenEverySecond;
        float spawnPerSeconds = 1 / meanSpawnDelay;

        if (Time.deltaTime > meanSpawnDelay)
        {
            Debug.LogWarning("Частота спавна ограничена частотой кадров");
        }

        float threshold = spawnPerSeconds * Time.deltaTime / 5;
        
        if (Random.value < threshold)
        {
            return true;
        }
        return false;
    }
    
    private void Spawn(GameObject attacker)
    {
        var myAttacker = Instantiate(attacker, transform.position, Quaternion.identity);
        myAttacker.transform.SetParent(transform);
    }
}

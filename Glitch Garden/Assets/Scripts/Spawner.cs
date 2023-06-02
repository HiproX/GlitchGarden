using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] attackerPrefabArray;

    private void Start()
    {
    }

    private void Update()
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

        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 0.2f);
        foreach (Collider2D collider in colliders)
        {
            if (collider.gameObject.GetComponent<Attacker>())
            {
                return false;
            }
        }

        return Random.value < threshold;
    }
    
    private void Spawn(GameObject attacker)
    {
        var myAttacker = Instantiate(attacker, transform.position, Quaternion.identity);
        myAttacker.transform.SetParent(transform);
    }
}

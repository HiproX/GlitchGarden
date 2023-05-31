using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float health = 30f;
    
    public void DealDamage(float damage)
    {
        health -= damage;
        if (health <= 0f)
        {
            DestroyObject();
            Debug.Log(name + " уничтожен");
        }
    }
    
    public void DestroyObject()
    {
        Destroy(gameObject);
    }
    
    public bool IsAlive => health > 0;
}

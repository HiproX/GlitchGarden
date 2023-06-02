using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float health = 30f;
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void DealDamage(float damage)
    {
        if (GetComponent<Stone>())
        {
            animator.SetTrigger("Damaged Trigger");
        }

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

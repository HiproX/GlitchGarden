using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    public GameObject projectile;
    public GameObject gun;
    private GameObject projectileParent;
    private Animator animator;
    private Spawner myLaneSpawner;

    private void Start()
    {
        SetMyLaneSpawner();
        animator = gameObject.GetComponent<Animator>();
        projectileParent = GameObject.Find("Projectiles");

        if (!projectileParent)
        {
            projectileParent = new GameObject("Projectiles");
        }
    }

    private void Update()
    {
        if (IsAttackerAheadInLane)
        {
            animator.SetBool("isAttacking", true);
        }
        else
        {
            animator.SetBool("isAttacking", false);
        }
    }

    private void Fire()
    {
        var newProjectile = Instantiate(projectile);
        newProjectile.transform.SetParent(projectileParent.transform);
        newProjectile.transform.position = gun.transform.position;
    }

    private bool IsAttackerAheadInLane
    {
        get
        {
            if (!myLaneSpawner)
            {
                Debug.LogError($"Отсутствует спавнер врагов на горизонтальной линии с координатами {transform.position.y}");
                return false;
            }
            foreach (Transform enemy in myLaneSpawner.transform)
            {
                if (enemy.position.x <= 9.5f && enemy.position.x > transform.position.x)
                {
                    return true;
                }
            }
            return false;
        }
    }

    private void SetMyLaneSpawner()
    {
        var spawnerArray = GameObject.FindObjectsOfType<Spawner>();

        foreach(var spawner in spawnerArray)
        {
            if (spawner.transform.position.y == transform.position.y)
            {
                myLaneSpawner = spawner;
                return;
            }
        }
    }
}

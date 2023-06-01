using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    public GameObject projectile;
    public GameObject gun;
    private GameObject projectileParent;

    private void Start()
    {
        projectileParent = GameObject.Find("Projectiles");

        if (!projectileParent)
        {
            projectile = new GameObject("Projectiles");
        }
    }
    private void Fire()
    {
        var newProjectile = Instantiate(projectile) as GameObject;
        newProjectile.transform.SetParent(projectileParent.transform);
        newProjectile.transform.position = gun.transform.position;
    }
}

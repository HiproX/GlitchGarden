using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed;
    public float damage;

    void Update()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var entity = collision.gameObject;
        if (!entity.GetComponent<Attacker>()) return;

        var health = entity.GetComponent<Health>();
        if (!health) return;

        health.DealDamage(damage);
        Destroy(gameObject);
    }
}

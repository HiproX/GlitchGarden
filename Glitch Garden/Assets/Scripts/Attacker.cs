using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SearchService;

public class Attacker : MonoBehaviour
{
    private float currentSpeed;
    private GameObject currentTarget;
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
        var myRigidbody = gameObject.AddComponent<Rigidbody2D>();
        myRigidbody.isKinematic = true;
    }

    void Update()
    {
        transform.Translate(Vector3.left * currentSpeed * Time.deltaTime);
    }

    public void SetSpeed(float speed)
    {
        currentSpeed = speed;
    }
    
    public void StrikeCurrentTarget(float damage)
    {
        if (currentTarget)
        {
            Debug.Log(name + " нанёс " + damage + " едениц урона " + currentTarget.name);
            var health = currentTarget.GetComponent<Health>();
            if (!health)
            {
                Debug.LogError("Компонент Health отсуствует у объекта " + currentTarget.name);
                return;
            }
            health.DealDamage(damage);
            if (!health.IsAlive)
            {
                animator.SetBool("isAttacking", false);
            }
        }
        else
        {

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(name + " тригер сработал");
    }

    public void Attack(GameObject obj)
    {
        currentTarget = obj;
    }
}

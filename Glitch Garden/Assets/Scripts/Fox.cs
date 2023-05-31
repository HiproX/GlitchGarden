using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Attacker))]
public class Fox : MonoBehaviour
{
    private Animator anim;
    private Attacker attacker;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        attacker = GetComponent<Attacker>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        var obj = collision.gameObject;
        if (!obj.GetComponent<Defender>()) return;

        Debug.Log("Лиса столкнулась с " + collision);
        if (obj.GetComponent<Stone>())
        {
            anim.SetTrigger("Jump Trigger");
        }
        else
        {
            anim.SetBool("isAttacking", true);
            attacker.Attack(obj);
        }
    }
}

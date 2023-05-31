using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lizard : MonoBehaviour
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

        Debug.Log("Крокодил столкнулся с " + collision);
        anim.SetBool("isAttacking", true);
        attacker.Attack(obj);
    }
}

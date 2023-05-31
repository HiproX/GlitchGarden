using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SearchService;

public class Attacker : MonoBehaviour
{
    private float currentSpeed;
    private GameObject currentTarget;
    // Start is called before the first frame update
    void Start()
    {
        var myRigidbody = gameObject.AddComponent<Rigidbody2D>();
        myRigidbody.isKinematic = true;
    }

    // Update is called once per frame
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
        Debug.Log(name + " нанёс " + damage + " едениц урона");
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

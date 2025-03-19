using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    public string TargetTag;
    public float PunchForce;

    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject target = collision.gameObject;

        if (target.CompareTag(TargetTag))
        {
            if (target.GetComponent<Health>())
                target.GetComponent<Health>().Hurt();

            target.GetComponent<Rigidbody2D>().AddForce(rb.velocity * PunchForce, ForceMode2D.Impulse);
        }
    }
}

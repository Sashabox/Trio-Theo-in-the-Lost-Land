using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadDeathScript : MonoBehaviour
{
    private GameObject enemy;
    public GameObject damage;

    // Start is called before the first frame update
    void Start()
    {
        enemy = gameObject.transform.parent.gameObject;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        damage.GetComponent<Collider2D>().enabled = false;
        GetComponent<Collider2D>().enabled = false;
        enemy.GetComponent<SpriteRenderer>().flipY = true;
        enemy.GetComponent<Collider2D>().enabled = false;
        Vector3 movement = new Vector3(Random.Range(40, 70), Random.Range(-40, 40), 0f);
        enemy.transform.position += movement * Time.deltaTime;
    }
}

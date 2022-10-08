using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public float speed = 4f;
    public int disappearAfter = 10;
    public int damage;

    public string enemyTag;

    private float timer;

    private void Update()
    {
        if(timer < disappearAfter)
        {
            timer += Time.deltaTime;
            transform.position += new Vector3(speed * Time.deltaTime, 0f, 0f);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(enemyTag))
        {
            Character enemy = collision.gameObject.GetComponent<Character>();
            enemy.Hurt(damage);
            Destroy(gameObject);
        }
    }
}

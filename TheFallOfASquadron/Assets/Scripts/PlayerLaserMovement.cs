using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLaserMovement : MonoBehaviour
{
    public float speed = 20.0f;
    private float zBound = 50.0f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);

        if (transform.position.z > zBound)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            Destroy(gameObject);

            EnemyMovement enemyHit = other.GetComponent<EnemyMovement>();
            enemyHit.health--;

            if (enemyHit.health <= 0)
            {
                Destroy(other.gameObject);
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    public int health = 30;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }

    void collidedWithEnemy(Enemy enemy)
    {
        enemy.Attack(this);
        if (health <= 0)
        {
            Destroy(this.gameObject);
            
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        Enemy enemy = collision.collider.gameObject.GetComponent<Enemy>();
        if (enemy)
        {
            collidedWithEnemy(enemy);
        }
    }
}

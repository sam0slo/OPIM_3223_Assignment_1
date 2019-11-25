using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Goal : MonoBehaviour
{
    public int health = 30;

    public event Action<Goal> onGoalDeath;

    public GameObject bigExplosionParticlesPrefab;

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
            if (onGoalDeath != null)
            {

                if (bigExplosionParticlesPrefab)
                {
                    GameObject bigExplosion = (GameObject)Instantiate(bigExplosionParticlesPrefab, new Vector3(23f , 0f , -20.5f) , bigExplosionParticlesPrefab.transform.rotation);
                    Destroy(bigExplosion, bigExplosion.GetComponent<ParticleSystem>().main.startLifetimeMultiplier);
                }
                onGoalDeath(this);
            }
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

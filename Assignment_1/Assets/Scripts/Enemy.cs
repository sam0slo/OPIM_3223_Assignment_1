using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public float moveSpeed = 5000;
    public int health = 10;
    public int damage = 10;
    public Transform targetTransform;

    // Start is called before the first frame update
    void Start()
    {

    }


    // Update is called once per frame
    void FixedUpdate()
    {
        if (targetTransform != null)
        {
            this.transform.position = Vector3.MoveTowards(this.transform.position, targetTransform.transform.position, Time.deltaTime * moveSpeed);
        }
    }

    public void Attack(Player player)
    {
        player.health -= this.damage;
        Destroy(this.gameObject);
    }

    public void Attack(Goal goal)
    {
        goal.health -= this.damage;
        Destroy(this.gameObject);
    }

    
    public void TakeDamage(int damage)
    {
        this.health -= damage;
        if (this.health <= 0)
        {
            Destroy(this.gameObject);
        }
    }


}

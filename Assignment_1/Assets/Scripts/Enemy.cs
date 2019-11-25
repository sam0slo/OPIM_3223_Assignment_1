using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public AudioClip explosion;
    private AudioSource audioSource;

    public float moveSpeed = 5000;
    public int health = 10;
    public int damage = 10;
    public Transform targetTransform;
    bool playedSound;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        playedSound = false;
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
        if(this.health > 0)
        {
            player.health -= this.damage;
        }
        
        Destroy(this.gameObject);
    }

    public void Attack(Goal goal)
    {
        if(this.health > 0)
        {
            goal.health -= this.damage;
        }
        
        Destroy(this.gameObject);
    }

    
    public void TakeDamage(int damage)
    {
        this.health -= damage;
        if (this.health <= 0)
        {
            if (!playedSound)
            {
                this.transform.localScale = new Vector3(0, 0, 0);
                audioSource.PlayOneShot(explosion);
                Destroy(this.gameObject, 1f);
                playedSound = true;
            }
        }
    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public AudioClip explosion;
    private AudioSource audioSource;
    public Animator goalDeathAnimation;

    bool playerAlive;
    bool goalAlive;
    
    public GameObject playerPrefab;

    // Start is called before the first frame update
    void Start()
    {
        var player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        player.onPlayerDeath += onPlayerDeath;

        var goal = GameObject.FindGameObjectWithTag("Goal").GetComponent<Goal>();
        goal.onGoalDeath += onGoalDeath;
        audioSource = GetComponent<AudioSource>();

        playerAlive = true;
        goalAlive = true;
    }

    private void Update()
    {
        var enemies = GameObject.FindGameObjectsWithTag("Enemy");
        if (enemies.Length == 0 && playerAlive && goalAlive)
        {
            Invoke("win", 3);
        }
    }

    void onGoalDeath(Goal goal)
    {
        goalAlive = false;

        audioSource.PlayOneShot(explosion);



        goalDeathAnimation.SetBool("goalDeath", true);

        Destroy(goal.gameObject, 1);

        Invoke("restartGame", 3);
    }

    void onPlayerDeath(Player player)
    {
        playerAlive = false;
       
        
        audioSource.PlayOneShot(explosion);


        Destroy(player.gameObject, 1);

        Invoke("restartGame", 3);
    }

    void win()
    {
        SceneManager.LoadScene("Win");
    }

    void restartGame()
    {
        var enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (var enemy in enemies)
        {
            Destroy(enemy);
        }

        SceneManager.LoadScene("Menu");
    }
}

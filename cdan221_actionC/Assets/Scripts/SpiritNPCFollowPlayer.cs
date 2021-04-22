using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class SpiritNPCFollowPlayer : MonoBehaviour
{

    //public Animator anim;
    public float speed = 4f;
    private Transform target;
    public int damage = 10;

    //public float speed = 2f;
    public float stoppingDistance = 4f; // when enemy stops moving towards player
    public float retreatDistance = 3f; // when enemy moves away from approaching player
    private float timeBtwShots;
    public float startTimeBtwShots = 2;
    //public GameObject projectile;

    private Rigidbody2D rb;
    private Transform player;
    private Vector2 PlayerVect;

    //public int EnemyLives = 30;
    //private Renderer rend;
    //private GameHandler gameHandler;

    public int EnemyLives = 3;
    private Renderer rend;
    private GameHandler gameHandler;

    public float attackRange = 10;

    void Start()
    {
        rend = GetComponentInChildren<Renderer>();

        if (GameObject.FindGameObjectWithTag("Player") != null)
        {
            target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        }

        if (GameObject.FindWithTag("GameHandler") != null)
        {
            gameHandler = GameObject.FindWithTag("GameHandler").GetComponent<GameHandler>();
        }
        Physics2D.queriesStartInColliders = false;

        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        PlayerVect = player.transform.position;

        timeBtwShots = startTimeBtwShots;

        rend = GetComponentInChildren<Renderer>();

    }

    void Update()
    {
        float DistToPlayer = Vector3.Distance(transform.position, player.position);
        if ((player != null) && (DistToPlayer <= attackRange))
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
        
        {
            // approach player
            if (Vector2.Distance(transform.position, player.position) > stoppingDistance)
            {
                transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
                Vector2 lookDir = PlayerVect - rb.position;
                float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg -90f;
                rb.rotation = angle;
            }
            // stop moving
            else if (Vector2.Distance(transform.position, player.position) < stoppingDistance && Vector2.Distance(transform.position, player.position) > retreatDistance)
            {
                transform.position = this.transform.position;
            }

            // retreat from player
            else if (Vector2.Distance(transform.position, player.position) < retreatDistance)
            {
                transform.position = Vector2.MoveTowards(transform.position, player.position, -speed * Time.deltaTime);
            }

            //if (timeBtwShots <= 0)
            //{
               // Instantiate(projectile, transform.position, Quaternion.identity);
                //timeBtwShots = startTimeBtwShots;
            //}
            //else
            //{
                //timeBtwShots -= Time.deltaTime;
            //}
        }
    }


    //public void OnCollisionEnter2D(Collision2D collision)
    //{
        //if (collision.gameObject.tag == "Player")
        //{
            //anim.SetBool("Attack", true);
            //gameHandler.playerGetHit(damage);
            //rend.material.color = new Color(2.4f, 0.9f, 0.9f, 0.5f);
            //StartCoroutine(HitEnemy());
        //}
    //}

    public void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //anim.SetBool("Attack", false);
        }
    }

    IEnumerator HitEnemy()
    {
        yield return new WaitForSeconds(0.5f);
        rend.material.color = Color.white;
    }

    //DISPLAY the range of enemy's attack when selected in the Editor
    void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPotassum : MonoBehaviour
{
    public Transform[] patrolpoints;
    public float moveSpeed;
    public int patrolDestination;
    private Rigidbody2D _rb;

    public Transform playerTransform;
    public bool isChasing;
    public float chaseDistance;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (isChasing)
        {
            if (transform.position.x < playerTransform.position.x)
            {
                transform.position += Vector3.right * moveSpeed * Time.deltaTime;
            }
            if (transform.position.x > playerTransform.position.x)
            {
                transform.position += Vector3.left * moveSpeed * Time.deltaTime;
            }
        }
        else if (!isChasing)
        {
            if(Vector2.Distance(transform.position,playerTransform.position) < chaseDistance)
            {
                isChasing = true;
            }
            if (patrolDestination == 0)
            {
                transform.position = Vector2.MoveTowards(transform.position, patrolpoints[0].position,moveSpeed*Time.deltaTime);
                if (Vector2.Distance(transform.position, patrolpoints[0].position) < .2f)
                {
                    patrolDestination = 1;
                    gameObject.GetComponent<SpriteRenderer>().flipX = false;
                }
            }
            if (patrolDestination == 1)
            {
                this.transform.position = Vector2.MoveTowards(transform.position, patrolpoints[1].position, moveSpeed * Time.deltaTime);
                if (Vector2.Distance(transform.position, patrolpoints[1].position) < .2f)
                {
                    patrolDestination = 0;
                    gameObject.GetComponent<SpriteRenderer>().flipX = true;
                }
            }
        }
        if (transform.position.x < playerTransform.position.x)
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
        }
        else if (transform.position.x > playerTransform.position.x)
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
        }
        

    }
}

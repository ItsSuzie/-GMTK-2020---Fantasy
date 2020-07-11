using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement1 : MonoBehaviour
{
    public Transform player;
    public float speed = 2f;
    private float playerDistance;
    public float minDistance = 1f;

    private BoxCollider2D boxCollider;
    private LayerMask Sword;
    private Rigidbody2D rb2d;

    // Start is called before the first frame update
    void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        //simply move towards player,  like a ghost maybe
        transform.LookAt(player);
        playerDistance = Vector2.Distance(transform.position, player.position);
        

        rb2d.MovePosition(Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime));


    }
}

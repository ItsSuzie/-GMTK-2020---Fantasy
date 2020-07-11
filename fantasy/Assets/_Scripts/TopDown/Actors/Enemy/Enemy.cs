using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int HP;
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
        //get something player == something something get instance()
        boxCollider = GetComponent<BoxCollider2D>();
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        //simply move towards player,  like a ghost maybe
        transform.LookAt(player); // TODO this acts like 3d stuff not good
        playerDistance = Vector2.Distance(transform.position, player.position);

        if (playerDistance < minDistance)
        {
            rb2d.MovePosition(Vector2.MoveTowards(transform.position, player.position, -1 * speed * Time.deltaTime));
        }



    }

    public void TakeDamage()
    {
        HP--;

        if(HP <= 0)
        {
            die();
        }
    }
    public void die() {
        // maybe stuff
        
        Destroy(this.gameObject);
    }
}

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


    // Start is called before the first frame update
    void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        Sword = LayerMask.GetMask("Sword");
    }

    // Update is called once per frame
    void Update()
    {

        //simply move towards player,  like a ghost maybe
        transform.LookAt(player);
        playerDistance = Vector2.Distance(transform.position, player.position);
        if (playerDistance < minDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }


        //if hit by sword get rekt
        Collider2D[] hits = Physics2D.OverlapBoxAll(transform.position, boxCollider.size, 0, Sword);
        foreach (Collider2D hit in hits)
        {
            Destroy(gameObject);
        }
        
         
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private static int EnemyCount;

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
    
        EnemyCount++;
    }

    // Update is called once per frame
    void Update()
    {

        //simply move towards player,  like a ghost maybe
        float rot_z = Mathf.Atan2(player.transform.position.y, player.transform.position.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);
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
        EnemyCount--;   

        Destroy(this.gameObject);
    }

    public static int enemyCount 
    {
        get { return EnemyCount; }
    }

}

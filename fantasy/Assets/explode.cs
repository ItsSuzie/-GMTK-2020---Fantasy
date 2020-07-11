using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explode : MonoBehaviour
{

    private BoxCollider2D boxCollider;
    private LayerMask player;

    // Start is called before the first frame update
    void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        player = LayerMask.GetMask("player");
    }

// Update is called once per frame
void Update()
    {

        Collider2D[] hits = Physics2D.OverlapBoxAll(transform.position, boxCollider.size, 0, player);

        foreach (Collider2D hit in hits)
        {
            ColliderDistance2D colliderDistance = hit.Distance(boxCollider);

            if (colliderDistance.isOverlapped)
            {
                Destroy(gameObject);
            }

        }
    }
}

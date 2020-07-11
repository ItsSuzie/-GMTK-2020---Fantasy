using UnityEngine;
using static PlayerMovement;

public class PlayerCombatController : MonoBehaviour
{

    
    // Variables
    #region Variables


    public Rect[] attackRect; // 0 = up, 1 = down, 2 = left, 3 = right
    private Vector2 attackDirection;    // may not be used
    private float attackDistance;       // may not be used
    public LayerMask hitMask;
    [SerializeField] private int lastFacingDir;

    // Private variables

    // Component references
    private PlayerInputManager inputManager;
    private PlayerMovement playerMovement;
    // private PlayerAttributesController playerAttributes;

    // Debuff Variables
    private bool D_Pacifism = false;

    private Vector2 attackOffset;

    #endregion


    // Private Methods
    #region private Methods

    /// <summary>
    /// Unity start method
    /// 
    /// Runs at start of initialization
    /// </summary>
    private void Start()
    {
        // Defines the component references
        inputManager = GetComponent<PlayerInputManager>();
        playerMovement = GetComponent<PlayerMovement>();
    }

    private void Update() {
    }


    // Initiate Attack
    public void initiateAttack(PlayerMovement.PLAYER_FACING_DIRECTION attackDirection)
    {
        // If not pacifised, attack
        if (!D_Pacifism)
        {
            if (attackDirection == PlayerMovement.PLAYER_FACING_DIRECTION.UP) {
                attackOffset = attackRect[0].position + (Vector2)transform.position; //something
                lastFacingDir = 0;
            }
            else if (attackDirection == PlayerMovement.PLAYER_FACING_DIRECTION.DOWN) {
                attackOffset = attackRect[1].position + (Vector2)transform.position; //something1
                lastFacingDir = 1;
            }
            else if (attackDirection == PlayerMovement.PLAYER_FACING_DIRECTION.LEFT) {
                attackOffset = attackRect[2].position + (Vector2)transform.position; //something2
                lastFacingDir = 2;
            }
            else if (attackDirection == PlayerMovement.PLAYER_FACING_DIRECTION.RIGHT) {
                attackOffset = attackRect[3].position + (Vector2)transform.position; //something3
                lastFacingDir = 3;
            }
            
            Collider2D[] hits = Physics2D.OverlapBoxAll(attackOffset, attackRect[lastFacingDir].size, 0, hitMask);
            foreach (Collider2D hit in hits) {
                Debug.Log("Hit " + hit.name);
                hit.GetComponent<Enemy>().TakeDamage();
            }
        }
    }



      private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.matrix = Matrix4x4.TRS((Vector2)this.transform.position + attackRect[lastFacingDir].center, this.transform.rotation, Vector3.one);
        Gizmos.DrawWireCube(Vector2.zero, attackRect[lastFacingDir].size);
        Gizmos.matrix = Matrix4x4.TRS((Vector2)this.transform.position + attackRect[lastFacingDir].center + (attackDirection.normalized * attackDistance), this.transform.rotation, Vector3.one);
        Gizmos.DrawWireCube(Vector2.zero, attackRect[lastFacingDir].size);
        Gizmos.color = Color.red;
        Gizmos.matrix = Matrix4x4.TRS((Vector2)this.transform.position + attackRect[lastFacingDir].center, Quaternion.identity, Vector3.one);
        Gizmos.DrawLine(Vector2.zero, attackDirection.normalized * attackDistance);

    }




    public bool debuffPacifist
    {
        set { D_Pacifism = value; }
    }




    #endregion
}




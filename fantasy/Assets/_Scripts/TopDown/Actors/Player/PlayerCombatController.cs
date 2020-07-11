using UnityEngine;
using static PlayerMovement;

public class PlayerCombatController : MonoBehaviour
{

    
    // Variables
    #region Variables


    public Rect[] attackRect; // 0 = up, 1 = down, 2 = left, 3 = right
    private Vector2 _attackDirection = Vector2.zero;    // may not be used
    private float _attackDistance;       // may not be used
    public LayerMask hitMask;
    [SerializeField] private int lastFacingDir;
    private Vector2 rayOrigin;

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

    private void Update() 
    {
    }


    // Initiate Attack
    public void initiateAttack(PlayerMovement.PLAYER_FACING_DIRECTION attackDirection)
    {
        // If not pacifised, attack
        if (!D_Pacifism)
        {
            Debug.Log("Attacking");
            if (attackDirection == PlayerMovement.PLAYER_FACING_DIRECTION.UP) {
                lastFacingDir = 0;
            }
            else if (attackDirection == PlayerMovement.PLAYER_FACING_DIRECTION.DOWN) {
                lastFacingDir = 1;
            }
            else if (attackDirection == PlayerMovement.PLAYER_FACING_DIRECTION.LEFT) {
                lastFacingDir = 2;
            }
            else if (attackDirection == PlayerMovement.PLAYER_FACING_DIRECTION.RIGHT) {
                lastFacingDir = 3;
            }
            

            rayOrigin = (Vector2)transform.position + attackRect[lastFacingDir].center;

            // Create raycast box for checking if enemy has been hit
            RaycastHit2D[] hits = Physics2D.BoxCastAll(rayOrigin, attackRect[lastFacingDir].size, 0, _attackDirection, _attackDistance, hitMask);
            foreach (RaycastHit2D hit in hits) {
                Debug.Log("Hit " + hit.transform.name);
                hit.transform.GetComponent<Enemy>().TakeDamage();
            }
        }
    }



    private void OnDrawGizmos()
    {
        rayOrigin = (Vector2)transform.position + attackRect[lastFacingDir].center;
        Gizmos.color = Color.red;
        Gizmos.matrix = Matrix4x4.TRS(rayOrigin, this.transform.rotation, Vector3.one);
        Gizmos.DrawWireCube(Vector2.zero, attackRect[lastFacingDir].size);
        Gizmos.matrix = Matrix4x4.TRS(rayOrigin + (_attackDirection.normalized * _attackDistance), this.transform.rotation, Vector3.one);
        Gizmos.DrawWireCube(Vector2.zero, attackRect[lastFacingDir].size);
        Gizmos.color = Color.red;
        Gizmos.matrix = Matrix4x4.TRS(rayOrigin, Quaternion.identity, Vector3.one);
        Gizmos.DrawLine(Vector2.zero, _attackDirection.normalized * _attackDistance);
    }




    public bool debuffPacifist
    {
        set { D_Pacifism = value; }
    }




    #endregion
}




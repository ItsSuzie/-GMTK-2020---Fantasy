using UnityEngine;
using static PlayerMovement;

public class PlayerCombatController : MonoBehaviour
{

    
    // Variables
    #region Variables


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
                attackOffset = new Vector2(0, 0); //something
            }
            else if (attackDirection == PlayerMovement.PLAYER_FACING_DIRECTION.DOWN) {
                attackOffset = new Vector2(0, 0); //something1
            }
            else if (attackDirection == PlayerMovement.PLAYER_FACING_DIRECTION.LEFT) {
                attackOffset = new Vector2(0, 0); //something2
            }
            else if (attackDirection == PlayerMovement.PLAYER_FACING_DIRECTION.RIGHT) {
                attackOffset = new Vector2(0, 0); //something3
            }
            
            Collider2D[] hits = Physics2D.OverlapBoxAll((Vector2)transform.position + attackOffset, new Vector2(50, 50), 0, 0);
            foreach (Collider2D hit in hits) {
                hit.GetComponent<Enemy>().die();
            }
        }
    }




    public bool debuffPacifist
    {
        set { D_Pacifism = value; }
    }

    #endregion
}

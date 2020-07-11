using UnityEngine;

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
    public void initiateAttack(playerMovement.PLAYER_FACING_DIRECTION attackDirection)
    {
        // If not pacifised, attack
        if (!D_Pacifism)
        {
            if (attackDirection == 0) 
                attackOffset = //something
            
            elseif (attackDirection == 1) {
                attackOffset = //something1
            
            elseif (attackDirection == 2) 
                attackOffset = //something2
            
            elseif (attackDirection == 3) 
                attackOffset = //something3
            
            
            Collider2D[] hits = Physics2D.OverlapBoxAll(transform.position + attackOffset, new Vector2(50, 50), 0, 0);
            foreach (Collider2D hit in hits) {
            }
        }
    }




    public bool debuffPacifist
    {
        set { D_Pacifism = value; }
    }

    #endregion
}

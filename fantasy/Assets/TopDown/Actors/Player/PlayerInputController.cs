using UnityEngine;

/// <summary>
/// COntrols the input on where it will go
/// </summary>
public class PlayerInputController : MonoBehaviour
{

    // Variables
    #region Variables


    // Private variables

    // Component references
    private PlayerInputManager inputManager;
    private PlayerMovement playerMovement;
    // private PlayerCombatController playerCombat;
    // private PlayerAttributesController playerAttributes;

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
        // playerCombat = GetComponent<PlayerCombatController>();
        // playerAttributes = GetComponent<PlayerAttributesController>();

        // Sending the current player number to the attribues controlelr
        // playerAttributes.currentPlayerNumber = (int)inputManager.player_number;
    }

    /// <summary>
    /// Unity Update method
    /// 
    /// Runs every frame
    /// </summary>
    private void Update()
    {
        // // If player attacks, initiate atttack
        // if (inputManager.IsAttacking)
        //     playerCombat.initiateAttack(playerMovement.FacingDirection);

        // if (!inputManager.IsAttacking || playerCombat.cooldownTimer <= 0 || !playerAttributes.playerStaggered || !playerAttributes.PlayerDied)
        //     playerCombat.FacingDir = playerMovement.FacingDirection;

        // if (inputManager.KillPlayer || inputManager.KillPlayer2)
        //     playerAttributes.takeDamage(99999);
    }

    /// <summary>
    /// Unity fixed update method
    /// 
    /// Runs once per frame, but executed on a fixed interval
    /// Do physics here
    /// </summary>
    private void FixedUpdate()
    {
        // Iniitate player movement (NOTE: Unity Physics must be kept inside of FixedUpdate()
        // to ensure physics are not tied to the frame rate)
        if ((inputManager.CanMove))
            playerMovement.initiatiteMovement(inputManager.MoveDirection, inputManager.IsSprinting);
        else
            playerMovement.initiatiteMovement(Vector2.zero, false);

    }


    #endregion

}

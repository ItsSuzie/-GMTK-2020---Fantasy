using UnityEngine;


/// <summary>
/// Manages and defines the input manager of the player
/// 
/// 
/// </summary>
public class PlayerInputManager : MonoBehaviour
{
    /// <summary>
    /// TODO: Prepare code for the new unity input system
    /// </summary>

    // Enums
    #region enums

    // Defines which player this player is
    public enum PLAYER_NUMBER
    {
        PLAYER_ONE,
        PLAYER_TWO
    };


    #endregion

    // variables
    #region Variables

    // public Variables
    // ---------------------------------------------

    [Header("Player Number")]
    public PLAYER_NUMBER player_number; // Defines which number the player is

    [Header("Gamepad Icons")]
    

    // Player input data
    private bool p2ControlState = false;
    private bool canControlP2 = false;
    private bool dropOutPlayer = false;
    private bool canMove = true;
    private Vector2 moveDirection;
    private bool isAttacking;
    private bool isSprinting;
    private bool killPlayer;
    private bool killPlayerP2;

    // Timers
    private float flashTimer = 1.0f;
    private float flashingTimer;

    // component references
    private BoxCollider2D box2d;

    #endregion


    #region Private Methods


    /// <summary>
    /// Unity start method
    /// 
    /// Runs once when the scene starts
    /// </summary>
    private void Start()
    {
        // COmponent references
        box2d = GetComponent<BoxCollider2D>();

        // Define controls
        defineControlscInput();
    }


    /// <summary>
    /// Unity update method
    ///
    /// UPdates every frame
    /// </summary>
    private void Update()
    {
        // Gets input from the player
        getInput();
    }

    /// <summary>
    /// Defines controls
    /// TODO: Define all ihput here using unity's input system
    /// </summary>
    private void defineControlscInput()
    {
    }

    // Parse playerInput
    // ------------------------------------------------------------

    /// <summary>
    /// Gets any input from the player
    /// </summary>
    private void getInput()
    {
        if (player_number == PLAYER_NUMBER.PLAYER_ONE)
        {
                canMove = true;
                // Move the player
                // Get horizontal and vertical input
                moveDirection.x = Input.GetAxisRaw("Horizontal_p1");
                moveDirection.y = Input.GetAxisRaw("Vertical_p1");
        }
        else    // Player 2
        {
            if (p2ControlState)
            {
                canMove = true;
                // Move the player
                // Get horizontal and vertical input
                moveDirection.x = Input.GetAxisRaw("Horizontal_p2");
                moveDirection.y = Input.GetAxisRaw("Vertical_p2");
            }
        }
    }

    #endregion

    // Getters and Setters
    #region Getters/Setters

    // Player input data
    public bool P2ControlState
    {
        get { return p2ControlState; }
    }

    /// <summary>
    /// Returns if p2 can be controlled
    /// </summary>
    public bool CanControlP2
    {
        get { return canControlP2; }
    }

    /// <summary>
    ///  Returns if player can move
    /// </summary>
    public bool CanMove
    {
        get { return canMove; }
    }

    // Get all input data
    public Vector2 MoveDirection
    {
        get { return moveDirection; }
    }

    /// <summary>
    /// Returns if player if pressing attacking key
    /// </summary>
    public bool IsAttacking
    {
        get { return isAttacking; }
    }

    /// <summary>
    /// Returns if player is pressing sprint key
    /// </summary>
    public bool IsSprinting
    {
        get { return isSprinting; }
    }

    /// <summary>
    /// Kill bind
    /// </summary>
    public bool KillPlayer
    {
        get { return killPlayer; }
    }

    public bool KillPlayer2
    {
        get { return killPlayerP2; }
    }

    #endregion

}
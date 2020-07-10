using UnityEngine;


/// <summary>
/// Defines the 
/// 
/// 
/// </summary>
public class PlayerInputManager : MonoBehaviour
{
    /// <summary>
    /// TODO: Prepare code for the new unity input system
    /// </summary>

    // variables
    #region Variables

    // public Variables
    // ---------------------------------------------


    // Player input data - stores bools if a button has been pressed.
    // use the bool's to check initiate input from the corresponding script needed

    private bool canMove = true;
    private Vector2 moveDirection;
    private bool isSprinting;

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
        canMove = true;
        // Move the player
        // Get horizontal and vertical input
        moveDirection.x = Input.GetAxisRaw("Horizontal");
        moveDirection.y = Input.GetAxisRaw("Vertical");
    }

    #endregion

    // Getters and Setters
    #region Getters/Setters

    // Player input data
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
    /// Returns if player is pressing sprint key
    /// </summary>
    public bool IsSprinting
    {
        get { return isSprinting; }
    }

    #endregion

}
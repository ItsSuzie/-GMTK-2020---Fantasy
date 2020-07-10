using UnityEngine;

public class PlayerMovement2D : MonoBehaviour
{

    public float moveSpeed = 40f;

    private CharacterController2D controller2D;

    private Vector2 moveDirection;
    private bool _Jump = false;
    private bool _crouch = false;

    private void Start()
    {
        // Get component references
        controller2D = GetComponent<CharacterController2D>();
    }

    private void Update()
    {
        moveDirection.x = Input.GetAxisRaw("Horizontal") * moveSpeed;
        if(Input.GetButtonDown("Jump"))
        {
            _Jump = true;
        }

        // if (Input.GetButtonDown("Crouch"))
        // {
        //     _crouch = true;
        // }

    }

    private void FixedUpdate()
    {
        controller2D.Move(moveDirection.x * Time.fixedDeltaTime, _crouch, _Jump);

        _Jump = false;
        // _crouch = false;
    }   
}

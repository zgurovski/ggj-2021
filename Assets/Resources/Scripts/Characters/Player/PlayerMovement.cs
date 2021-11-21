using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour, IMove
{
    public float moveSpeed = 10f;
    private Player player;
    private float screenEdgeHorizontal = 26f; //the distance between the player and the horizontal edge of the screen
    private float screenEdgeVertical = 26f; //the distance between the player and the vertical edge of the screen
    private List<CHARACTER_STATE> allowedForMovmentStates;
    private GameObject talkChecker;
    private Vector2 direction = Vector2.zero;

    void Start()
    {
        player = GetComponent<Player>();
        talkChecker = GameObject.FindGameObjectWithTag("TalkChecker");
        allowedForMovmentStates = getAllowedForMovmentStates();
    }

    void OnEnable()
    {
        //InputManager.onMovementInputEvent += movementInputEvent;
    }

    void OnDisable()
    {
       // InputManager.onMovementInputEvent -= movementInputEvent;
        player.getCharacterAnimator().IdleAnimation();
        player.getRigidBody().velocity = Vector2.zero;
    }

    void Update()
    {
        // Movement input
        float x = 0f;
        float y = 0f;

        if (Input.GetKey(InputManager.MoveLeft)) x = -1f;
        if (Input.GetKey(InputManager.MoveRight)) x = 1f;
        if (Input.GetKey(InputManager.MoveUp)) y = 1f;
        if (Input.GetKey(InputManager.MoveDown)) y = -1f;

        direction = new Vector2(x, y);
    }

    void FixedUpdate()
    {
        movementInputEvent(direction);
    }

    void movementInputEvent(Vector2 direction)
    {

        if (!talkChecker.activeSelf)
        {
            return;
        }

        bool isMoving = !direction.Equals(Vector2.zero);

        if (player.getState() != CHARACTER_STATE.TIRED && allowedForMovmentStates.Contains(player.getState()))
        {
            // Start walking
            Walk(moveSpeed, direction);
        }
        if (!isMoving)
        {
            // Stop walking
            Idle();
        }
    }

    public List<CHARACTER_STATE> getAllowedForMovmentStates()
    {
        return new List<CHARACTER_STATE> {
            CHARACTER_STATE.IDLE,
            CHARACTER_STATE.MOVING,
            CHARACTER_STATE.JUMPING
        };
    }

    public void Idle()
    {
        player.setState(CHARACTER_STATE.IDLE);
        player.getCharacterAnimator().IdleAnimation();
    }

    public void Walk(float moveSpeed, Vector2 direction)
    {
        if (player.getState() != CHARACTER_STATE.JUMPING)
        {
            // Fake depth by moving slower in y direction
            Vector2 result = new Vector3(direction.x * moveSpeed, direction.y * moveSpeed * .7f);

            // Move player
            player.getRigidBody().velocity = new Vector2(result.x, result.y);

            // Play walk or idle animation
            player.setState(CHARACTER_STATE.MOVING);
            player.getCharacterAnimator().WalkAnimation(result.normalized);
        }
        KeepPlayerInCameraView();
    }

    // Keep the player within camera view
    void KeepPlayerInCameraView()
    {
        Vector2 playerPosScreen = Camera.main.WorldToScreenPoint(transform.position);

        if (playerPosScreen.x + screenEdgeHorizontal > Screen.width && (playerPosScreen.y - screenEdgeVertical < 0))
        {
            transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width - screenEdgeHorizontal, screenEdgeVertical, transform.position.z - Camera.main.transform.position.z));

        }
        else if (playerPosScreen.x + screenEdgeHorizontal > Screen.width)
        {
            transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width - screenEdgeHorizontal, playerPosScreen.y, transform.position.z - Camera.main.transform.position.z));

        }
        else if (playerPosScreen.x - screenEdgeHorizontal < 0f && (playerPosScreen.y - screenEdgeVertical < 0))
        {
            transform.position = Camera.main.ScreenToWorldPoint(new Vector3(screenEdgeHorizontal, screenEdgeVertical, transform.position.z - Camera.main.transform.position.z));

        }
        else if (playerPosScreen.x - screenEdgeHorizontal < 0f)
        {
            transform.position = Camera.main.ScreenToWorldPoint(new Vector3(screenEdgeHorizontal, playerPosScreen.y, transform.position.z - Camera.main.transform.position.z));

        }
        else if ((playerPosScreen.y - screenEdgeVertical < 0) && (playerPosScreen.x + screenEdgeHorizontal > Screen.width))
        {
            transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width - screenEdgeHorizontal, screenEdgeVertical, transform.position.z - Camera.main.transform.position.z));

        }
        else if ((playerPosScreen.y - screenEdgeVertical < 0) && (playerPosScreen.x - screenEdgeHorizontal < 0f))
        {
            transform.position = Camera.main.ScreenToWorldPoint(new Vector3(screenEdgeHorizontal, screenEdgeVertical, transform.position.z - Camera.main.transform.position.z));

        }
        else if (playerPosScreen.y - screenEdgeVertical < 0)
        {
            transform.position = Camera.main.ScreenToWorldPoint(new Vector3(playerPosScreen.x, screenEdgeVertical, transform.position.z - Camera.main.transform.position.z));
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField]
    public float _runningSpeed=8;
    [SerializeField]
    float _horizontalMovementSpeed = 4;

    float _movementSpeed;

    // GameState boolean
    public bool GameState;

    // Private component additions
    Animator _playerAnim;
    NavMeshAgent _navAgent;

    void Start()
    {
        // Game is paused at start. UI will be added to prompt the player to press start.
        GameState= false;

        // Background Audio Script
        // AudioScript.PlaySound(AudioScript.Sound.BackgroundMusic);

        // Game Component additions
        _playerAnim = GetComponent<Animator>();
        _navAgent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        // Controls starting/pausing the game based on clicking escape.
        GameStartControls();

        // Represents basic movement controls.
        MovementControls();

    }

    void GameStartControls() {

        //Change GameState if pressing Space

        if (Input.GetKeyDown(KeyCode.Space)) {
            // Press Space to Start the Game.
            GameState = true;

            // Disable Information Panel
            FindObjectOfType<Manager>().UIPanel.SetActive(false);
        }
    }

    void MovementControls() {

        // If Game State is Available
        if (!GameState) {

            // Idle Controls
            Idle();
        }
        else {

            // Running Controls
            Run();

        }

        if (_navAgent.velocity != Vector3.zero) {

            // Running Sounds
            FindObjectOfType<AudioAssets>().PlaySound(SoundNames.WalkingSounds);

        }
    }

    void Idle() {
        // Idle animation
        _playerAnim.SetFloat("Running", 0f, 0.1f, Time.deltaTime);
    }

    void Run() {

        // animation controls with running animation
        _playerAnim.SetFloat("Running", 1f, 0.1f, Time.deltaTime);

        // Navmesh movement
        _navAgent.Move(Vector3.forward * Time.deltaTime * _runningSpeed);

        if (Input.GetKey(KeyCode.A)) {
            // player pressing A for left movement
            _navAgent.Move(Vector3.left * Time.deltaTime * _horizontalMovementSpeed);
            _playerAnim.SetFloat("Side Movement", -1f, 0.1f, Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.D)) {
            // player pressing D for right movement
            _navAgent.Move(Vector3.right * Time.deltaTime * _horizontalMovementSpeed);
            _playerAnim.SetFloat("Side Movement", 1f, 0.1f, Time.deltaTime);
        }
        else {
            _playerAnim.SetFloat("Side Movement", 0, 0.1f, Time.deltaTime);
        }
    }
}

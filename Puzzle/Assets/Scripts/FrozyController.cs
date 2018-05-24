using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrozyController : MonoBehaviour {

    public float turnSpeed = 10;

    public float moveSpeed;
    public float jumpForce;

    public CharacterController controller;

    public Vector3 moveDirection;
    private Vector2 input;
    public bool invertZ;

    public float gravityScale;

    public Animator anim;

    private GameManager manager;

    //ROTACION PJ
    public Transform model;
    private Transform cam;
    private float angle;
    public Quaternion targetRotation;

    void Start()
    {
        cam = Camera.main.transform;

        controller = GetComponent<CharacterController>();

        manager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    void Update()
    {

        GetInput();

        float yStore = moveDirection.y;

        if (manager.extraCam.frozyIn)
        {
            moveDirection.z = transform.right.x * -input.x * moveSpeed;
            moveDirection.x = transform.forward.z * input.y * moveSpeed;
        }
        else
        {
            moveDirection.x = transform.right.x * input.x * moveSpeed;
            moveDirection.z = transform.forward.z * input.y * moveSpeed;
        }

        if (invertZ)
        {
            moveDirection.z = -moveDirection.z;
            moveDirection.x = -moveDirection.x;
        }

        moveDirection = moveDirection.normalized * moveSpeed;

        moveDirection.y = yStore;

        if (controller.isGrounded)
        {
            moveDirection.y = 0f;

            if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.JoystickButton0))
            {
                FindObjectOfType<AudioManager>().Play("froozyJump");

                anim.SetTrigger("isJumping");
                moveDirection.y = jumpForce;
            }
        }

        moveDirection.y = moveDirection.y + Physics.gravity.y * gravityScale * Time.deltaTime;

        controller.Move(moveDirection * Time.deltaTime);

        if (Mathf.Abs(input.x) != 0 || Mathf.Abs(input.y) != 0)
        {
            anim.SetBool("isRunning", true);
            anim.SetBool("isIdle", false);
        }
        else
        {
            anim.SetBool("isRunning", false);
            anim.SetBool("isIdle", true);
        }

        if (Mathf.Abs(input.x) < 0.3 && Mathf.Abs(input.y) < 0.3)
        {
            return;
        }

        CalculeDirection();
        Rotate();
    }

    void GetInput()
    {
        input.x = Input.GetAxisRaw("Horizontal");
        input.y = Input.GetAxisRaw("Vertical");
    }

    private void CalculeDirection()
    {
        angle = Mathf.Atan2(input.x, input.y);
        angle = Mathf.Rad2Deg * angle;
        angle += cam.eulerAngles.y;
    }

    private void Rotate()
    {
        targetRotation = Quaternion.Euler(0, angle, 0);
        model.rotation = Quaternion.Slerp(model.rotation, targetRotation, turnSpeed * Time.deltaTime);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float turnSpeed = 10;

    public float moveSpeed;
    public float jumpForce;

    public CharacterController controller;

    public Vector3 moveDirection;
    private Vector2 input;

    public float gravityScale;

    public Animator anim;

    private GameManager manager;

    //ROTACION PJ
    public Transform model;
    private Transform cam;
    private float angle;
    public Quaternion targetRotation;

	void Start ()
    {
        cam = Camera.main.transform;

        controller = GetComponent<CharacterController>();

        manager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    void Update ()
    {

        GetInput();

        float yStore = moveDirection.y;

        if(manager.extraCam.extraCamActive)
        {
            moveDirection.z = transform.position.x * -input.x;

            moveDirection.x = transform.position.z * input.y;
        }
        else
        {
            moveDirection.x = transform.position.x * input.x;

            moveDirection.z = transform.position.z * input.y;
        }

        //moveDirection = (transform.forward * input.y * moveSpeed) + (transform.right * input.x * moveSpeed);

        moveDirection = moveDirection.normalized * moveSpeed;

        moveDirection.y = yStore;

        if (controller.isGrounded)
        {
            moveDirection.y = 0f;

            if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.JoystickButton0))
            {
                anim.SetTrigger("isJumping");
                moveDirection.y = jumpForce;
            }
        }

        moveDirection.y = moveDirection.y + Physics.gravity.y * gravityScale * Time.deltaTime;

        controller.Move(moveDirection * Time.deltaTime);

        if(Mathf.Abs(input.x) != 0 || Mathf.Abs(input.y) != 0)
        {
            anim.SetBool("isRunning", true);
            anim.SetBool("isIdle", false);
        }
        else
        {
            anim.SetBool("isRunning", false);
            anim.SetBool("isIdle", true);
        }

        if (Mathf.Abs(input.x) < 0.7 && Mathf.Abs(input.y) < 0.7)
        {
            return;
        }
        CalculeDirection();
        Rotate();
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "IcePlayer" || other.tag == "FirePlayer")
        {
            Debug.Log("MUERTO");
            //ResetPlayer();
        }
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
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{

    public float jumpForce;
    public float jumpTime;
    public float jumpTimeCounter;
    public float gravTimeCounter;
    public bool stoppedJumping;
    public float moveSpeed;

    public float gravity;

    private float distanceGround;

    private Rigidbody rb;

    private Vector3 resetPos;

    private bool isTimeTrial;
    private Timer timerObj;
    private bool hasStarted;

    void Start()
    {

        jumpForce = 30;
        jumpTime = 0.75F;
        moveSpeed = 2;
        gravity = 0;

        distanceGround = gameObject.GetComponent<CapsuleCollider>().bounds.extents.y;

        rb = GetComponent<Rigidbody>();
        jumpTimeCounter = jumpTime;
        gravTimeCounter = 0;

        hasStarted = false;

        stoppedJumping = true;

        resetPos = Vector3.zero;

        if(SceneManager.GetActiveScene().name == "Lvl1Regular" || SceneManager.GetActiveScene().name == "Lvl2Regular")
        {
            isTimeTrial = false;
        }
        else
        {
            isTimeTrial = true;
            timerObj = GameObject.Find("Timer").GetComponent<Timer>();
        }
    }

    // Update is called once per frame
    void Update()
    {

        float x = CrossPlatformInputManager.GetAxis("Horizontal");
        float y = CrossPlatformInputManager.GetAxis("Vertical");

        Vector3 movement = new Vector3(x * moveSpeed, 0.0f, y * moveSpeed);

        rb.AddForce(movement * 4f);

        if (x != 0 && y != 0)
        {
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, Mathf.Atan2(x, y) * Mathf.Rad2Deg, transform.eulerAngles.z);
        }

        if (isGrounded())
        {
            gravTimeCounter = 0;
            jumpTimeCounter = jumpTime;
        }
        else
        {
            gravTimeCounter -= Time.deltaTime;
            jumpTimeCounter -= Time.deltaTime;
        }
        if (isGrounded())
        {
            /*if (x != 0 || y != 0)
            {
                anim.Play("PlayerMove");
            }
            else
            {
                anim.Play("PlayerIdle");
            }*/
        }
        else if (CrossPlatformInputManager.GetButtonDown("Jump"))
        {
            Debug.Log("Ree");
         //   anim.Play("PlayerJump");
            gravity = -2;
        }

    }

    private bool isGrounded()
    {
        return Physics.Raycast(transform.position, -Vector3.up, distanceGround + 0.1F);
    }

    void FixedUpdate()
    {

        if (CrossPlatformInputManager.GetButton("Jump") && isGrounded())
        {

            Debug.Log("Jumped");
            rb.velocity = new Vector2(rb.velocity.y, jumpForce);
            stoppedJumping = false;
        }

        //if you keep holding down the mouse button...
        if (CrossPlatformInputManager.GetButton("Jump") && !stoppedJumping)
        {

            Debug.Log("Jumping");
            //and your counter hasn't reached zero...
            if (jumpTimeCounter > 0)
            {
                //keep jumping!
                rb.velocity = new Vector2(0, jumpForce * jumpTimeCounter);
            }
        }
        rb.AddForce(new Vector3(0, gravity * -gravTimeCounter, 0));



        //if you stop holding down the mouse button...
        if (CrossPlatformInputManager.GetButtonUp("Jump"))
        {
            Debug.Log("Stopped");
            //stop jumping and set your counter to zero.  The timer will reset once we touch the ground again in the update function.
            jumpTimeCounter = 0;
            stoppedJumping = true;
        }

    }

    private void OnCollisionEnter(Collision other)
    {
        Debug.Log("Hitting Shit");
        if (other.gameObject.tag == "Kills")
        {
            gameObject.GetComponent<Transform>().position = resetPos;
            if (isTimeTrial)
            {
                timerObj.addTime(5F);
            }
        }
        else if(other.gameObject.tag == "Finish")
        {
            SceneManager.LoadScene("End");
        }
        else if(isGrounded())
        {
            resetPos = gameObject.GetComponent<Transform>().position;
        }
    }

}
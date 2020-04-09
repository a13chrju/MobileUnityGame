using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class move : MonoBehaviour
{
    public Rigidbody rb;
    public float MoveSpeed;
    public float gravityscale;
    public float jumpforce;
    public GameObject particles;
    public Animator anim;
    public Vector3 moveDirection;
    public AudioClip jumpSound;
    private AudioSource source;
    private float canjump = 0f;
    private float moveHorizontal, moveVertical;
    private Vector3 movHorizontal, movVertical;
    public float moveRight = 0f;
    public Animator m_Animator;
    private bool btnJump = false;
    private bool canyesjump = true;
    public bool isattacking = false;
    private float attacktime;
    public bool isGrounded = true;

    public Canvas cantjumptxt;
    // Use this for initialization
    void Start()
    {
        m_Animator = GetComponent<Animator>();
        rb = this.GetComponent<Rigidbody>();
        //   anim = GetComponent<Animator>();
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (moveRight > 0)
        {
            m_Animator.SetBool("runnings", true);
        }
        else
        {
            m_Animator.SetBool("runnings", false);
        }
        rb.AddForce(Vector3.down * gravityscale, ForceMode.Force);
        moveHorizontal = 0 * -1f; //Joystick.Horizontal
        moveVertical = moveRight * -1f; // Joystick.Vertical


        movHorizontal = (transform.right * moveHorizontal) * -1f;
        movVertical = (transform.forward * moveVertical) * -1f;


        Vector3 Velocity = ((new Vector3(0, 0, 0) + movVertical).normalized) * MoveSpeed;


        // rb.velocity = Velocity;

        rb.MovePosition(rb.position + Velocity * Time.fixedDeltaTime);
        //   Animating(moveHorizontal, moveVertical);

        /* else
         {
           //  Animating(0f, 0f);
         }
         */
        if(Time.time > attacktime)
        {
            isattacking = false;
        }

        if (Input.GetKey(KeyCode.R))
        {
            jump();
        }

    }

    public void jump()
    {
        if (canyesjump && isGrounded)
        {
            m_Animator.SetTrigger("jumpUp");
            rb.AddForce(Vector3.up * jumpforce);
        }
        else
        {
            Debug.Log("I CANT JUMP");
            cantjumptxt.GetComponent<CanvasGroup>().alpha = 1;
            StartCoroutine(cantjumpCoroutine());
        }
    }

    IEnumerator cantjumpCoroutine()
    {
        yield return new WaitForSeconds(2f);
        cantjumptxt.GetComponent<CanvasGroup>().alpha = 0;
    }

    public void attack()
    {
        isattacking = true;
        m_Animator.SetTrigger("reset");
        m_Animator.SetTrigger("attack");
        Debug.Log("AAAAAAattacked");
        Debug.Log("CAN attack :" + isattacking);
        attacktime = Time.time + 0.5f;
    }


    public void die()
    {
        m_Animator.SetTrigger("die");
        moveRight = 0f;
        canjump = Time.time + 6f;
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Ground")
        {
            isGrounded = true;
            Debug.Log("Ground enter :" + isGrounded);
            
        }
    }

    void OnCollisionExit(Collision col)
    {
        if (col.gameObject.tag == "Ground")
        {
            isGrounded = false;
            Debug.Log("Ground leave :" + isGrounded);
            
        }
    }
}

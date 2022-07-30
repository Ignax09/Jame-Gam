using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;
    private Rigidbody2D rb;
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private Collider2D boxCollider;
    [SerializeField] private Transform glassesRotation;
    SpriteRenderer sRenderer;
    Animator animator;
    bool landSound;

    void Start()
    {
        animator = GetComponent<Animator>();
        sRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        
    }

    void Update()
    {
        float movement = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2 (movement * speed, rb.velocity.y);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump(jumpForce);
        }
        if (Input.GetKeyUp(KeyCode.Space) && rb.velocity.y >= 0)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y / 2);
        }

        if (movement < 0)
        {
            sRenderer.flipX = true;
        }
        if (movement > 0)
        {
            sRenderer.flipX = false;
        }
        if (movement == 0)
        {
            animator.SetFloat("Speed", 0);
        }
        else
        {
            FindObjectOfType<AudioManager>().Play("Walk");
            animator.SetFloat("Speed", 1);
        }
        if (rb.velocity.y <= 0.1f)
        {
            animator.SetBool("MidAir", false);
        }
        if (rb.velocity.y <= 0.1f && landSound)
        {
            FindObjectOfType<AudioManager>().Play("Land");
            landSound = false;
        }
    }

    void Jump(float force)
    {
        if (isGrounded())
        {
            animator.SetBool("MidAir", true);
            rb.velocity = new Vector2(rb.velocity.x, force);
            FindObjectOfType<AudioManager>().Play("Jump");
            landSound = true;
        }
    }

    private bool isGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size - new Vector3(0.2f, 0, 0), 0f, Vector2.down, boxCollider.bounds.extents.y, layerMask);
        return raycastHit.collider != null;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ending")
        {
            BackToMenu();
        }
    }

    void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void Death()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}

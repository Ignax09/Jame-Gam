using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;
    private Rigidbody2D rb;
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private Collider2D boxCollider;
    [SerializeField] private Transform glassesRotation;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        glassesRotation.localPosition = new Vector3(0.2f, 0.2f, 0);
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
            glassesRotation.localPosition = new Vector3(-0.2f, 0.2f, 0);
        }
        if (movement > 0)
        {
            glassesRotation.localPosition = new Vector3(0.2f, 0.2f, 0);
        }
    }

    void Jump(float force)
    {
        if (isGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, force);
        }
    }

    private bool isGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0f, Vector2.down, boxCollider.bounds.extents.y, layerMask);
        return raycastHit.collider != null;

    }
}

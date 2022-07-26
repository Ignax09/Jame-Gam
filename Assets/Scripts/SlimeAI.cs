using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeAI : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] int speed;
    bool detectedEdge;
    [SerializeField] Transform edgeCheck;
    bool detectedWall;
    [SerializeField] Transform wallCheck;
    [SerializeField] LayerMask groundLayer;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        CollisionCheck();
    }

    private void FixedUpdate()
    {
        Debug.Log(rb.velocity.y);
        if (!detectedEdge) Flip();
        if (detectedWall) Flip();
        Patrol();
    }

    void Patrol()
    {
        detectedWall = Physics2D.OverlapCircle(wallCheck.position, 0.1f, groundLayer);
        if (rb.velocity.y >= 0) detectedEdge = Physics2D.OverlapCircle(edgeCheck.position, 0.2f, groundLayer);
        rb.velocity = new Vector2(speed, rb.velocity.y);

    }

    void Flip()
    {
        transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
        speed *= -1;
        detectedEdge = true;
        detectedWall = false;
    }

    void CollisionCheck()
    {
        detectedWall = Physics2D.OverlapCircle(wallCheck.position, 0.1f, groundLayer);
        if (rb.velocity.y >= 0) detectedEdge = Physics2D.OverlapCircle(edgeCheck.position, 0.2f, groundLayer);
    }
}

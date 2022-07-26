using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crushed : MonoBehaviour
{
    Vector3 halfExtents;
    [SerializeField] LayerMask layerMask;
    Collider2D collider1;
    // Start is called before the first frame update
    void Start()
    {
        collider1 = GetComponent<Collider2D>();
        halfExtents = new Vector2(transform.localScale.x / 2 - 0.1f, transform.localScale.y / 2 - 0.1f);
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(collider1.bounds.center, collider1.bounds.size - new Vector3(0.4f, 0.4f, 0), 0f, Vector2.down, 0, layerMask);
        if (raycastHit.collider != null)
        {
            Death();
        }
    }

    void Death()
    {
        
        Destroy(gameObject);
    }
}

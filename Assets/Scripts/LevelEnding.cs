using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LevelEnding : MonoBehaviour
{
    Vector3 startingPosition;
    [SerializeField] float speed;
    [SerializeField] float maxBounds;
    void Start()
    {
        startingPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(startingPosition.position.y);
        transform.position += new Vector3(0, speed * Time.deltaTime);
        if (transform.position.y >= startingPosition.y + maxBounds)
        {
            Flip();
        }
    }

    void Flip()
    {
        speed *= -1;
        maxBounds *= -1;
    }
}

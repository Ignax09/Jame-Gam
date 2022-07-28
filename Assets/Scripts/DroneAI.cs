using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneAI : MonoBehaviour
{
    Vector3 startingPosition;
    [SerializeField] Vector3 patrolPoint;
    Transform playerTransform;
    [SerializeField] float roamSpeed;
    [SerializeField] float chaseSpeed;
    [SerializeField] float detectionDistance;
    private State state;
    Vector3 intrestedPosition;
    float LockedPositionY;

    private enum State
    {
        Roaming,
        Chasing,
        BackToStart,
    }

    void Awake()
    {
        startingPosition = transform.position;
        playerTransform = FindObjectOfType<PlayerMovement>().GetComponent<Transform>();
        state = State.Roaming;
        intrestedPosition = patrolPoint;
        LockedPositionY = transform.position.y;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        switch (state)
        {
            case State.Roaming:
                
                if (Vector3.Distance(transform.position, startingPosition) <= 0.1f)
                {
                    intrestedPosition = patrolPoint;
                }
                if (Vector3.Distance(transform.position, patrolPoint) <= 0.1f)
                {
                    intrestedPosition = startingPosition;
                }
                transform.position = Vector3.MoveTowards(transform.position, intrestedPosition, roamSpeed * Time.deltaTime);
                LookForTarget();
                break;
            case State.Chasing:
                transform.position = Vector3.MoveTowards(transform.position, playerTransform.position, chaseSpeed * Time.deltaTime);
                transform.position = new Vector3(transform.position.x, LockedPositionY, 0);
                if (Vector3.Distance(transform.position, startingPosition) >= detectionDistance * 3)
                {
                    state = State.BackToStart;
                }
                break;
            case State.BackToStart:
                if (Vector3.Distance(transform.position, startingPosition) >= 0.1f)
                {
                    transform.position = Vector3.MoveTowards(transform.position, startingPosition, roamSpeed * Time.deltaTime);
                }
                else
                {
                    state = State.Roaming;
                }
                break;
        }
    }

    void LookForTarget()
    {
        if (Vector3.Distance(transform.position, playerTransform.position) <= detectionDistance)
        {
            state = State.Chasing;
        }
    }
}

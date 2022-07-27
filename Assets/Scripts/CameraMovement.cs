using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    Transform playerTransform;
    float cameraSpeed;
    // Start is called before the first frame update
    void Start()
    {
        cameraSpeed = 30;
        playerTransform = FindObjectOfType<PlayerMovement>().GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, playerTransform.position, cameraSpeed * Time.deltaTime);
        transform.position = new Vector3(transform.position.x, 0, -10);
    }
}

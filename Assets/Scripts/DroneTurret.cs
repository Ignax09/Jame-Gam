using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneTurret : MonoBehaviour
{
    [SerializeField] float shotCooldown;
    float shotTimer;
    [SerializeField] float maxRotation;
    Transform playerTransform;
    [SerializeField] float rotationSpeed;
    Vector3 direction;
    Quaternion rotation;
    [SerializeField] GameObject bulletPrefab;
    GameObject bullet;
    // Start is called before the first frame update
    void Awake()
    {
        playerTransform = FindObjectOfType<PlayerMovement>().GetComponent<Transform>();
        shotTimer = shotCooldown;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Active()
    {
        shotTimer -= Time.deltaTime;
        Shoot();
        Vector3 vectorToTarget = playerTransform.position - transform.position;
        float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
        if (angle > maxRotation) angle = maxRotation - 180;
        if (angle > maxRotation - 90) angle = maxRotation - 90;
        if (angle < maxRotation - 180) angle = maxRotation - 180;
        Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * rotationSpeed);
        if (transform.rotation.z > maxRotation - 90)
        {
            //transform.rotation = Quaternion.Euler(0, 0, maxRotation - 90);
        }
        if (transform.rotation.z < maxRotation - 180)
        {
            transform.rotation = Quaternion.Euler(0, 0, maxRotation - 180);
        }
    }

    void Shoot()
    {
        if (shotTimer <= 0)
        {
            bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
            bullet.GetComponent<Rigidbody2D>().AddForce(transform.right * 10, ForceMode2D.Impulse);
            shotTimer = shotCooldown;
        }
        
    }
}

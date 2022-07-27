using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazardBlock : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.SendMessage("Death");
        }
    }
}

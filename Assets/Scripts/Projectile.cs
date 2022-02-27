using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{ 
    //public float health = 6.0f;
 
    void Start()
    {
        Destroy(gameObject, 3);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Target"))
        {
            collision.gameObject.GetComponent<Renderer>().material.color = Color.red;
            //health = health - 2;
            Destroy(collision.gameObject, 1);
        }
        Destroy(gameObject);
    }
}

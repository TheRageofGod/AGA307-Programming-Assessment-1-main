using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public int health;
    public float mySpeed;
    public Size size;

    void Start()
    {
        SetUp();
    }
    void SetUp()
    {
        float easy = 2;
        float medium = 1;
        float hard = 0.5f;
        switch (size)
        {
            case Size.SMALL:
                transform.localScale = Vector3.one * hard;
                GetComponent<Renderer>().material.color = Color.red;
                mySpeed = 0.0075f;
                break;
            case Size.MEDIUM:
                transform.localScale = Vector3.one * medium;
                GetComponent<Renderer>().material.color = Color.yellow;
                mySpeed = 0.005f;
                break;
            case Size.LARGE:
                transform.localScale = Vector3.one * easy;
                GetComponent<Renderer>().material.color = Color.green;
                mySpeed = 0.0025f;
                break;
            default:
                transform.localScale = Vector3.one * easy;
                break;

        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Projectile"))
        {
            Hit(2);
        }
       
    }
    void Hit(int _damage)
    {

        health -= _damage;
        if (health <= 0)
        {
            GameEvents.ReportEnemyDied(this);
        }
        else
            GameEvents.ReportEnemyHit(this);
    }
}

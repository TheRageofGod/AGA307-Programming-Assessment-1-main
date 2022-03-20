using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Size
{
    SMALL, MEDIUM, LARGE
}
public class TargetManager : Singleton<TargetManager>
{
    float moveDistance = 500f;
    public Size size;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        SetUp();
        StartCoroutine(moveRandom());
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
                speed = 0.0075f;
                break;
                case Size.MEDIUM:
                transform.localScale = Vector3.one * medium;
                GetComponent<Renderer>().material.color = Color.yellow;
                speed = 0.005f;
                break;
                case Size.LARGE:
                transform.localScale = Vector3.one * easy;
                GetComponent<Renderer>().material.color = Color.green;
                speed = 0.0025f;
                break;
            default:
                transform.localScale = Vector3.one * easy;
                break;

            }
   }
    IEnumerator moveRandom()
    {
        Vector3 direction = new Vector3();
        int rnd = Random.Range(0, 5);

        if (rnd == 0)
            direction = Vector3.back;
        if (rnd == 1)
            direction = Vector3.forward;
        if (rnd == 2)
            direction = Vector3.down;
        if (rnd == 3)
            direction = Vector3.right;
        if (rnd == 4)
            direction = Vector3.up;
        if (rnd == 5)
            direction = Vector3.left;

        for (int i = 0; i < moveDistance; i++)
        {
            transform.Translate(direction * speed);
            yield return null;
        }
        yield return new WaitForSeconds(3);

        StartCoroutine(moveRandom());
    }

}

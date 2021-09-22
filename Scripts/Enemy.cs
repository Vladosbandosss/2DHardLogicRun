using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
   
    [SerializeField]public static  float moveSpeed=2f;
    [SerializeField] private bool moveLeft;
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (moveLeft)
        {
            Vector3 temp = transform.position;
            temp.x -= moveSpeed * Time.deltaTime;
            transform.position = temp;
        }
        else
        {
            Vector3 temp = transform.position;
            temp.x += moveSpeed * Time.deltaTime;
            transform.position = temp;
        }
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.tag == "bounce")
        {
            moveLeft = !moveLeft;
        }
    }

    public static void UpSpeed()
    {
        moveSpeed += 0.5f;
    }
}

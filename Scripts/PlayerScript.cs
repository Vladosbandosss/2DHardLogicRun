using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] float move = 3f;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        HorizontalMove();

        VerticalMove();
    }

    private void VerticalMove()
    {
        if (Input.GetAxisRaw("Vertical") > 0)//up
        {
            Vector2 temp = transform.position;
            temp.y += move * Time.deltaTime;
            transform.position = temp;
        }
        if (Input.GetAxisRaw("Vertical") < 0)//doun
        {
            Vector2 temp = transform.position;
            temp.y -= move * Time.deltaTime;
            transform.position = temp;
        }
    }

    private void HorizontalMove()
    {
        if (Input.GetAxisRaw("Horizontal") > 0)//right
        {
            Vector2 temp = transform.position;
            temp.x += move * Time.deltaTime;
            transform.position = temp;
        }

        if (Input.GetAxisRaw("Horizontal") < 0)//left
        {
            Vector2 temp = transform.position;
            temp.x -= move * Time.deltaTime;
            transform.position = temp;
        }
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.tag == "Enemy")
        {
            //создай гейм манагер смерти
            GameManager.instance.RestartGame();
          
        }
        if (coll.tag == "goal")
        {
            GameManager.instance.UpLevel();
            Debug.Log("победа");
            //гейм манагер достиг цели
        }
    }
}

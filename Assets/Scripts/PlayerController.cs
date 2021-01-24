using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    private Rigidbody2D rb2d;
    public float speed;

    public float time = 12;
    public bool timeRun = false;

    public Text startText;
    public Text winText;
    public Text loseText;
    public Text timeText;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        speed = 0;
        timeRun = true;
        startText.text = "Use W and S to move. Avoid the Missiles.";
        timeText.text = time.ToString("Time: " + time);
        winText.text = "";
        loseText.text = "";
    }

    void FixedUpdate()
    {
        float moveHorizontal = 0;
        float moveVertical = Input.GetAxis ("Vertical");
        Vector2 movement = new Vector2 (moveHorizontal, moveVertical);
        rb2d.AddForce (movement * speed);
    }

    void Update()
    {
        if (timeRun)
        {
            if (time <= 10)
            {
                speed = 20;
                startText.text = "";
            }

            if (time > 0)
            {
                time -= Time.deltaTime;
                timeText.text = time.ToString("Time: " + time);
            }
            else
            {
                time = 0;
                timeRun = false;
                speed = 0;
                loseText.text = "Game Over.";
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Win")
        {
            speed = 0;
            winText.text = "You win! Game created by Casey Temple.";
            timeRun = false;
        }

        if (collision.collider.tag == "Enemy")
        {
            speed = 0;
            loseText.text = "Game Over.";
            timeRun = false;
        }
    }
}

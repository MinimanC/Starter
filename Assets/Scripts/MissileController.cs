using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileController : MonoBehaviour
{
    public Transform position;
    public float xCenter = 0f;
    private SpriteRenderer Sprite;

    void Start()
    {
        position = this.transform.Find("Transform");
        Sprite = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        transform.position = new Vector3(xCenter + Mathf.PingPong(Time.time * 2, 6) - 6/2f, transform.position.y, transform.position.z);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player")
        {
            Destroy(this);
        }
    }
}
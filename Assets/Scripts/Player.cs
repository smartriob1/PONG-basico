using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed;
    private Rigidbody2D rb;
    private Vector2 startPos;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float move = 0;

        if (gameObject.CompareTag("Player1"))
        {
             move = Input.GetAxisRaw("Vertical");

        }else if (gameObject.CompareTag("Player2"))
        {
             move = Input.GetAxisRaw("Vertical2");

        }

        rb.velocity = new Vector2 (rb.velocity.x, move * speed);
    }

    public void Reset()
    {
        rb.velocity = Vector2.zero;
        transform.position = startPos;
    }
}

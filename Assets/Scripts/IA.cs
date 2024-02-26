using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IA : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private GameObject pelota;
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
        if(transform.position.y > pelota.transform.position.y)
        {
            transform.Translate(Vector2.down * speed * Time.deltaTime);

        }else if (transform.position.y < pelota.transform.position.y)
        {
            transform.Translate(Vector2.up * speed * Time.deltaTime);
        }
        //rb.velocity = new Vector2(rb.velocity.x, posicion * speed);
    }
}

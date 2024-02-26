using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pelota : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private AudioSource fuente;
    [SerializeField] private AudioClip rebotar;
    private Rigidbody2D rb;
    private Vector2 startPos;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        rb = GetComponent<Rigidbody2D>();
        Lanzar();
    }

    void Lanzar()
    {
        float x = Random.Range(0,2) == 0 ? -1 : 1;
        float y = Random.Range(0,2) == 0 ? -1 : 1;
        rb.velocity = new Vector2(speed * x, speed * y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        fuente.clip = rebotar;
        fuente.Play();
        VelocityFix();
    }

    private void VelocityFix()
    {
        float velocidadDelta = 0.5f; 
        float velocidadMinima = 0.2f;

        if (Mathf.Abs(rb.velocity.x) < velocidadMinima)
        {
            velocidadDelta = Random.value < 0.5f ? velocidadDelta : -velocidadDelta; 
            rb.velocity = new Vector2(rb.velocity.x + velocidadDelta, rb.velocity.y); 
        }

        if (Mathf.Abs(rb.velocity.y) < velocidadMinima) 
        {
            velocidadDelta = Random.value < 0.5f ? velocidadDelta : -velocidadDelta;
            rb.velocity += new Vector2(0f, velocidadDelta);
        }
    }

    public void Reset()
    {
        rb.velocity = Vector2.zero;
        transform.position = startPos;
        Lanzar();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarcarGol : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Pelota"))
        {
            if (gameObject.CompareTag("GolPlayer1"))
            {
                FindObjectOfType<GameManager>().MarcarGol(1);
            }
            else if (gameObject.CompareTag("GolPlayer2"))
            {
                FindObjectOfType<GameManager>().MarcarGol(2);
            }
        }
    }
}

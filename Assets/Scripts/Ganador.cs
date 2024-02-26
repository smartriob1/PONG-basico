using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ganador : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI ganador;
    private GameManager gameManager;

    // This method is called when the game starts
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        ganador.text = gameManager.GetComponent<GameManager>().GetGanador();
    }

    public void LoadMainMenu()
    {
        Destroy(gameManager.gameObject);
        SceneManager.LoadScene("Menú");
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject pelota, player1, player2;
    [SerializeField] private TextMeshProUGUI score1, score2;
    [SerializeField] bool pvp;
    [SerializeField] int victoria;
    private int golesPlayer1, golesPlayer2 = 0;
    private String ganador;
    private static GameManager _instance;

    void Awake()
    {
        if (_instance == null)
        {
            _instance = this; // Esto hace seguro que el GameManager no sea destruido cuando una nueva escena está cargada
            DontDestroyOnLoad(gameObject); // This makes sure the GameManager is not destroyed when a new scene is loaded
        }
        else
        {
            Destroy(gameObject);    // Esto destuye el GameManager si hay uno ya en la escena
        }
    }

    public void MarcarGol(int jugador)
    {
        if(jugador == 1)
        {
            golesPlayer1++;
            score1.text = golesPlayer1.ToString();
        }
        else if(jugador == 2)
        {
            golesPlayer2++;
            score2.text = golesPlayer2.ToString();
        }
        HaGanado();
        ResetPosiciones();
    }

    void HaGanado()
    {
        if(golesPlayer1 >= victoria)
        {
            ganador = "Jugador 1";
            SceneManager.LoadScene("Ganador");
        }else if (golesPlayer2 >= victoria && pvp)
        {
            ganador = "Jugador 2";
            SceneManager.LoadScene("Ganador");
        }
        else if (golesPlayer2 >= victoria && !pvp)
        {
            ganador = "IA";
            SceneManager.LoadScene("Ganador");
        }
    }
    void ResetPosiciones()
    {
        pelota.GetComponent<Pelota>().Reset();
        player1.GetComponent<Player>().Reset();
        if (pvp)
        {
            player2.GetComponent<Player>().Reset();
        }
    }

    public String GetGanador()
    {
        return ganador;
    }
}

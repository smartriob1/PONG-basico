using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{

    public void LoadIA()
    {
        SceneManager.LoadScene("JuegoIA");
    }
    public void LoadPVP()
    {
        SceneManager.LoadScene("JuegoPVP");
    }
}

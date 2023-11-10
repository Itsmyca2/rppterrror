using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipalManeger : MonoBehaviour
{
    [SerializeField] private string nomePrimeiraCena;
    public void Jogar()
    {
        SceneManager.LoadScene("DialogoInicial");
    }

    public void Sair()
    {
        Debug.Log("saiu");
        Application.Quit();
    }
}

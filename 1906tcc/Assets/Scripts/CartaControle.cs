using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class CartaControle : MonoBehaviour
{
    public TextMeshProUGUI textoFalado;

    public float tempoFala;
    private string[] frases;
    private int index;

    public void FalaCarta(string[] txt)
    {
        frases = txt;
        StartCoroutine(TypeFrases());
    }

    public void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            SceneManager.LoadScene("DialogoInicial");
        }
    }

    private IEnumerator TypeFrases()
    {
        textoFalado.text = "";
        foreach (char letras in frases[index].ToCharArray())
        {
            textoFalado.text += letras;
            yield return new WaitForSeconds(tempoFala);
        }
    }

    public void PassarDialogo()
    {
        if (textoFalado.text == frases[index])
        {
            //ainda tem textos
            if (index < frases.Length - 1)
            {
                index++;
                textoFalado.text = "";
                StartCoroutine(TypeFrases());
            }
            else //quando acaba os textos 
            {
                textoFalado.text = "";
                index = 0;
            }
        }
    }
}

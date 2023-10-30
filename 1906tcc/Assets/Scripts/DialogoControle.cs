using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogoControle : MonoBehaviour
{
    public GameObject dialogoObje;
    public Image perfilPersonagem;
    public TextMeshProUGUI textoFalado;
    public TextMeshProUGUI nomePersonagem;

    public float tempoFala;
    private string[] frases;
    private int index;

    public void Fala(Sprite p, string [] txt, string n)
    {
        
        perfilPersonagem.sprite = p;
        frases = txt;
        nomePersonagem.text = n;
        StartCoroutine(TypeFrases());
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
                dialogoObje.gameObject.SetActive(false);
                textoFalado.text = "";
                index = 0;
            }
        }
    }

}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogo : MonoBehaviour
{
   public GameObject dialogoObj;
   public Sprite foto;
   public string[] textofalado;
   public string nome;

   private DialogoControle dc;

   private void Start()
   {
      dialogoObj.SetActive(false);
      dc = FindObjectOfType<DialogoControle>();
   }
   
   
   public void OnTriggerEnter2D(Collider2D other)
   {
      if (other.gameObject.CompareTag("Player"))
      {
         dialogoObj.SetActive(true);
         dc.Fala(foto, textofalado, nome);
      }
      
   }

   public void OnTriggerExit2D(Collider2D other)
   {
      dialogoObj.SetActive(false);
   }
}

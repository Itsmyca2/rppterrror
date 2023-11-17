using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CartaDialogo : MonoBehaviour
{
    public string [] textofalado;

    private CartaControle dc;

    private void Start()
    {
         dc = FindObjectOfType<CartaControle>();
         dc.FalaCarta(textofalado);
    }
   
   
   
        
           
        
      
   
}

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PortaPalacio : MonoBehaviour
{
     public void OnTriggerEnter2D(Collider2D other)
     {
          if (other.gameObject.CompareTag("Player"))
          {
               SceneManager.LoadScene("Palacio");
          }
     }
}

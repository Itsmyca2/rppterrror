using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenuController : MonoBehaviour
{
   
    
        public void VoltarGameOver()
        {
            GameManeger.instance.LoadScene();
        }
    
}



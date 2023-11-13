using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CriaJogador : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameManeger.instance.AdicionarJogador();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

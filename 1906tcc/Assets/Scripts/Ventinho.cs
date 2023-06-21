using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ventinho : MonoBehaviour
{
    public float ventoVelocidade;
        
        // Start is called before the first frame update
        void Start()
        {
            
        }
    
        // Update is called once per frame
        void Update()
        {
            MovimentoVento();
        }
    
        void MovimentoVento()
        {
            transform.Translate(Vector3.right * ventoVelocidade * Time.deltaTime);
        }
}

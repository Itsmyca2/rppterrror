using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropItens : MonoBehaviour
{
    public GameObject item;
    public int itemDropPorcentagem;
    public int itemMinDrop;
    public int itemMaxDrop;
    
    
    public void Drop()
    {
        int rand = Random.Range(1, 100);
        if (rand < itemDropPorcentagem)
        {
            int amout = Random.Range(itemMinDrop, itemMaxDrop);

            for (int i = 0; i < amout; i++)
            {
                Instantiate(item, transform.position, transform.rotation);
            }
            
        }
        
    }
    
}

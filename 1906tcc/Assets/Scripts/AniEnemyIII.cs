using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AniEnemyIII : MonoBehaviour
{
    public Animator inimigoIIIAnimator;

    public string animName;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void InimigoIII(string animationNome)
    {
        //if(animName== animationNome) return;
        
        animName = animationNome;
        inimigoIIIAnimator.Play(animationNome);
    }
}

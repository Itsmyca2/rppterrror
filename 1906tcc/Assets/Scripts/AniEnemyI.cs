using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AniEnemyI : MonoBehaviour
{
    public Animator inimigoIAnimator;

    public string animName;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void InimigoI(string animationNome)
    {
        if(animName== animationNome) return;
        
        animName = animationNome;
        inimigoIAnimator.Play(animationNome);
    }
}

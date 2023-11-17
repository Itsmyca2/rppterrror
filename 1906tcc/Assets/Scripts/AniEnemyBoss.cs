using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AniEnemyBoss : MonoBehaviour
{
    public Animator inimigoTioAnimator;
    public string animName;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void InimigoTio(string animationName)
    {
        if(animName== animationName) return;
        
        animName = animationName;
        inimigoTioAnimator.Play(animationName);
    }
}

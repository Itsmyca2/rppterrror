using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AniEnemyII : MonoBehaviour
{
    public Animator inimigoIIAnimator;

    public string animName;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void InimigoII(string animationName)
    {
        if(animName== animationName) return;
        
        animName = animationName;
        inimigoIIAnimator.Play(animationName);
    }
}

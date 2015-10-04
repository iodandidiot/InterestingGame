using UnityEngine;
using System.Collections;

public class explotion : MonoBehaviour {

    Animator __animator;


    public void __AnimAndDestroy()
    {
        __animator = GetComponent<Animator>();
        __animator.SetBool("Destroy", true);  
    }
    public void __Destroy()
    {
        Destroy(gameObject);
    }
    //void OnDestroy() 
    //{
    //    __animator = GetComponent<Animator>();
    //    __animator.SetBool("Destroy", true);  

    //}
}

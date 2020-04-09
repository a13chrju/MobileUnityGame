using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class humanAnim : MonoBehaviour
{
    Animator m_Animator;
    private move moveclass;
    // Use this for initialization
    void Start()
    {
        moveclass = GetComponent<move>();
        m_Animator = GetComponent<Animator>();
    }


    // Update is called once per frame
    void Update()
    {
        if (moveclass.moveRight > 0)
        {
            m_Animator.SetBool("running", true);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boulder : MonoBehaviour
{
    // Start is called before the first frame update
    private Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "player")
        {
           
            StartCoroutine(dieCoroutine());
        }
    }

  

    IEnumerator dieCoroutine()
    {
    //yield on a new YieldInstruction that waits for 5 seconds.
    yield return new WaitForSeconds(0.5f);
        anim.SetTrigger("die");

    }
}

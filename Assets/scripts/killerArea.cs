using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class killerArea : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject killbox;
    public GameObject creature;
    public bool hasCreature;
    public GameObject player;
    private Animator anim;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("player");
        if (hasCreature)
        {
            anim = creature.GetComponent<Animator>();
        }
  
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "player")
        {
            Debug.Log("YES!!!!");
            if (other.gameObject.GetComponent<move>().isattacking)
            {
                if (hasCreature)
                {
                    anim.SetTrigger("die");
                }
             
                Destroy(killbox);
            }
        }
    }
}

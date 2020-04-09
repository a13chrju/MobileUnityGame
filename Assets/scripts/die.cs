using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class die : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject gameManager;
    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("gameManager");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "player")
        {
            other.GetComponent<move>().die();
            gameManager.GetComponent<gameFile>().die();
          
        }
    }
}

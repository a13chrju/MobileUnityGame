using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class win : MonoBehaviour {

    public Canvas restartCanvas;
    public Canvas winCanvas;
    public move playermovement;
    public GameObject stars, lightexplosion, atchest;
    public Animator anim;
    public float windelay = 0f;
    private bool canbeshown = false;
    public int unlockedLVL;

    // Use this for initialization
    void Start () {
        winCanvas.enabled = false;
    }
	
	// Update is called once per frame
	void Update () {
        if (Time.time > windelay && canbeshown)
        {
            anim.SetBool("added", true);
        }
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "player")
        {
            canbeshown = true;
            windelay = Time.time + 1f;
            playermovement.moveRight = 0f;
            restartCanvas.enabled = false;
            winCanvas.enabled = true;
            Instantiate(stars, atchest.transform.position, atchest.transform.rotation);
            Instantiate(lightexplosion, atchest.transform.position, atchest.transform.rotation);
            var temp = PlayerPrefs.GetInt("levelreached", 1);
            if (temp == (unlockedLVL - 1))
            {
                PlayerPrefs.SetInt("levelreached", unlockedLVL);
            }
        }
    }
}

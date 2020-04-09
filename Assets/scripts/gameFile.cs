using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class gameFile : MonoBehaviour {

    public Text timerText;
    public bool istarted = false;
    public bool playlevel = false;
    public float timeGone, playLevel;
    public float levelLength;
    public List<executeCommandModel> jumpedat;
    public CanvasGroup thisone;
    public move playermovement;
    public Camera playerCamera;
    public Camera levelCamera;
    public float index = 0;
    public Canvas playingCanvas;
    public Transform startposition;
    public Button attkBtn;

    // Use this for initialization
    void Start() {
        playingCanvas.enabled = false;
    }

    [System.Serializable]
    public class executeCommandModel
    {
        public string type { get; set; }
        public float attime { get; set; }

        public executeCommandModel(string type, float attime)
        {
            this.type = type;
            this.attime = attime;
        }
    }

    // Update is called once per frame
    void Update() {

        if (istarted) {
            timeGone += Time.deltaTime;
            timerText.text = timeGone.ToString("f1");
        }
        if (timeGone > levelLength)
        {

            if (playlevel == false) {
                playermovement.moveRight = 3f;
                playlevel = true;
                istarted = false;
                playerCamera.enabled = true;
                levelCamera.enabled = false;
                thisone.alpha = 0;
                playingCanvas.enabled = true;
            }
            playLevel += Time.deltaTime;
            //play recoring




            if (jumpedat.Count > 0)
            {
                if (playLevel > jumpedat[0].attime)
                {
                    if (jumpedat[0].type == "jump")
                    {
                        playermovement.jump();
                    } else if (jumpedat[0].type == "fight")
                    {
                        playermovement.attack();
                    }
                    jumpedat.RemoveAt(0);
                }
            }



        }



    }

    public void ClickedStartTimer()
    {
        istarted = !istarted;
    }

    public void ClickedJump()
    {
        executeCommandModel model = new executeCommandModel("jump", timeGone);
        jumpedat.Add(model);
    }

    public void restart()
    {
        index = 0;
        timeGone = 0f; playLevel = 0f;
        jumpedat.Clear();
        playermovement.moveRight = 0f;
        playermovement.m_Animator.SetTrigger("live");
        playlevel = false;
        istarted = false;
        playerCamera.enabled = false;
        levelCamera.enabled = true;
        thisone.alpha = 1;
        playingCanvas.enabled = false;
        playermovement.GetComponent<Rigidbody>().velocity = Vector3.zero;
        playermovement.GetComponent<Rigidbody>().transform.position = startposition.position;
        Debug.Log(playermovement.moveRight);
    }

    public void alternativeRestart(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void die()
    {
        jumpedat.Clear();
    }

    public void attack()
    {
        executeCommandModel model = new executeCommandModel("fight", timeGone);
        jumpedat.Add(model);
        StartCoroutine(attackEnabledButton());
    }

    IEnumerator attackEnabledButton()
    {
        attkBtn.interactable = false;
        yield return new WaitForSeconds(0.5f);
        attkBtn.interactable = true;
    }

}

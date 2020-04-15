using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class OnEnter : MonoBehaviour
{
    public AudioClip wrongSFX;
    public AudioClip tilesCorrectSFX;
    PlayerMovement pm;

    public GameObject Red;
    public GameObject Black;
    public GameObject White;
    public GameObject Blue;
    public GameObject RedKey;
    public GameObject BlackKey;
    public GameObject WhiteKey;
    public GameObject BlueKey;
    public GameObject key;

    //public Text code;
    public TMP_Text code;
    public TMP_Text riddle;
    public TMP_Text grabText;

    private int count = 0;
    private bool once = false;
    private bool tilesCorrect = false;
    private GameObject mainCamera;
    private FootSteps fs;

    private void Start()
    {
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        pm = player.GetComponent<PlayerMovement>();
        fs = mainCamera.GetComponent<FootSteps>();
        once = false;
        tilesCorrect = false;
    }

    private void Update()
    {
        if (count == 4)
        {
            if(code.text.Equals("CROW") || (code.text.Equals("CROW was correct")))
            {
                if (code.text.Equals("CROW"))
                {
                    if (!tilesCorrect)
                    {
                        tilesCorrect = true;
                        AudioSource.PlayClipAtPoint(tilesCorrectSFX, mainCamera.transform.position);
                        code.text += " was correct";
                        key.SetActive(true);
                        grabText.gameObject.SetActive(false);
                        riddle.gameObject.SetActive(true);
                        PlayerBehavior.tilesOpened = true;
                    }
                }
            }
            else
            {
                pm.playerWon();
                fs.StopAudio();
                if (!once)
                {
                    AudioSource.PlayClipAtPoint(wrongSFX, mainCamera.transform.position);
                    code.text += " was incorect";
                    once = true;
                }

                Invoke("ChangeScene", 4f);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Blue")
        {
            Blue.SetActive(false);
            BlueKey.SetActive(true);
            code.text += "C";
            count++;

        }
        else if(other.gameObject.tag == "Red")
        {
            Red.SetActive(false);
            RedKey.SetActive(true);
            code.text += "R";
            count++;
        }
        else if (other.gameObject.tag == "White")
        {
            White.SetActive(false);
            WhiteKey.SetActive(true);
            code.text += "O";
            count++;
        }
        else if (other.gameObject.tag == "Black")
        {
            Black.SetActive(false);
            BlackKey.SetActive(true);
            code.text += "W";
            count++;
        }

    }
    private void ChangeScene()
    {
        SceneManager.LoadScene(0);
    }
}

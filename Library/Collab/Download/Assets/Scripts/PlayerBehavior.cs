using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBehavior : MonoBehaviour
{
    public GameObject key;
    public Text textKey;
    public Transform keyPosition;
    public Transform playerPosition;
    public AudioClip doorOpenSFX;
    public Text escapedText;
    public Transform doorPosition;
    public PlayerMovement pm;

    public static bool tilesOpened;

    bool grabbed;
    GameObject mainCamera;
    FootSteps fs;
    bool once = false;

    // Start is called before the first frame update
    void Start()
    {
        grabbed = false;
        tilesOpened = false;
        once = false;
        escapedText.text = "";
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
        fs = mainCamera.GetComponent<FootSteps>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!grabbed)
        {
            float distance = Vector3.Distance(keyPosition.position, playerPosition.position);
            if (distance < 1.8f)
            {
                if (tilesOpened && Breakable.broken)
                {
                    textKey.text = "Press E to grab Key!";
                    if (Input.GetKeyDown("e"))
                    {
                        grabbed = true;
                        textKey.enabled = false;
                        key.transform.SetParent(gameObject.transform);
                    }
                }
            }
            else
            {
                textKey.text = "";
            }
        }
        else
        {
            float doorDistance = Vector3.Distance(doorPosition.position, playerPosition.position);
            if (doorDistance < 2.3f)
            {
                if (!once)
                {
                    pm.playerWon();
                    fs.StopAudio();
                    AudioSource.PlayClipAtPoint(doorOpenSFX, mainCamera.transform.position);
                    escapedText.text = "YOU'VE ESCAPED!";
                    once = true;
                }

            }
        }
    }
}

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
    private bool grabbed;
    public Text escapedText;
    public Transform doorPosition;
    public PlayerMovement pm;

    // Start is called before the first frame update
    void Start()
    {
        grabbed = false;
        escapedText.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        if (!grabbed)
        {
            float distance = Vector3.Distance(keyPosition.position, playerPosition.position);
            if (distance < 1.8f)
            {
                textKey.text = "Press E to grab Key!";
                if (Input.GetKeyDown("e"))
                {
                    grabbed = true;
                    textKey.enabled = false;
                    key.transform.SetParent(gameObject.transform);
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
            Debug.Log(doorDistance);
            if (doorDistance < 2.3f)
            {
                escapedText.text = "YOU'VE ESCAPED!";
                pm.playerWon();

            }
        }
    }
        

    //void OnControllerColliderHit(ControllerColliderHit hit)
    //{
    //    if (hit.gameObject.tag == "door" && grabbed)
    //    {
    //        escapedText.enabled = true;
    //    }
    //}
}

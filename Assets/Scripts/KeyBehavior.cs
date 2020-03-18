using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyBehavior : MonoBehaviour
{
    public Transform player;
    public Text keyText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(player.position, transform.position);
        Debug.Log(distance);
        if (distance < 1.5f)
        {
            keyText.text = "Press E to grab Key!";
        } else
        {
            keyText.text = "";
        }
    }
}

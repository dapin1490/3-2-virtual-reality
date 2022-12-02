using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialoglist : MonoBehaviour
{
    public GameObject logUI;
    GameObject player;
    public string[] dialog;
    public TMP_Text logtext;
    int turn = 0;
    string defaultText;

    // Start is called before the first frame update
    void Start()
    {
        print("dialog script start");
        logUI.gameObject.SetActive(false);
        defaultText = logtext.text;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKeyDown("e") && other.tag == "Player")
        {
            logUI.gameObject.SetActive(true);
            player = other.gameObject;
            player.GetComponent<Rigidbody>().isKinematic = true;
            Dialog();
        }
    }

    public void Dialog()
    {
        if (turn < dialog.Length)
        {
            logtext.text = dialog[turn++];
        }
        else
        {
            logUI.gameObject.SetActive(false);
            player.gameObject.GetComponent<Rigidbody>().isKinematic = false;
            turn = 0;
            logtext.text = defaultText;
        }
    }
}

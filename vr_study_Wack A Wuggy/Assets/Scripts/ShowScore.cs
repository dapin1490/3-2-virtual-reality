using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShowScore : MonoBehaviour
{
    public GameObject Player;
    public TMP_Text logtext;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        logtext.text = "점수 : " + Player.GetComponent<PlayerScore>().score;
    }
}

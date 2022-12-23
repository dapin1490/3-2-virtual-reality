using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShowScore : MonoBehaviour
{
    public GameObject Player;
    public TMP_Text logtext;
    int score;

    // Start is called before the first frame update
    void Start()
    {
        score = Player.GetComponent<PlayerScore>().score;
    }

    // Update is called once per frame
    void Update()
    {
        if (score != Player.GetComponent<PlayerScore>().score)
        {
            score = Player.GetComponent<PlayerScore>().score;
            logtext.text = Player.name + "/n점수 : " + Player.GetComponent<PlayerScore>().score;
            print("player score : " + score);
        }
    }
}

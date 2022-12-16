using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogPressE : MonoBehaviour
{
    GameObject player;
    string[] dialog;
    public TMP_Text logtext;
    int turn = 0;
    string defaultText;

    // Start is called before the first frame update
    void Start()
    {
        print("dialog script start");
        defaultText = logtext.text;

        dialog = new string[]
        {
            "게임 방법을 안내합니다. 다음으로 넘어가려면 E를 누르세요.",
            "이것은 \"상어 잡기\" 게임입니다.",
            "우측에 보이는 파란 원 안에 들어가면 게임이 시작됩니다.",
            "게임이 시작되면 하얀 벽이 나타납니다.",
            "총 9마리의 상어가 하얀 벽에서 튀어나옵니다.",
            "각 상어는 랜덤하게 튀어나오고, 랜덤하게 들어갈 수 있습니다.",
            "상어를 클릭하면 점수가 누적됩니다.",
            "파란 원 밖으로 나가면 게임이 종료됩니다.",
            "언제든 다시 파란 원 안으로 들어가 게임을 이어서 할 수 있습니다.",
            "설명이 끝났습니다. E를 눌러 안내를 종료하세요."
        };
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKeyDown("e") && other.tag == "Player")
        {
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
            player.gameObject.GetComponent<Rigidbody>().isKinematic = false;
            turn = 0;
            logtext.text = defaultText;
        }
    }
}

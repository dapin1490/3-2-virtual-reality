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
    bool InTrigger;
    int frame;

    // Start is called before the first frame update
    void Start()
    {
        print("dialog script start");
        defaultText = logtext.text;
        InTrigger = false;
        frame = 0;

        dialog = new string[]
        {
            "게임 방법을 안내합니다. 다음으로 넘어가려면 키보드 E 또는 컨트롤러 A 버튼을 누르세요.",
            "이것은 \"상어 잡기\" 게임입니다.",
            "우측에 보이는 파란 원 안에 들어가면 게임이 시작됩니다.",
            "게임이 시작되면 하얀 벽이 나타납니다.",
            "총 9마리의 상어가 하얀 벽에서 튀어나옵니다.",
            "각 상어는 랜덤하게 튀어나오고, 랜덤하게 들어갈 수 있습니다.",
            "E키 또는 A버튼으로 왼쪽에 보이는 창을 집어 상어를 공격할 수 있습니다.",
            "상어를 공격하면 점수가 누적되며 상어가 들어갑니다.",
            "파란 원 밖으로 나가면 게임이 비활성화됩니다.",
            "언제든 다시 파란 원 안으로 들어가 게임을 이어서 할 수 있습니다.",
            "R키 또는 B버튼을 누르면 점수를 초기화할 수 있습니다.",
            "P키 또는 X버튼을 길게 누르면 게임이 초기화됩니다.",
            "설명이 끝났습니다. E키 또는 A버튼을 눌러 안내를 종료하세요."
        };
    }

    // Update is called once per frame
    void Update()
    {
        frame += 1;
        if (InTrigger && (Input.GetKeyDown(KeyCode.E) || OVRInput.Get(OVRInput.Button.One)) && frame >= 60)
        {
            frame = 0;
            print("dialog: E");
            Dialog();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        print("in : " + other.name);
        if (other.tag == "Player")
        {
            InTrigger = true;
            player = other.gameObject;
        }
    }

    //private void OnTriggerStay(Collider other)
    //{
    //    if (other.tag == "Player" && (Input.GetKeyDown(KeyCode.E) || OVRInput.Get(OVRInput.Button.One)))
    //    {
    //        player = other.gameObject;
    //        player.GetComponent<Rigidbody>().isKinematic = true;
    //        Dialog();
    //    }
    //}

    private void OnTriggerExit(Collider other)
    {
        print("out : " + other.name);
        if (other.tag == "Player")
        {
            InTrigger = false;
        }
    }

    public void Dialog()
    {
        if (turn < dialog.Length)
        {
            //player.GetComponent<Rigidbody>().isKinematic = true;
            logtext.text = dialog[turn++];
            print(logtext.text);
        }
        else
        {
            //player.gameObject.GetComponent<Rigidbody>().isKinematic = false;
            turn = 0;
            logtext.text = defaultText;
        }
    }
}

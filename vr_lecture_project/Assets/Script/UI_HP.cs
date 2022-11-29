using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // TMP텍스트를 사용할 때 추가해 줍시다.

public class UI_HP : MonoBehaviour
{
    public TMP_Text myHP; // 텍스트 변수입니다.
    public int HP; // 실제 hp를 넣는 변수입니다.

    void Start() // 처음 시작할 때 표시합니다.
    {
        HP = GetComponent<EnemyDamaged>().HP; // hp를 가져와서 hp변수에 넣습니다.
        myHP.text = "HP:" + HP.ToString(); //UI텍스트에 HP : 라는 문구를 넣고 hp변수를 문자(string)으로 변환해 추가합니다. 
    }

    private void OnTriggerEnter(Collider col) //충돌이 들어 오면 실행합니다. 
    {
        HP = GetComponent<EnemyDamaged>().HP; // 위와 동일하되 충돌이 발생할 때만 갱신합니다.
        myHP.text = "HP:" + HP.ToString();
    }
}

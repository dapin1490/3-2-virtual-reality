using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // TMP�ؽ�Ʈ�� ����� �� �߰��� �ݽô�.

public class UI_HP : MonoBehaviour
{
    public TMP_Text myHP; // �ؽ�Ʈ �����Դϴ�.
    public int HP; // ���� hp�� �ִ� �����Դϴ�.

    void Start() // ó�� ������ �� ǥ���մϴ�.
    {
        HP = GetComponent<EnemyDamaged>().HP; // hp�� �����ͼ� hp������ �ֽ��ϴ�.
        myHP.text = "HP:" + HP.ToString(); //UI�ؽ�Ʈ�� HP : ��� ������ �ְ� hp������ ����(string)���� ��ȯ�� �߰��մϴ�. 
    }

    private void OnTriggerEnter(Collider col) //�浹�� ��� ���� �����մϴ�. 
    {
        HP = GetComponent<EnemyDamaged>().HP; // ���� �����ϵ� �浹�� �߻��� ���� �����մϴ�.
        myHP.text = "HP:" + HP.ToString();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamaged : MonoBehaviour
{
    bool ready = true;
    float delay = 0.5f;
    bool hitted;
    public GameObject Player;

    private void Start()
    {
        hitted = this.GetComponent<IsHitted>();
    }

    private void OnTriggerEnter(Collider col)//충돌이 들어 오면 실행합니다. 
    {
        if (col.gameObject.tag == "Grabbable" && ready)//HeroAttack이란 태그를 가진 물체가 들어오면 실행합니다.
        {
            print(this.gameObject.name + " hit");
            hitted = true;
            ready = false;//피격불가시간을 갖습니다.
            Player.GetComponent<PlayerScore>().score += 1;
            StartCoroutine(Wait());
        }

        IEnumerator Wait()  //다단히트를 방지하기 위한 딜레이입니다.
        {
            yield return new WaitForSeconds(delay);  //delay
            ready = true;  //피격준비상태로 바꿉니다.
            hitted = false;
        }
    }
}
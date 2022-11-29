using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamaged : MonoBehaviour
{
    public int HP = 5;//얻어맞는 적의 hp입니다.
    public GameObject dead;
    public GameObject effect;
    bool ready = true;
    float delay = 0.5f;

    private void OnTriggerEnter(Collider col)//충돌이 들어 오면 실행합니다. 
    {
        if (col.gameObject.tag == "HeroAttack" && ready)//HeroAttack이란 태그를 가진 물체가 들어오면 실행합니다.
        {
            int damagefromHero = col.gameObject.GetComponent<WeaponDamage>().weapondamage;
            //충돌한 물체의 WeaponDamage콤포넌트를 가져와 그 안의 weapondamage란 변수를 damagefromHero로 저장합니다.
            HP = HP - damagefromHero; //그 변수값을 기존 hp값에서 뺀 뒤 다시 저장합니다.
            ready = false;//피격불가시간을 갖습니다.
            Instantiate(effect, col.transform.position, col.transform.rotation); //지정된 오브젝트를 불러 옵니다.
            StartCoroutine(Wait());
        }

        if (HP <= 0) //만일 hp가 0 이하가 되면 아래와 같이 실행합니다.
        {
            Destroy(gameObject, 0); //0초 후 해당 물체를 삭제합니다.
            Instantiate(dead, transform.position, transform.rotation); //지정된 오브젝트를 불러 옵니다.
        }

        IEnumerator Wait()  //다단히트를 방지하기 위한 딜레이입니다.
        {
            yield return new WaitForSeconds(delay);  //delay
            ready = true;  //피격준비상태로 바꿉니다.
        }
    }
}
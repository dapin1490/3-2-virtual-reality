using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamaged : MonoBehaviour
{
    public int HP = 5;//���´� ���� hp�Դϴ�.
    public GameObject dead;
    bool ready = true;
    float delay = 0.5f;

    private void OnTriggerEnter(Collider col)//�浹�� ��� ���� �����մϴ�. 
    {
        if (col.gameObject.tag == "HeroAttack" && ready)//HeroAttack�̶� �±׸� ���� ��ü�� ������ �����մϴ�.
        {
            int damagefromHero = col.gameObject.GetComponent<WeaponDamage>().weapondamage;
            //�浹�� ��ü�� WeaponDamage������Ʈ�� ������ �� ���� weapondamage�� ������ damagefromHero�� �����մϴ�.
            HP = HP - damagefromHero; //�� �������� ���� hp������ �� �� �ٽ� �����մϴ�.
            ready = false;//�ǰݺҰ��ð��� �����ϴ�.
            StartCoroutine(Wait());
        }

        if (HP <= 0) //���� hp�� 0 ���ϰ� �Ǹ� �Ʒ��� ���� �����մϴ�.
        {
            Destroy(gameObject, 0); //0�� �� �ش� ��ü�� �����մϴ�.
            Instantiate(dead, transform.position, transform.rotation); //������ ������Ʈ�� �ҷ� �ɴϴ�.
        }

        IEnumerator Wait()  //�ٴ���Ʈ�� �����ϱ� ���� �������Դϴ�.
        {
            yield return new WaitForSeconds(delay);  //delay
            ready = true;  //�ǰ��غ���·� �ٲߴϴ�.
        }
    }
}

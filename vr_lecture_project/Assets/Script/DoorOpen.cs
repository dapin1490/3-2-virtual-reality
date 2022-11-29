using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpen : MonoBehaviour
{
    Animator animator;
    public float distance = 1f;
    public GameObject rayOrigin; //ray가 시작될 지점입니다. 게임오브젝트를 생성해서 넣어줍시다.
    void Start()
    {
        this.animator = GetComponent<Animator>();
    }

    private void Update()
    {
        RaycastHit hit; // ray의 충돌체를 지정합니다.
        if (Input.GetKeyDown("e"))
        {
            Vector3 fwd = transform.TransformDirection(Vector3.forward);
            //현재 게임오브젝트의 방향값을 검출하여 벡터3값으로 나타냅니다.
            Debug.DrawRay(rayOrigin.transform.position, fwd*distance, Color.red);
            //씬창에서 레이가 어떻게 나가고 있는지 보여줍니다.
            if (Physics.Raycast(rayOrigin.transform.position, fwd, out hit, distance))
            {
                // 일정거리만큼 ray를 발사하여 충돌체를 검출합니다.(out hit)
                // hit은 이제 충돌체를 지칭합니다.

                GameObject hitTarget = hit.collider.gameObject;
                //충돌체의 게임오브젝트변수를 생성합니다.

                if (hitTarget.gameObject.tag == "Door") //충돌체의 태그가 Door라면
                {
                    animator = hitTarget.gameObject.GetComponent<Animator>();
                    this.animator.SetTrigger("onoff"); //애니메이션 트리거 신호를 보냅니다.

                }

            }

        }
    }

}

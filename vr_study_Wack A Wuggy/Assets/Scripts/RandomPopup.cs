using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomPopup : MonoBehaviour
{
    int status = 300;
    int frame = 0;
    bool UpFlag = false;
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        print("RandomPopup script start");
        status = 300;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // status == 15 : popup
        // frame >= 30 && Random.Range(1, 30+1) % 30 == 0 : down
        // if wacked, down rightnow
        frame++;

        if ((UpFlag == false && Random.Range(1, status+1) % status == 0) || frame >= 500)
        {
            UpFlag = true;
            frame = 0;
            anim.SetBool("RdPu_UpFlag", UpFlag);
            anim.SetBool("RdPu_DownFlag", !UpFlag);
            print("up");
        }

        if (UpFlag == true && frame >= 200 && Random.Range(1, status + 1) % status == 0)
        {
            UpFlag = false;
            frame = 0;
            anim.SetBool("RdPu_UpFlag", UpFlag);
            anim.SetBool("RdPu_DownFlag", !UpFlag);
            print("down");
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomPopup : MonoBehaviour
{
    int status;
    int frame = 0;
    bool UpFlag = false;
    bool hitted;

    public float Speed = 2;

    // Start is called before the first frame update
    void Start()
    {
        // print("RandomPopup script start");
        status = 300;
        hitted = this.GetComponent<IsHitted>();
    }

    // Update is called once per frame
    void Update()
    {
        // if wacked, down rightnow
        frame++;

        if (!UpFlag && (Random.Range(1, status + 1) % status == 0 || frame >= 500))
        {
            UpFlag = true;
            frame = 0;
            status = 60;
            transform.Translate(Vector3.left * Speed * 1);
            // print(this.gameObject.name + " up");
        }

        if (UpFlag && ((frame >= 60 && Random.Range(1, status + 1) % status == 0) || hitted))
        {
            UpFlag = false;
            frame = 0;
            status = 300;
            transform.Translate(Vector3.right * Speed * 1);
            hitted = false;
            // print(this.gameObject.name + " down");
        }
    }
}

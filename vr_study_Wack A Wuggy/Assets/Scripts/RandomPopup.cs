using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomPopup : MonoBehaviour
{
    int status;
    int frame = 0;

    public float Speed = 2;

    // Start is called before the first frame update
    void Start()
    {
        // print("RandomPopup script start");
        status = 600;
    }

    // Update is called once per frame
    void Update()
    {
        // if wacked, down rightnow
        frame++;

        if (!this.GetComponent<IsHitted>().popped && (Random.Range(1, status + 1) % status == 0 || frame >= 500))
        {
            this.GetComponent<IsHitted>().popped = true;
            frame = 0;
            status /= 10;
            transform.Translate(Vector3.left * Speed * 1);
            // print(this.gameObject.name + " up");
        }

        if (this.GetComponent<IsHitted>().popped && ((frame >= 60 && Random.Range(1, status + 1) % status == 0) || this.GetComponent<IsHitted>().hitted))
        {
            this.GetComponent<IsHitted>().popped = false;
            frame = 0;
            status *= 10;
            transform.Translate(Vector3.right * Speed * 1);
            this.GetComponent<IsHitted>().hitted = false;
            // print(this.gameObject.name + " down");
        }
    }
}

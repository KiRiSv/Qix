using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerc : MonoBehaviour
{
    // Start is called before the first frame update
    public int movementSpeed;
    Transform tr;
    int facing = 0;
    int lr = 0;
    int ud = 0;
    void Start()
    {
        tr = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        //get the Input from Horizontal axis
        float horizontalInput = Input.GetAxis("Horizontal");
        //get the Input from Vertical axis
        float verticalInput = Input.GetAxis("Vertical");
        int v = 0;
        int h = 0;
        if (verticalInput > 0)
            h = 1;
        else if (verticalInput < 0)
            h = -1;
        if (horizontalInput > 0)
            v = 1;
        else if (horizontalInput < 0)
            v = -1;

        if (facing == 0)
        {
            if (h == 1)
                facing = 2;
            else if (h == -1)
                facing = 4;
            else if (v == 1)
                facing = 1;
            else if (v == -1)
                facing = 3;
        }
        else if (v == 0 && h == 0)
        {
        }
        else if(v == 0)
        {
            if (h == 1)
                facing = 1;
            else 
                facing = 3;
        }
        else if (h == 0)
        {
            if (v == 1)
                facing = 2;
            else
                facing = 4;
        }
        else
        {
            if (lr != h)
            {
                if (h == 1)
                    facing = 1;
                else if (h == -1)
                    facing = 3;
            }
            else if (ud != v)
            {
                if (v == 1)
                    facing = 2;
                else if (v == -1)
                    facing = 4;
            }

        }


        lr = h;
        ud = v;
        int mh = 0;
        int mv = 0;
        switch (facing)
        {
            case 1:
                mv = 1;
                break;
            case 2:
                mh = 1;
                break;
            case 3:
                mv = -1;
                break;
            case 4:
                mh = -1;
                break;
            case 0:
                break;
        }
        tr.position = transform.position + new Vector3(mh * movementSpeed * Time.deltaTime, mv * movementSpeed * Time.deltaTime, 0);

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line : MonoBehaviour
{
    public float moveSpeed;
    float xDirection;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        MyInput();
        MoveLine();


    }
    public void MyInput()
    {
        xDirection = Input.GetAxisRaw("Horizontal");//input == đầu vào; getAxisRaw == get trục đầu vào từ bàn phím < >  || getAxis == được dùng cho 3d
    }
    public void MoveLine()
    {
        //when click btn-left - 10 , click btn-right +10
        if (transform.position.x <= -8f && xDirection < 0 || transform.position.x >= 8f && xDirection > 0)
            return;
        float moveStep = moveSpeed * xDirection * Time.deltaTime;
        transform.position = transform.position + new Vector3(moveStep, 0, 0); // vector3 = XYZ ( x ngang / Y doc / Z xeo)
    }
}


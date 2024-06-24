using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    GameController m_gc;
    private void Start()
    {
        m_gc = FindObjectOfType<GameController>(); // tìm kiếm tắt cả obj có kiểu script giống như biến
    }


    //verify giữa đối tượng game này  & game khác thông qua Tab trong Unity  >> Var 2 frame vào nhau
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            m_gc.IncremenScore(); // kiểm tra biến private trong Unii > ở Script khởi tạo > chọn góc phải trên script >> chọn debug
            Destroy(gameObject);  //muốn bóng va vào line thì ẩn luôn 
            Debug.Log("da va voi gia do");
        }
    }
    //verify giữa đối tượng game này  & game khác thông qua Tab trong Unity  >> Var 2 frame vào nhau && đi xuyên vẫn bất được xự kiện 
    // cần bật isTrigger ở unity phần Collider2D
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("DeathZone"))
        {
            m_gc.SetGameOverState(true);
            Destroy(gameObject);  //muốn bóng va vào line thì ẩn luôn 

            Debug.Log("da va voi DeathZone");
        }
    }
}

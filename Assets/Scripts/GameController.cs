using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject ball;
    public float spawnTime; // thời gian tạo ra quả bóng tiếp theo

    int m_score;
    float m_spawnTime;
    bool m_isGameOver;




    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        //chỉ tạo banh khi có banh không rôi vào vùng deathzone 
        if (m_isGameOver) // kiem tra ket thuc game
        {
            m_spawnTime = 0;
            return;
        }
        //mong muốn 3s sẽ tạo ra 1 trái banh
        m_spawnTime -= Time.deltaTime;  // đếm lùi thời gian
        if (m_spawnTime <= 0) //nếu thời gian về 0 tạo ra >>> set thời gian ở trong Script biến >> SpawnTime
        {
            SpawnBall(); /// Khởi tạo banh >> với biến trong Script Ball 
            m_spawnTime = spawnTime; // tạo liên tục do reset về ban đầu
        }
    }
    //tự tạo bóng ở ngoài vùng 
    public void SpawnBall()
    {
        Vector2 spwanPos = new Vector2(Random.Range(-7, 7), 6); // vector lấy (x,y) (random.ranger[random tu a~b])
        if (ball)
        {
            Instantiate(ball, spwanPos, Quaternion.identity); // instantiate khởi tạo đối tượng  với các thông tin truyền vào [đối tượng muốn khởi tạo , vị trí, góc xoay đối tượng == với Quaternion.indentity = giữ nguyên]
        }
    }

    public void SetScore(int value) { m_score = value; }
    public int GetScore() { return m_score; }
    public void IncremenScore() { m_score++; }
    public bool IsGameover() { return m_isGameOver; }
    public void SetGameOverState(bool state) { m_isGameOver = state; }
}

using UnityEngine;
using System.Collections;

public class Goal : MonoBehaviour
{
    Timer m_Timer;
    ItemUI m_ItemUI;

    // Use this for initialization
    void Start()
    {
        m_Timer = GameObject.Find("Canvas_UI").GetComponent<Timer>();
        m_ItemUI = GameObject.Find("Canvas_UI").GetComponent<ItemUI>();
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        //プレイヤーが落ちたら
        if (other.tag == "Player")
        {
            //プレイヤーが喜ぶとか

            //タイマー止める
            m_Timer.TimerStop();

            //データ保存 
            PlayerPrefs.SetInt("ResultTime", (int)m_Timer.TotalTime);
            PlayerPrefs.SetInt("ResultItem", (int)m_ItemUI.Num);
        }
    }
}


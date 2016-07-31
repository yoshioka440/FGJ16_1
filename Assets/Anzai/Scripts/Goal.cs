using UnityEngine;
using System.Collections;

public class Goal : MonoBehaviour
{
	public GameObject gameManager;

    Timer m_Timer;
    ItemUI m_ItemUI;

    // Use this for initialization
    void Start()
    {
        m_Timer = GameObject.Find("Canvas_UI").GetComponent<Timer>();
        //        m_ItemUI = GameObject.Find("Canvas_UI").GetComponent<ItemUI>();
        LoadScene.distance = (int)transform.position.y;
    }


	void OnTriggerEnter2D(Collider2D other)
    {
		Debug.Log ("OnTriggerEnter2D!");
		Debug.Log (other.gameObject.tag);

        //プレイヤーが到着したら
		if (other.gameObject.tag == "Player")
        {
            //プレイヤーが喜ぶとか

            //タイマー止める
            m_Timer.TimerStop();

            LoadScene.time = (int)m_Timer.TotalTime;

            //データ保存 
//            PlayerPrefs.SetInt("ResultTime", (int)m_Timer.TotalTime);
//            PlayerPrefs.SetInt("ResultItem", (int)m_ItemUI.Num);

			gameManager.GetComponent<GameManager> ().MoveToNextScene ();
        }
    }
}


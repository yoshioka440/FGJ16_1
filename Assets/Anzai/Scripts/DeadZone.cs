using UnityEngine;
using System.Collections;

public class DeadZone : MonoBehaviour {

    Timer m_Timer;
    ItemUI m_ItemUI;

    // Use this for initialization
    void Start () {
        m_Timer = GameObject.Find("Canvas_UI").GetComponent<Timer>();
        m_ItemUI = GameObject.Find("Canvas_UI").GetComponent<ItemUI>();
    }

    // Update is called once per frame
    void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        //プレイヤーが落ちたら
        if (other.tag == "Player")
        {
            //止まる
            other.gameObject.SetActive(false);

            //タイマー止める
            m_Timer.TimerStop();

            //データ保存 
            PlayerPrefs.SetInt("ResultTime", 0);
            PlayerPrefs.SetInt("ResultItem", (int)m_ItemUI.Num);
            //ステージネーム入れる
            PlayerPrefs.SetString("StageName", Application.loadedLevelName);

            //シーン遷移
            UnityEngine.SceneManagement.SceneManager.LoadScene("Result");
        }
    }
}

using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

	public float gameTotalTime = 120.0f;

    private float m_TotalTime;
    private bool m_isStop = false;

	/// <summary>
	/// Gets or sets the total time.
	/// </summary>
	/// <value>The total time.</value>
    public float TotalTime
    {
        get { return m_TotalTime; }
        set { m_TotalTime = value; }
    }

    public Image[] m_Image = new Image[3];
    public Sprite[] m_Sprites;

	// Use this for initialization
	void Start () {
		m_TotalTime = gameTotalTime;
        m_Image[0].sprite = m_Sprites[0];
        m_Image[1].sprite = m_Sprites[0];
        m_Image[2].sprite = m_Sprites[0];
    }
	
	// Update is called once per frame
	void Update () {
		if (!m_isStop)
        {
            m_TotalTime -= Time.deltaTime;
        }
        if (m_TotalTime <= 0.0f)
        {
			m_TotalTime = 0.0f;
            TimerStop();
        }

        UI_TimeChange();
    }

    //時間止める
    public void TimerStop()
    {
        m_isStop = true;
		Debug.Log ("Go To GameOver Scene");
		UnityEngine.SceneManagement.SceneManager.LoadScene ("GameOver");
		Debug.Log (UnityEngine.SceneManagement.SceneManager.GetActiveScene().ToString());
    }


    // Imageを切り替える関数
    void UI_TimeChange()
    {
        if (m_TotalTime >= 0.0f)
        {
            int threedigits = (int)(TotalTime * 0.01f) % 10;      //100の位
            int twodigits = (int)(TotalTime * 0.1f) % 10;    //10の位
            int onedigits = (int)TotalTime % 10;            // 1の位

            m_Image[0].sprite = m_Sprites[threedigits];
            m_Image[1].sprite = m_Sprites[twodigits];
            m_Image[2].sprite = m_Sprites[onedigits];
        }
    }
}

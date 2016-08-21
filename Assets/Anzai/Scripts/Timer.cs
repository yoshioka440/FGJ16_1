using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{

	public float gameTotalTime = 120.0f;

	private float m_TotalTime;
	private bool m_isStop = false;

	public bool IsStop {
		get;
		set;
	}

	/// <summary>
	/// Gets or sets the total time.
	/// </summary>
	/// <value>The total time.</value>
	public float TotalTime {
		get { return m_TotalTime; }
		set { m_TotalTime = value; }
	}

	public Image[] m_Image = new Image[3];	// 時間UIImageオブジェクト
	public Sprite[] m_Sprites;				// 画像
	public Text additionalTime;				// 時間の増減の表示用テキスト

	bool isDamaging = false;
	// Use this for initialization
	void Start ()
	{
		m_TotalTime = gameTotalTime;
		m_Image [0].sprite = m_Sprites [0];
		m_Image [1].sprite = m_Sprites [0];
		m_Image [2].sprite = m_Sprites [0];
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (!m_isStop) {
			m_TotalTime -= Time.deltaTime;
		}
		if (m_TotalTime <= 0.0f) {
			m_TotalTime = 0.0f;
			TimerStop ();
		}

		UI_TimeChange ();
	}

	//時間止める
	public void TimerStop ()
	{
		m_isStop = true;
		Debug.Log ("Go To GameOver Scene");
		UnityEngine.SceneManagement.SceneManager.LoadScene ("GameOver");
		Debug.Log (UnityEngine.SceneManagement.SceneManager.GetActiveScene ().ToString ());
	}

	// プレイヤーがダメージ負った時
	public void DecreaseTime ()
	{
		Debug.Log ("被ダメ！");
		isDamaging = true;
		m_TotalTime -= 5.0f;
		additionalTime.enabled = true;
		additionalTime.text = "-5";

		StartCoroutine(showAdditionalTime());
	}

	// 数秒たったら時間増減効果を消す
	IEnumerator showAdditionalTime ()
	{
		yield return new WaitForSeconds (3.0f);
		Debug.Log ("3秒経過！");
		additionalTime.text = "";
		additionalTime.enabled = false;
		isDamaging = false;
	}


	// Imageを切り替える関数
	void UI_TimeChange ()
	{
		if (m_TotalTime >= 0.0f) {
			int threedigits = (int)(TotalTime * 0.01f) % 10;      //100の位
			int twodigits = (int)(TotalTime * 0.1f) % 10;    //10の位
			int onedigits = (int)TotalTime % 10;            // 1の位

			m_Image [0].sprite = m_Sprites [threedigits];
			m_Image [1].sprite = m_Sprites [twodigits];
			m_Image [2].sprite = m_Sprites [onedigits];
		}
	}
}

using UnityEngine;
using System.Collections;

public class PlayerManager : MonoBehaviour {
    public float flyingTime = 2.0f;
    public GameObject pointGroup;

    public bool isLanding { get; private set; }

	public Sprite player;
	public Sprite player_hold;
	public Sprite player_jump_0;
	public Sprite player_jump_1;

    Vector3 prevPosition;
    Vector3 nowPosition;
    Vector3 nextPosition;
    // !!! kunii:スタート位置保持追加
    Vector3 startPosition;
    float jumpTime;

    public int nowPoint;
    // 次の地点の番号（初期位置が0）
    int nextPoint;

    GageManager m_gageManager;
    float m_JumpPower;
    float m_Cooltime;

    //SE
    SoundManager m_SoundManager;

	public Timer timer;

	bool isDamaging = false;
	bool isFail = false;

	public ItemUI itemUI;


    // Use this for initialization
    void Start()
    {
        Initialize();
        m_gageManager = GameObject.Find("GameManager").GetComponent<GageManager>();
        m_SoundManager = GameObject.Find("GameManager").GetComponent<SoundManager>();
    }

    void Initialize()
    {
        isLanding = true;
        jumpTime = 0;
        nowPoint = -1;
        m_JumpPower = 0;
        m_Cooltime = 0;
        prevPosition = this.transform.position;
        nowPosition = this.transform.position;
        nextPosition = pointGroup.transform.GetChild(0).transform.position;
        // !!! kunii:スタート位置保持追加
        startPosition = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (isLanding)
        {
            m_Cooltime = 0.0f;

            if (Input.GetMouseButton(0) || Input.touchCount > 0)
            {
                Debug.Log("Press Left Click");
                isLanding = false;

                if (nowPoint % 2 == 1)
                {
                   this.transform.rotation = Quaternion.Euler(0, 180, 0);
                }
                else
                {
                   this.transform.rotation = Quaternion.Euler(0, 0, 0);
                }

 //               m_gageManager.OnTouchEventGage();
                m_JumpPower = m_gageManager.slider.value;

                nowPosition = transform.position;
				GetComponent<SpriteRenderer> ().sprite = player_jump_1;
            }
        }
        else
        {
            Debug.Log("Jump");
            Jump();

            m_Cooltime += Time.deltaTime;

            if (m_Cooltime >= 0.5f)
            {
                if (this.transform.position == nextPosition)
                {
                    // !!! kunii:NEXT位置の設定は補正なし
                    nowPoint++;
                    isLanding = true;
                    jumpTime = 0;

                    nextPosition = pointGroup.transform.GetChild(nowPoint + 1).transform.position;
					if (nowPoint != 0) {
						prevPosition = pointGroup.transform.GetChild (nowPoint - 1).transform.position;
					}
					nowPosition = transform.position;
                    GetComponent<SpriteRenderer>().sprite = player_jump_1;

					// ポイントの取得
					if (nowPoint != (pointGroup.transform.childCount - 1)) {
						if (pointGroup.transform.GetChild (nowPoint).GetComponent<SpriteRenderer> ().sprite != null) {
							pointGroup.transform.GetChild (nowPoint).GetComponent<SpriteRenderer> ().sprite = null;
							itemUI.AddItem ();
							m_SoundManager.SoundRings (2);
						}
					}
                }
                else if (this.transform.position == prevPosition)
                {
                    nowPoint--;
                    isLanding = true;
                    jumpTime = 0;

                    // !!! kunii:PREV位置の設定は補正あり（pointGroupの配列境界対策）
                    // !!! kunii:配列のオーバーロード対策
                    if (nowPoint > 0)
                    {
                        nextPosition = pointGroup.transform.GetChild(nowPoint + 1).transform.position;
                    }
                    else
                    {
                        nowPoint = 0;
                    }

                    if (nowPoint > 1)
                    {
                        prevPosition = pointGroup.transform.GetChild(nowPoint - 1).transform.position;
                    }
                    else
                    {
                        // !!! kunii:スタート位置へ戻す
                        prevPosition = startPosition;
                    }

                    nowPosition = transform.position;
                }
                GetComponent<SpriteRenderer>().sprite = player_hold;

                // !!! kunii:位置配列インデックス確認用
                //Debug.Log("Jump Count : " + nowPoint);
//                m_SoundManager.SoundRings(0);

            }
        }
    }

    void Jump()
    {
        //		nextPosition = new Vector3 (0, 5, 0);
        //		nextPosition = pointTransform.position;

        jumpTime += Time.deltaTime;

        if (m_JumpPower >= 0.7f)
        {
            this.transform.position = Vector3.Lerp(this.transform.position, nextPosition, jumpTime / flyingTime);
        }
        else if (m_JumpPower <= 0.2f)
        {
            //this.transform.position = Vector3.Lerp(this.transform.position, nextPosition, jumpTime / flyingTime);
            // !!! kunii:パワー足らずは前回箇所に戻す
            this.transform.position = Vector3.Lerp(this.transform.position, prevPosition, jumpTime / flyingTime);
//			isFail = true;
//			if (isFail) {
//				m_SoundManager.SoundRings (3);
//			}
        }
        else
        {
            this.transform.position = Vector3.Lerp(this.transform.position, prevPosition, jumpTime / flyingTime);
        }
    }

	/// <summary>
	/// Raises the trigger enter2 d event.
	/// </summary>
	/// <param name="col">Col.</param>
	void OnTriggerEnter2D (Collider2D col) {
		Debug.Log (col.gameObject.name);

		if (col.gameObject.name == "Bird" && isDamaging == false) {
			Debug.Log ("鳥と衝突！");
			isDamaging = true;
			// 音がなる
			m_SoundManager.SoundRings(0);
			// 被ダメ演出
			StartCoroutine(Dameged ());
			// 時間減少
			timer.DecreaseTime ();

			StartCoroutine (TimeElapsed ());
		}
	}

	IEnumerator Dameged ()
	{
		GetComponent<SpriteRenderer> ().enabled = false;
		yield return new WaitForSeconds (0.1f);
		GetComponent<SpriteRenderer> ().enabled = true;
		yield return new WaitForSeconds (0.1f);
		GetComponent<SpriteRenderer> ().enabled = false;
		yield return new WaitForSeconds (0.1f);
		GetComponent<SpriteRenderer> ().enabled = true;
		yield return new WaitForSeconds (0.1f);
		GetComponent<SpriteRenderer> ().enabled = false;
		yield return new WaitForSeconds (0.1f);
		GetComponent<SpriteRenderer> ().enabled = true;
		yield return new WaitForSeconds (0.1f);
		GetComponent<SpriteRenderer> ().enabled = false;
		yield return new WaitForSeconds (0.1f);
		GetComponent<SpriteRenderer> ().enabled = true;
	}

	IEnumerator TimeElapsed ()
	{
		yield return new WaitForSeconds (3.0f);
		isDamaging = false;
	}

}

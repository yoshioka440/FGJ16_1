using UnityEngine;
using System.Collections;

public class PlayerManager : MonoBehaviour {
    public float flyingTime = 2.0f;
    public GameObject pointGroup;

    bool isLanding;
    Vector3 prevPosition;
    Vector3 nowPosition;
    Vector3 nextPosition;
    float jumpTime;

    public int nowPoint;
    // 次の地点の番号（初期位置が0）
    int nextPoint;

    GageManager m_gageManager;
    float m_JumpPower;
    float m_Cooltime;

    // Use this for initialization
    void Start()
    {
        Initialize();
        m_gageManager = GameObject.Find("GameManager").GetComponent<GageManager>();
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

                m_gageManager.OnTouchEventGage();
                m_JumpPower = m_gageManager.slider.value;

                nowPosition = transform.position;
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
                    nowPoint++;
                    isLanding = true;
                    jumpTime = 0;

                    // !!! kunii:配列のオーバーロード対策
                    if (nowPoint > 0)
                    {
                        nextPosition = pointGroup.transform.GetChild(nowPoint + 1).transform.position;
                        prevPosition = pointGroup.transform.GetChild(nowPoint - 1).transform.position;
                    }

                    nowPosition = transform.position;

                }
                else if (this.transform.position == prevPosition)
                {
                    if(nowPoint == 0)
                    {
                        return;
                    }
                    nowPoint--;
                    isLanding = true;
                    jumpTime = 0;

                    // !!! kunii:配列のオーバーロード対策
                    if (nowPoint > 0)
                    {
                        nextPosition = pointGroup.transform.GetChild(nowPoint + 1).transform.position;
                        prevPosition = pointGroup.transform.GetChild(nowPoint - 1).transform.position;
                    }
                    nowPosition = transform.position;

                }
            }
        }
    }

    void Jump()
    {
        //		nextPosition = new Vector3 (0, 5, 0);
        //		nextPosition = pointTransform.position;

        jumpTime += Time.deltaTime;

        if (m_JumpPower >= 0.8f)
        {
            this.transform.position = Vector3.Lerp(this.transform.position, nextPosition, jumpTime / flyingTime);
        }
        else if (m_JumpPower <= 0.2f)
        {
            this.transform.position = Vector3.Lerp(this.transform.position, nextPosition / 2, jumpTime / flyingTime);
        }
        else
        {
            this.transform.position = Vector3.Lerp(this.transform.position, prevPosition, jumpTime / flyingTime);
        }
    }

}

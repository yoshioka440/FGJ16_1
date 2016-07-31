using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TimeDown : MonoBehaviour {

    float m_LimitTime;
    const float setTime = 4.0f;
    Image m_Image;

    PlayerManager m_PlayerManager;

    public Sprite[] m_Sprites;

	// Use this for initialization
	void Start () {

        m_Image = GetComponent<Image>();
        m_LimitTime = setTime;
        m_PlayerManager = GameObject.Find("Player").GetComponent<PlayerManager>();
	}
	
	// Update is called once per frame
	void Update () {

        if (m_PlayerManager.isLanding)
        {
            m_LimitTime -= Time.deltaTime;

            if(m_LimitTime <= 0)
            {
                //耐えられなくて落ちる処理
              //  transform.root.gameObject.AddComponent<Rigidbody2D>();
            }

           m_Image.sprite = m_Sprites[(int)m_LimitTime];
        }
       else
        {
            m_LimitTime = setTime;
        }

	}
}

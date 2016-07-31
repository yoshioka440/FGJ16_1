using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ResultScore : MonoBehaviour {

    private static int m_Score = 0;

    public Image[] m_Images = new Image[6];
    public Sprite[] m_Sprites;

    public int Score
    {
        get { return m_Score; }
        set { m_Score = value; }
    }

	// Use this for initialization
	void Start () {
        int ResultTime = LoadScene.time;
        int Distance = LoadScene.distance;

        int threedigits = (int)(ResultTime * 0.01f) % 10;      //100の位
        int twodigits = (int)(ResultTime * 0.1f) % 10;    //10の位
        int onedigits = (int)ResultTime % 10;            // 1の位

        m_Images[0].sprite = m_Sprites[threedigits];
        m_Images[1].sprite = m_Sprites[twodigits];
        m_Images[2].sprite = m_Sprites[onedigits];

        threedigits = (int)(Distance * 0.01f) % 10;      //100の位
        twodigits = (int)(Distance * 0.1f) % 10;    //10の位
        onedigits = (int)Distance % 10;            // 1の位

        m_Images[3].sprite = m_Sprites[threedigits];
        m_Images[4].sprite = m_Sprites[twodigits];
        m_Images[5].sprite = m_Sprites[onedigits];

    }

}

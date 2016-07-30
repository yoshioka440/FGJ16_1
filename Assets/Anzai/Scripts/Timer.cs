using UnityEngine;
using System.Collections;

public class Timer : MonoBehaviour {

    private int m_TotalTime = 0;

    public int TotalTime
    {
        get { return m_TotalTime; }
        set { m_TotalTime = value; }
    }

    public Sprite[] m_Sprites;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        m_TotalTime += (int)Time.deltaTime;

    }
}

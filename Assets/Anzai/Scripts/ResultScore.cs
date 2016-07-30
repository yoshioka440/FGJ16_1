using UnityEngine;
using System.Collections;

public class ResultScore : MonoBehaviour {

    private static int m_Score = 0;

    public int Score
    {
        get { return m_Score; }
        set { m_Score = value; }
    }

	// Use this for initialization
	void Start () {
        int ResultTime = PlayerPrefs.GetInt("ResultTime");
        int ResultItem = PlayerPrefs.GetInt("ResultItem");

        int timeScore = ResultTime * 10;
        int itemScore = ResultItem * 100;
        m_Score = timeScore + itemScore;

	}
	
	// Update is called once per frame
	void Update () {
	    
	}

}

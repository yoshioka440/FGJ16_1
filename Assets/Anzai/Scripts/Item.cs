using UnityEngine;
using System.Collections;

public class Item : MonoBehaviour {

    private int m_ItemNum = 0;

    public int Num
    {
        get { return m_ItemNum; }
        set { m_ItemNum = value; }
    }


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    private void AddItem()
    {
        m_ItemNum++;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            //ゲット
            AddItem();

            //あたり判定消す
            GetComponent<Collider2D>().enabled = false;

            Destroy(this.gameObject, 2.0f);
            //アイテムゲットした時の音 とか エフェクト
        }
    }

}

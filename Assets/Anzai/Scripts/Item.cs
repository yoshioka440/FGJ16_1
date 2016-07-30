using UnityEngine;
using System.Collections;

public class Item : MonoBehaviour {

    ItemUI m_ItemUI;

	// Use this for initialization
	void Start () {
        m_ItemUI = GameObject.Find("Canvas_UI").GetComponent<ItemUI>();

    }
	
	// Update is called once per frame
	void Update () {
	    
	}


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            //ゲット
            m_ItemUI.AddItem();

            //あたり判定消す
            GetComponent<Collider2D>().enabled = false;

            Destroy(this.gameObject, 2.0f);
            //アイテムゲットした時の音 とか エフェクト
        }
    }

}

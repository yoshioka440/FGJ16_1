using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ItemUI : MonoBehaviour {

    private int m_ItemNum = 0;

    public Image m_Image;
    public Sprite[] m_Sprites;

    void Start()
    {
        m_Image.sprite = m_Sprites[0];
    }

	/// <summary>
	/// アイテムの数値を取得する
	/// </summary>
	/// <value>The number.</value>
    public int Num
    {
        get { return m_ItemNum; }
        set { m_ItemNum = value; }
    }

	/// <summary>
	/// Itemから呼ぶ
	/// </summary>
    public void AddItem()
    {
        m_ItemNum++;
        m_Image.sprite = m_Sprites[m_ItemNum];
    }
}

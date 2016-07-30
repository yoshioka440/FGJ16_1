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

    public int Num
    {
        get { return m_ItemNum; }
        set { m_ItemNum = value; }
    }

    public void AddItem()
    {
        m_ItemNum++;
        m_Image.sprite = m_Sprites[m_ItemNum];
    }
}

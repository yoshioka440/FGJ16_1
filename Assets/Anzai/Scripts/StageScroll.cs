using UnityEngine;
using System.Collections;

public class StageScroll : MonoBehaviour {

    int count;
    public int endNum;
    public GameObject player;
    public GameObject prefab;

    // Use this for initialization
    void Start()
    {
        count = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if ((int)player.transform.position.y / 10 == count)
        {
            var Parent = GameObject.Find("StageGroup").transform;
            int num = Parent.GetChildCount();
            var Obj = Instantiate(prefab, Parent.transform.GetChild(num - 1).
                transform.position + new Vector3(0, 11.0f, 0) ,
                Quaternion.identity) as GameObject;
            count++;
            Obj.transform.parent = Parent;
        }
    }
}

using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour {

    public string nextSceneName;

    public void StageRetry()
    {
        SceneManager.LoadScene("Main");
    }

    public void StageNext()
    {
        SceneManager.LoadScene("Main");

    }


    //public void StageNext()
    //{
    //    //前回のシーンを取得
    //    var StageName = PlayerPrefs.GetString("StageName");

    //    var len = StageName.Length;
    //    //次のステージナンバー取得 Char->int 
    //    int beforeNum = int.Parse(StageName[len-1].ToString());
    //    int nextNum = beforeNum + 1;
    //    //最後の文字を削除
    //    StageName = StageName.Remove(len-1, 1);

    //    var str = StageName + nextNum.ToString();
    //    Debug.Log(str);


    //    if (ContainsScene(str)) {
    //        SceneManager.LoadScene(str);
    //    }
    //    else
    //    {
    //        Debug.Log("ok");
    //        SceneManager.LoadScene("Test1");
    //    }

    //}
    public void SceneChange()
    {
        SceneManager.LoadScene(nextSceneName);
    }

    //http://polaris-bear.lolipop.jp/shunroom/461
    bool ContainsScene(string sceneName)
    {
        Debug.Log(SceneManager.sceneCount);
        for (int i = 0; i < SceneManager.sceneCount; i++)
        {
            if (SceneManager.GetSceneAt(i).name == sceneName)
            {
                return true;
            }
        }
        return false;
    }
}

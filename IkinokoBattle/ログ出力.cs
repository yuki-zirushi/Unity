using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var test = "TEST!!";
        Debug.Log(test); //test変数をログに出力
        Debug.Log(test.Length); //test変数の長さを出力

        test = null;
        Debug.Log(test.Length); //空っぽなのでエラーが発生(NullReferenceException)
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

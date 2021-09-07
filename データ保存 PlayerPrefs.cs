using UnityEngine;

public class PlayerPrefsTest : MonoBehaviour
{
  //PlayerPrefsのデータ読み書きに使うキーは、タイプミスを避けるために定数などで宣言しておいた方がいい
  private const string TestKey = "TEST";
  private void Start()
  {
    //保存するデータ
    var testData = "This is Test!!";

    //Stringをセット
    PlayerPrefs.SetString(TestKey, testData);

    //保存
    PlayerPrefs.Save();

    //保存したStringの読み込み
    //一度保存した後は、保存処理をコメントアウトしても「This is Test!!」が読み込める
    var savedData = PlayerPrefs.GetString(TestKey);
    Debug.Log(savedData);
  }
}
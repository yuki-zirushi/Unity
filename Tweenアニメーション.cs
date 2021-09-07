using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverTextAnimator : MonoBehaviour
{
  private void Start()
  {
    var transformCache = transform;
    //終点として使用するため、初期座標を保持
    var defaultPosition = transformCache.localPosition;
    //一旦上の方に移動させる
    transformCache.localPosition = new Vector3(0, 300f);
    //移動アニメーションを開始
    transformCache.DOLocalMove(defaultPosition, 1f).SetEase(Ease.Liner).OnComplete(() =>
      {
        Debug.Log("GAME OVER!!");
        //シェイクアニメーション
        transformCache.DOShakePosition(1.5f, 100);
      });

    //DOTweenには、Coroutineを使わずに任意の秒数を持てる便利メソッドあり
    DOVirtual.DelayedCall(10, () =>
      {
        //10秒待ってからタイトルシーンに遷移
        SceneManager.LoadScene("TitleScene");
      });
   }
}
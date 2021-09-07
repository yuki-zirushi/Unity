using DG.Tweening;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class Item : MonoBehaviour
{
  //アイテムの種類定義
  public enum ItemType
  {
    Wood, //木
    Stone, //石
    ThrowAxe //投げオノ(木と石で作る！)
  }

  [SerializeField] private ItemType type;

  //初期化処理
  public void Initialize()
  {
    //アニメーションが終わるまでcolliderを無効
    var colliderCache = GetComponent<Collider>();
    colliderCache.enabled = false;
    //出現アニメーション
    var transformCache = transform;
    var dropPosition = transform.localPosition + new Vector3(Random.Range(-1f, 1f), 0, Random.Range(=1f, 1f));
    transformCache.DOLocalMove(dropPosition, 0.5f);
    var defaultScale = transformCache.localScale;
    transformCache.localScale = Vector3.zero;
    transformCache.DOScale(defaultScale, 0.5f).SetEase(Ease.OutBounce).OnComplete(() =>
    {
      //アニメーションが終わったらcolliderを有効に
      colliderCache.enabled = true;
    });
  }

  private void OnTriggerEnter(Collider other)
  {
    if (!other.CompareTag("Player")) return;

    //TODO プレイヤーの所持品として追加

    //オブジェクトの破棄
    Destroy(gameObject);
  }
}
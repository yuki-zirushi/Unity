using UnityEngine;
using UnityEngine.UI;

public class LifeGauge : MonoBehaviour
{
  [SerializeField] private Image fillImage;

  private RectTransform _parentRectTransform;
  private Camera _camera;
  private MobStatus _status;

  private void Update()
  {
    Refresh();
  }

  //ゲージを初期化する
  public void Initialize(RectTransform parentRectTransform, Camera camera, MobStatus status)
  {
    //座標の計算に使うパラメーターを受け取り、保持しておく
    _parentRectTransform = parentRectTransform;
    _camera = camera;
    _status = status;
    Refresh();
  }

  //ゲージを更新します
  private void Refresh()
  {
    fillImage.fillAmount = _status.Life / _status.LifeMax;
    //対象Mobの場所にゲージを移動
    //World座標やLocal座標を変換するときはRectTransformUtilityを使う
    var screenPoint = _camera.WorldToScreenPoint(_status.transform.position);
    Vector2 localPoint;
    //今回はCanvasのRender ModeがScreen Space - Overlayなので第三引数にnullを指定している。
    //Screen Space - Cameraの場合は、対象のカメラを渡す必要がある
    RectTransformUtility.ScreenPointToLocalPointInRectangle(_parentRectTransform, screenPoint, null, out localPoint);
    transform.localPosition = localPoint + new Vector2(0, 80);
    //ゲージが重なるので少し上にずらしている
  }
}
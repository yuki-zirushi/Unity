private void Start() {
  Debug.Log(Input.touchSupported ? "タッチに対応しています" : "タッチに対応していません");
}

private void Update() {
  Debug.Log(string.Format("現在のタッチ数は {0} です", Input.touchCount));
}

private void Update() {
  foreach (var touch in Input.touches)
  {
    switch (touch.phase)
    {
      case TouchPhase.Began:
        Debug.Log(string.Format("指ID: {0} タッチ開始 座標: {1}",
        touch.fingerId, touch.position));
        break;
      case TouchPhase.Canceled:
        Debug.Log(string.Format("指ID: {0} タッチキャンセル 座標: {1}",
        touch.fingerId, touch.position));
        break;
      case TouchPhase.Ended:
        Debug.Log(string.Format("指ID: {0} タッチ終了 座標: {1}",
        touch.fingerId, touch.position));
        break;
      case TouchPhase.Moved:
        Debug.Log(string.Format("指ID: {0} タッチ移動 座標: {1} 1フレームでの移動距離: {2}",
        touch.fingerId, touch.position, touch.deltaPosition));
        break;
      case TouchPhase.Stationary:
        Debug.Log(string.Format("指ID: {0} タッチホールド(移動なし) 座標: {1}",
        touch.fingerId, touch.position));
        break;
      default:
        throw new ArgumentOutOfRangeException();
    }
  }
}
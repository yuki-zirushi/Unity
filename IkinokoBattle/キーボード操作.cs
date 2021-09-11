//左シフトキーが押されている状態で、スペースキーを押した瞬間を判定する

private void Update() {
  if (Input.GetKey(KeyCode.LeftShift) && Input.GetKeyDown(KeyCode.Space)) {
    Debug.Log("Shift+Spaceを押しました！");
  }
}
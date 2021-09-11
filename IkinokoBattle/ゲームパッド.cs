//アナログスティック
private void Update() {
  Debug.Log(string.Format("Axisを取得 ({0}, {1})",
    Input.GetAxis("Horizontal"),
    Input.GetAxis("Vertical")
    ));
}

//ボタン
private void Update() {
  if (Input.GetButtonDown("Jump"))
  {
    Debug.Log("Jumpボタンが押されたよ!");
  }
}
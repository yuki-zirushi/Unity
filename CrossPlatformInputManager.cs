using UnityStandardAssets.CrossPlatformInput;

private void Update() {
  if (Input.GetButtonDown("Jump"))
  {
    Debug.Log("Jumpボタンが押されたよ!");
  }
}
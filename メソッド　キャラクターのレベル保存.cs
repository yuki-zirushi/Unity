public void SaveLevel(int level) {
  /*
  アクセス修飾子　戻り値の型　メソッド名(引数)
  voidは戻り値なし
  */
  if (level < 1 || 99 < level) {
    throw new Exception("レベルは1~99で指定してください");
  }

  PlayerPref.SetInt("level", level);
  // levelの値をPlayerPrefにセット
  PlayerPref.Save();
  Debug.Log("レベルを保存しました！");
}
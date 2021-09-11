//if else

var hp = 10;
if (hp < 10) {
  Debug.Log("あぶない！HPが無くなりそうだよ！");
} else if (hp < 30) {
  Debug.Log("HPが減ってきたよ");
} else {
  Debug.Log("HPはまだたくさんあるよ");
}

//for

for (var i = 0; i < 10; i++) {
  Debug.Log(i);
}

for (var i = 0; i < 10; i++) {
  if (i == 5) break;
  Debug.Log(i);
}

//foreach

var values = new int[] {1, 10, 100, 1000};
foreach (var value in values) {
  Debug.Log(value);
  //1, 10, 100, 1000が順に出力される
}

//while

var value = 0;
while (value < 90) {
  value = Random.Range(0, 100);
  //0~99にランダムな数値を生成
  Debug.Log(value);
}

//switch

var value = 1;
switch (value) {
  case 1:
    Debug.Log("おはよう");
    break;
  case 2:
    Debug.Log("こんにちは");
    break;
  case 3:
    Debug.Log("こんばんは");
    break;
  default:
    Debug.Log("うっひょー！！");
    break;
}
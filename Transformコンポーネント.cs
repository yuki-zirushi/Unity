transform.position = new Vector(1, 2, 3); //ワールド座標を直接変更
transform.localPosition = new Vector(1, 2, 3); //ローカル座標を直接変更
transform.Rotate(new Vector3(0, 0, 10)); //Z軸に対して10度回転させる
transform.localScale *= 3; //大きさを3倍にする

/*
ワールド座標 : シーンの中でゲームオブジェクトがどこにあるか
ローカル座標 : 親ゲームオブジェクトの中で子ゲームオブジェクトがどこにあるか
*/
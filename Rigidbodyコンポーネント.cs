var rigidbody = GetComponent<Rigidbody>();
rigidbody.MovePosition(new Vector3(1, 2, 3)); //任意の座標に瞬間移動させる
rigidbody.AddForce(transform.forward * 100); //任意の方向に力を加える
rigidbody.velocity = new Vector(10, 0, 0); //移動速度を変更
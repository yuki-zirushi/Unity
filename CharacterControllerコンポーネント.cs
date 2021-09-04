var characterController = GetComponent<CharacterController>();
characterController.Move(new Vector(1, 2, 3));
//キャラクターを引数で指定した方向に移動させる(重力なし)
characterController.SimpleMove(new Vector(1, 2, 3));
//(空中にいる場合は引数が無視され、代わりにキャラクターに対して重力がかかる)
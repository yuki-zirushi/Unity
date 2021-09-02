//車クラス
public class Car {
  //フィールド(インスタンス変数)
  public string Tire = "良いタイヤ";
  private string _owner;

　//コンストラクタ(インスタンス化の際、最初に呼ばれる)
  public Car(string owner) {
    _owner = owner;
    Debug.Log(string.Format("新しい車ができたよ！オーナー:{0}さん", _owner));
  }

  public void Run() {
    Debug.Log("走るよ！");
  }
}

var car = new Car("田中"); //インスタンス化
Debug.Log(car.Tire); //フィールドの読み取り
car.Run(); //メソッドの実行
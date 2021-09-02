abstract public class Car {
//継承専用クラス

  public virtual void Run() {
  //メソッドでvirtualをつけると、子クラスでオーバーライド可能になる
    Debug.Log("走るよ！");
  }

  public void Stop() {
    Debug.Log("止まるよ！");
  }
}

public class SportCar : Car {
//Carクラスを継承
  public override void Run() {
  //Runメソッドをオーバーライド
    Debug.Log("超早く");
    base.Run();
    //親クラスのメソッドを実行
  }
}

var sportCar = new SportCar();
sportCar.Run(); //「超早く」「走るよ！」と出力
sportCar.Stop(); //「止まるよ！」と出力

/*
abstractをつけるとクラス・メソッドの抽象化ができる
抽象クラス自体はインスタンス化できない
継承専用させたくない場合はsealed
*/
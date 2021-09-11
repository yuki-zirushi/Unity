public class Car {
//アウタークラス
  private Engine　_engine;

  public Car() {
    _engine = new Engine();
  }

  private class Engine {
  //インナークラス
    private Engine() {
      Debug.Log("エンジンを作ったよ！");
    }
  }
}

var car = new Car();
//「エンジンを作ったよ！」と表示される
var engine = new Car.Engine();
//Engineクラスは隠蔽されているので外部から直接呼び出そうとするとエラーになる
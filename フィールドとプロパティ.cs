public class Character {

  //キャラクターのレベルを格納するフィールド
  //privateで外から見えなくする
  private int _characterLevel:

　//外部から_characterLevelにアクセスできるようにするプロパティ
  public int CharacterLevel {
    get {
      return_characterLevel;
    }
    //レベルを1~99にセットする
    set {
      _characterLevel = Mathf.Clamp(value, 1, 99);
    }
  }
}
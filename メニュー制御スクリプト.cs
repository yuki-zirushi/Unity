using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
  [SerializeField] private Button pauseButton;
  [SerializeField] private GameObject pausePanel;
  [SerializeField] private Button resumeButton;

  [SerializeField] private Button itemsButton;
  [SerializeField] private Button recipeButton;

  private void Start()
  {
    pausePanel.SetActive(false); //ポーズのパネルは初期状態では非表示にしておく

    pauseButton.onClick.AddListener(Pause);
    resumeButton.onClick.AddListener(Resume);
    itemsButton.onClick.AddListener(ToggleItemsDialog);
    recipeButton.onClick.AddListener(ToggleRecipeDialog);
  }

  //ゲームを一時停止する
  private void Pause()
  {
    Time.timeScale = 0; //0だと時間が停止する
    pausePanel.SetActive(true);
  }

  //ゲームを再開する
  private void Resume()
  {
    Time.timeScale = 1; //また時間が流れるようにする
    pausePanel.SetActive(false);
  }

  //アイテムウィンドウを開閉
  private void ToggleItemsDialog()
  {
    //TODO 後で実装
  }

  //レシピウィンドウを開閉
  private void ToggleRecipeDialog()
  {
    //TODO 後で実装
  }
}
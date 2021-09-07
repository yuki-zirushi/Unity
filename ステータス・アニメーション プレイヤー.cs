using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerStatus : MobStatus
{
  protected override void OnDie()
  {
    base.OnDie();
    //プレイヤーが倒れたときのゲームオーバー処理
    StartCoroutine(GoToGameOverCoroutine());
  }

  private IEnumerator GoToGameOverCoroutine()
  {
    yield return new WaitForSeconds(3);
    SceneManager.LoadScene("GameOverScene");
  }
}
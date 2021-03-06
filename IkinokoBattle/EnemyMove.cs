using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(EnemyStatus))]
public class EnemyMove : MonoBehaviour
{
  private NavMeshAgent _agent;
  private RaycastHit[] _raycastHits = new RaycastHit[10];
  private EnemyStatus _status;

  private void Start()
  {
    _agent = GetComponent<NavMeshAgent>(); //NavMeshAgentを保持しておく
    _status = GetComponent<EnemyStatus>();
  }

  //CollisionDetectorのonTriggerStayにセットし、衝突判定を受け取るメソッド
  public void OnDetectObject(Collider collider)
  {
    if (!_status.IsMovable)
      {
        _agent.isStopped = true;
        return;
      }

    //検知したオブジェクトに「Player」のタグがついていれば、そのオブジェクトを追いかける
    if (collider.CompareTag("Player"))
    {
      //自信とプレイヤーの座標差分を計算
      var positionDiff = collider.transform.position - transform.position;
      //プレイヤーとの距離を計算
      var distance = positionDiff.magnitude;
      //プレイヤーへの方向
      var direction = positionDiff.normalized;

      //_raycastHitsに、ヒットしたColliderや座標情報などが格納される
      var hitCount = Physics.RaycastNonAlloc(transform.position, direction, _raycastHits, distance);
      Debug.Log("hitCount: " + hitCount);
      if (hitCount == 0)
      {
        _agent.isStopped = false;
        _agent.destination = collider.transform.position;
      }
      else
      {
        //見失ったら停止する
        _agent.isStopped = true;
      }
    }
  }
}
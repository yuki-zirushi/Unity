using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class EnemyMove : MonoBehaviour
{
  [SerializeField] private PlayerController playerController;
  private NavMeshAgent _agent;

  private void Start()
  {
    _agent = GetComponent<NavMeshAgent>(); //NavMeshAgentを保持しておく
  }

  private void Update()
  {
    _agent.destination = playerController.transform.position;
  }
}
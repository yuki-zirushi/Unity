using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
  [SerializeField] private float moveSpeed = 3; //移動速度
  [SerializeField] private float jumpPower = 3; //ジャンプ力
  private CharacterController _characterController;
  //CharacterControllerのキャッシュ

  private Transform _transform; //Transformのキャッシュ
  private Vector3 _moveVelocity; //キャラクターの移動速度情報

  private bool IsGrounded
  {
    get
    {
      var ray = new Ray(_transform.position + new Vector3(0, 0.1f), Vector3.down);
      var raycastHits = new RaycastHit[1];
      var hitCount = Physics.RaycastNonAlloc(ray, raycastHits, 0.2f);
      return hitCount >= 1;
    }
  }

  private void Start()
  {
    _characterController = GetComponent<CharacterController>();
    //毎フレームアクセスするので、負荷を下げるためにキャッシュしておく
    _transform = transform;
    //transformもキャッシュしておくと少しだけ負荷が下がる
  }

  private void Update()
  {
    Debug.Log(IsGrounded ? "地上にいます" : "空中です");

    _moveVelocity.x = CrossPlatformInputManager.GetAxis("Horizontal") * moveSpeed;
    _moveVelocity.z = CrossPlatformInputManager.GetAxis("Vertical") * moveSpeed;

    //移動方向に向く
    _transform.LookAt(_transform.position + new Vector3(_moveVelocity.x, 0, _moveVelocity.z));

    if (IsGrounded)
    {
      if (Input.GetButtonDown("Jump"))
      {

        //ジャンプ処理
        Debug.Log("ジャンプ!");
        _moveVelocity.y = jumpPower; //ジャンプの際は上方向に移動させる
      }
    }
    else
    {
      //重力による加速
      _moveVelocity.y += Physics.gravity.y * Time.deltaTime;
    }

    //オブジェクトを動かす
    _characterController.Move(_moveVelocity * Time.deltaTime);
  }
}
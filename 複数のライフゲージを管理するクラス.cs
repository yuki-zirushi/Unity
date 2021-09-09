using System;
using System.Collections.Generic;
using UnityEngine;

[RequierComponent(typeof(RectTransform))]
public class LifeGaugeContainer : MonoBehaviour
{
  public static LifeGaugeContainer Instance
  {
    get { return _instance; }
  }

  private static LifeGaugeContainer _instance;

  [SerializeField] private Camera mainCamera;
  //ライフゲージ表示対象のMobを映しているカメラ
  [SerializeField] private LifeGauge lifGaugePrefab; //ライフゲージのPrefab

  private RectTransform rectTransform;
  //アクティブなライフゲージを保持するコンテナ
  private readonly Dictionary<MobStatus, LifeGauge> _statusLifeBarMap = new Dictionary<MobStatus, LifeGauge>();

  private void Awake()
  {
    //シーン上に1つしか存在させないスクリプトのため、このような疑似シングルトンが成り立つ
    if (null != _instance) throw new Exception("LifeBarContainer instance already exists.");
    _instance = this;
    rectTransform = GetComponent<RectTransform>();
  }

  //ライフゲージを追加
  public void Add(MobStatus status)
  {
    var lifeGauge = Instantiate(lifeGaugePrefab, transform);
    lifeGauge.Initialize(rectTransform, mainCamera, status);
    _statusLifeBarMap.Add(status, lifeGauge);
  }

  //ライフゲージを破棄する
  public void Remove(MobStatus status)
  {
    Destroy(_statusLifeBarMap[status].gameObject);
    _statusLifeBarMap.Remove(status);
  }
}
using System;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
  private static AudioManager instance;
  [SerializeField] private AudioSource _audioSource;
  private readonly Dictionary<string, AudioClip> _clips = new Dictionary<string, AudioClip>();

  public static AudioManager instance
  {
    get { return instance; }
  }

  private void Awake()
  {
    if (null != instance)
    {
      //すでにインスタンスがある場合は自身を破棄する
      Destroy(gameObject);
      return;
    }

    //シーンを遷移しても破棄されなくなる
    DontDestroyOnLoad(gameObject);
    //インスタンスとして保持
    instance = this;

    //Resource/2D_SEディレクトリ下のAudio Clipをすべて取得
    var audioClips = Resources.LoadAll<AudioClip>("2D_SE");
    foreach (var clip in audioClips)
    {
      //Audio ClipをDictionaryに保持しておく
      _clips.Add(clip.name, clip)
    }
  }

  public void Play(string clipName)
  {
    if (!_clips.ContainKey(clipName))
    {
      保持しない名前を指定したらエラー
      throw new Excpetion("Sound" + clipName + "is not defined");
    }

    //指定の名前のclipに差し替えて再生
    _audioSource.clip = _clips[clipName];
    _audioSource.Play();
  }
}
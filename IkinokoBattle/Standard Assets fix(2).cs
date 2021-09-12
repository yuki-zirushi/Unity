SimpleActivatorMenu.cs

using System;
using UnityEngine;
using UnityEngine.UI; //この行を追加

namespace UnityStandardAssets.Utility
{
  public class SimpleActivatorMenu : MonoBehaviour
  {
    // An incredibly simple menu which, when given references
    // to gameobjects in the scene
    public Text camSwitchButton; 「GUIText」を「Text」に変更
    public GameObject[] objects;
  }
}
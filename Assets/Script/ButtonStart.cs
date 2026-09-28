using NUnit.Framework;
using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using JetBrains.Annotations;
public class ButtonStart : MonoBehaviour
{
  public CameraMover cameraMover;
    public Animator mainmenuAnimator;
   
    public void Play()
    {
        cameraMover.isAtTarget = true;
        mainmenuAnimator.SetBool("playTrigger", true);
    }

    public void Quit()
    {
        Application.Quit();
    }
  

   
}

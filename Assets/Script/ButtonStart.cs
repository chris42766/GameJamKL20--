using NUnit.Framework;
using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using JetBrains.Annotations;
public class ButtonStart : MonoBehaviour
{
  public CameraMover cameraMover;
    public Animator mainmenuAnimator;
    public AudioManager audioMainMenu;
    public AudioSource buttonSound;
   
    public void Play()
    {
        buttonSound.Play();
        audioMainMenu.MainMenuAudio.Stop();
        audioMainMenu.CalmAudio.Play();
        cameraMover.isAtTarget = true;
        mainmenuAnimator.SetBool("playTrigger", true);
    }

    public void Quit()
    {
        buttonSound.Play();
        Application.Quit();
    }
  

   
}

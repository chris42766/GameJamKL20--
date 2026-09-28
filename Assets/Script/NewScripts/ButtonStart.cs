using NUnit.Framework;
using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using JetBrains.Annotations;
public class ButtonStart : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
  public CameraMover cameraMover;

   
    public void OnPointerDown(PointerEventData eventData)
    {

    }

    public void OnPointerUp(PointerEventData eventData)
    {


    }

    public void OnPointerClick(PointerEventData eventData)
    {
        cameraMover.isAtTarget = true;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
     
    }
    public void OnPointerExit(PointerEventData eventData)
    {
       
    }


  

   
}

using System.Drawing;
using UnityEngine;
using UnityEngine.EventSystems;

public class CardInteraction : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{

    private Vector3 mOffset;
    private float mZCoord;
    public bool cardDrag = false;
    bool shrinkSize = false;
    bool isLocked = false;
   // bool shrinkSize = false;
    void Update()
    {

   
        //Debug.Log(cardDrag);
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void OnPointerDown(PointerEventData eventData)
    {
      //  transform.position= eventData.position;
    }

    public void OnPointerUp(PointerEventData eventData)
    {


    }

    public void OnPointerClick(PointerEventData eventData)
    {
       
        
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        //ebug.Log("Holey");
    }
    public void OnPointerExit(PointerEventData eventData)
    {
    }
    private void OnMouseDown()
    {
        mZCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;

        mOffset = gameObject.transform.position - GetMouseWorldPos();
        cardDrag = true;
        //shrinkSize = true;
    }

    private Vector3 GetMouseWorldPos()
    {
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = mZCoord;

        return Camera.main.ScreenToWorldPoint(mousePoint);
    }
    private void OnMouseDrag()
    {
        transform.position = GetMouseWorldPos() + mOffset;
    }
    private void OnMouseUp()
    {
        cardDrag = false;
       // shrinkSize = false;
    }

    public Vector3 GetMousePositionInWorldSpace()
    {
        Vector3 p = Camera.main.ScreenToWorldPoint(Input.mousePosition);
       // p.y = p.y - point;
        p.z = 0f;
        return p;
    }

    void ShrinkSize()
    {
        // transform.localScale = new Vector3(1.46f,2.2f,0.7f);
        Vector3 pos = transform.position;
        pos.z -= 1.9f;
        transform.position = pos;

    }
}

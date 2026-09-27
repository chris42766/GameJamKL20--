using System.Drawing;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class CardInteraction : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{

    private Vector3 mOffset;
    private float mZCoord;
    public bool cardDrag = false;
    bool cardDragOut = false;
    bool shrinkSize = false;
    bool isLocked = false;
    // bool shrinkSize = false;


    public CardIdentity identity;
   

    public bool beingHovered;
    public Vector3 defaultSize = new Vector3(-19, -27.3f, -10.2f);
    public Vector3 magnifiedSize = new Vector3(-19,-26f,-10.2f);
    private Vector3 originalPosition;
    float cooldown = 0.6f;

    void Awake()
    {
        identity = GetComponent<CardIdentity>();
     
    }
    void Start()
    {
        originalPosition = transform.position;
    }

/*   void Update()
    {
        if (cardDrag) return;
        if (beingHovered)
        {
            // transform.position = new Vector3(originalPosition.x,originalPosition.y +0.1f, +originalPosition.z);
            Vector3 target = new Vector3(originalPosition.x, originalPosition.y + 0.1f, originalPosition.z);
            transform.position = Vector3.Lerp(transform.position, target, Time.deltaTime * 5f); 
    }
        else if (!beingHovered && !cardDragOut)
        {
            transform.position = Vector3.Lerp(transform.position, originalPosition, Time.deltaTime * 5f);
        
    }
            //transform.position = originalPosition;
        
    }*/
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
      
      //  UI.SetActive(true);
    }
    public void OnPointerExit(PointerEventData eventData)
    {
       
            //UI.SetActive(false);
    }
    private void OnMouseDown()
    {
        mZCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;

        mOffset = gameObject.transform.position - GetMouseWorldPos();
        cardDrag = true;
        cardDragOut = true;
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
        cardDragOut = false;
        originalPosition = transform.position;

       // shrinkSize = false;
    }

    public Vector3 GetMousePositionInWorldSpace()
    {
        Vector3 p = Camera.main.ScreenToWorldPoint(Input.mousePosition);
       // p.y = p.y - point;
        p.z = 0f;
        return p;
    }
    private void OnMouseEnter()
    {
        beingHovered = true;
    }

    private void OnMouseExit()
    {
        beingHovered = false;
    }

}

using UnityEngine;

public class EffectsScript : MonoBehaviour
{
    public bool beingHovered;
    public Vector3 defaultSize = new Vector3(1f, 1f, 0.1f);
    public Vector3 magnifiedSize = new Vector3(1.2f, 1.2f, 0.1f);
    public Vector3 hoverAngle = new Vector3(0, 0, 15);
    //[SerializeField] private 
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (beingHovered)
        {

            if (transform.localScale != magnifiedSize)
            {
                transform.localScale = magnifiedSize;
                transform.eulerAngles = hoverAngle;
            }

        }
        else
        {
            
            if (transform.localScale != defaultSize)
            {
                transform.localScale = defaultSize;
                transform.eulerAngles = Vector3.zero;
            }

        }
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

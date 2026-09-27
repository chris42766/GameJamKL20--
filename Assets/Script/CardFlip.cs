using UnityEngine;

public class CardFlip : MonoBehaviour
{
    private bool isHovering;
    private CardDisplay display;

    void Awake()
    {
        display= GetComponent<CardDisplay>();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour=

    // Update is called once per frame
    void Update()
    {
        if (isHovering && Input.GetKeyDown(KeyCode.K))
        {
            TryFlip();
        }
    }
    void OnMouseEnter()
    {
        isHovering = true;
    }
    void OnMouseExit()
    {
        isHovering = false;
    }
    public void TryFlip()
    {
        int currentRank = display.cardData.rank;

        if (currentRank != 3 && currentRank != 6) return;

        CardData newData= display.cardData;
        newData.rank=(currentRank==3)?6:3;

        display.SetCard(newData);
        transform.Rotate(0f, 180f, 0f);
    }
}

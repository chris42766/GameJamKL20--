using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using UnityEngine;

public class AddPlayAreaScript : MonoBehaviour
{
    public TensPlayAreaScript TPAScript;
  //  public DeckTesting deckTesting;
    public List<GameObject> groupOfCards;
    //public CardInteraction CI;
    private int initialtotalNumber = 0;
    public int totalNumber = 0;
    public int cardPlayed = 0;
    public bool stopLoop = false;
    public bool multiplier = false;
    public BoxCollider boxCollider;

    public bool nextRoundAdd;
    //public groupOfTargets = GameObject.FindGameObjectsWithTag("Target").ToList();
    // Start is called once before the first execution of Update after the MonoBehaviour is created
   void Awake()
    {
        //boxCollider.enabled = false;
    }
    //void Start()
    // Update is called once per frame
    void Update()
    {
        //CI=GameObject.FindGameObjectWithTag("Card").GetComponent<CardInteraction>();

        /*if (TPAScript.playAdd)
        {
            boxCollider.enabled = true;
        }*/
        //ShootableElectronScript bullet = groupOfBalls[k].GetComponent<ShootableElectronScript>(); /

        groupOfCards = GameObject.FindGameObjectsWithTag("Card").ToList();
        if (!stopLoop)
        {
            if (cardPlayed == 2)
            {
                if (totalNumber >= 11&&totalNumber!=20&&totalNumber!=30)
                {
                    int trueAnswer = totalNumber % 10;
                    totalNumber= trueAnswer;
                    Debug.Log(totalNumber);
                }
                else if (totalNumber == 20 || totalNumber == 30)
                {
                    totalNumber = 10;
                    Debug.Log(totalNumber);
                }
                else
                {
                    Debug.Log(totalNumber);
                }
                nextRoundAdd = true;

                stopLoop = true;
            }
        }

    }

    void OnTriggerStay(Collider collisioninfo)
    {
        if (collisioninfo.tag == "Card")
        {
            if (groupOfCards.Contains(collisioninfo.gameObject))
            {
                CardDisplay display = collisioninfo.GetComponent<CardDisplay>();
                CardInteraction CI = collisioninfo.GetComponent<CardInteraction>();
                BoxCollider BoxCollider = collisioninfo.GetComponent<BoxCollider>();

                if (display != null && CI.cardDrag == false && cardPlayed != 2)
                {
                    if (cardPlayed == 0)
                    {
                        int cardValue = display.cardData.CardValue;
                       totalNumber += cardValue;
                        cardPlayed += 1;
                        collisioninfo.gameObject.transform.position = new Vector3(-10.3f, 3.53f, 4.14f);
                        //Destroy(collisioninfo.gameObject);
                        Debug.Log(totalNumber);
                        Destroy(BoxCollider);
                    }
                    else if (cardPlayed == 1)
                    {
                        
                        int cardValue = display.cardData.CardValue;
                   
                        totalNumber += cardValue;
                        cardPlayed += 1;
                        collisioninfo.gameObject.transform.position = new Vector3(-5.9f, 3.53f, 4.14f);
                        //Destroy(collisioninfo.gameObject);
                        Debug.Log(totalNumber);
                        Destroy(BoxCollider);
                    }
                    
                }


                // collisioninfo.GetComponent<TutorialTarget>().changeTarget();

                // Destroy(gameObject);
            }
        }
    }
}

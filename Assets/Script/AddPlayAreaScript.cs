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
    public DeckTesting deckTesting;
    //public TensPlayAreaScript tpaScript;
    public bool nextRoundAdd;


    //pair checking system
    private int firstCardRank=-1;
    private int secondCardRank=-1;
    public bool isPair=false;
    


   void Awake()
    {
        //boxCollider.enabled = false;
    }
    //void Start()
    // Update is called once per frame
    void Update()
    {
        //CI=GameObject.FindGameObjectWithTag("Card").GetComponent<CardInteraction>();
        groupOfCards = GameObject.FindGameObjectsWithTag("Card").ToList();
        if (TPAScript.playAddEnabled)
        {
            boxCollider.enabled = true;
        }
        else if (!TPAScript.playAddEnabled)
        {
            boxCollider.enabled = false;
        }
        
        if (!stopLoop)
        {
            if (cardPlayed == 2)
            {
                if (TPAScript.Condition)

                {
                    if (firstCardRank == secondCardRank)
                    {
                        if (firstCardRank == 1)
                        {
                            Debug.Log("Aces Pair");
                        }
                        else
                        {
                            Debug.Log("PAIR");
                        }
                       
                    }
                    else if (firstCardRank != secondCardRank)
                    {
                        if (totalNumber >= 11 && totalNumber != 20 && totalNumber != 30)
                        {
                            int trueAnswer = totalNumber % 10;
                            totalNumber = trueAnswer;
                            Debug.Log(totalNumber);
                        }
                        else if (totalNumber == 20 || totalNumber == 30)
                        {
                            totalNumber = 10;
                          
                        }
                       
                      
                    }
                }
                else if (!TPAScript.Condition)
                {
                    totalNumber = 0;
                    nextRoundAdd = true;
                    stopLoop = true;
                }
                nextRoundAdd = true;
                stopLoop = true;
                Debug.Log(totalNumber);
            }
        }

    }

    void OnTriggerStay(Collider collisioninfo)
    {
        if (collisioninfo.tag == "Card")
        {
            if (groupOfCards.Contains(collisioninfo.gameObject))
            {
                CardIdentity display = collisioninfo.GetComponent<CardIdentity>();
                CardInteraction CI = collisioninfo.GetComponent<CardInteraction>();
                BoxCollider BoxCollider = collisioninfo.GetComponent<BoxCollider>();
                
                if (display != null && CI.cardDrag == false && cardPlayed != 2)
                {
                    if (cardPlayed == 0)
                    {
                        int cardValue = display.cardData.CardValue;
                       totalNumber += cardValue;
                        cardPlayed += 1;
                        collisioninfo.gameObject.transform.position = new Vector3(-19.5f, -26.54f, -9.2f);

                        firstCardRank = display.cardData.rank;
                           
                        GameObject duplicate = Instantiate(collisioninfo.gameObject, new Vector3(-18.84f, -27.272f, -9.665f), Quaternion.Euler(0f, 81.93f, 180f));
                        duplicate.transform.localScale = new Vector3(0.33f, 0.33f, 0.33f);
                        deckTesting.RegisterSpawnedCard(duplicate);
                       
                        //Destroy(collisioninfo.gameObject);
                        Debug.Log(totalNumber);
                        Destroy(BoxCollider);
                    }
                    else if (cardPlayed == 1)
                    {
                        
                        int cardValue = display.cardData.CardValue;
                   
                        totalNumber += cardValue;
                        cardPlayed += 1;
                        collisioninfo.gameObject.transform.position = new Vector3(-18.9f, -26.54f, -9.2f);

                        secondCardRank = display.cardData.rank;
               
                        GameObject duplicate = Instantiate(collisioninfo.gameObject, new Vector3(-18.57f, -27.272f, -9.659f), Quaternion.Euler(0f, 110.5f, 180f));
                        duplicate.transform.localScale = new Vector3(0.33f, 0.33f, 0.33f);
                        deckTesting.RegisterSpawnedCard(duplicate);

                        Debug.Log(totalNumber);
                        Destroy(BoxCollider);
                       // Destroy(duplicate.BoxCollider);
                    }
                    
                }


                // collisioninfo.GetComponent<TutorialTarget>().changeTarget();

                // Destroy(gameObject);
            }
        }
    }
}

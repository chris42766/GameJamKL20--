using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using UnityEngine;

public class TensPlayAreaScript : MonoBehaviour
{
    public List<GameObject> groupOfCards;
    //public CardInteraction CI;
   public int totalNumber=0;
    public int cardPlayed=0;
    public bool stopLoop=false;

    public bool playAddEnabled = false;
    public bool nextRoundTen=false;
    public DeckTesting deckTesting;

    public bool Condition;
    //public groupOfTargets = GameObject.FindGameObjectsWithTag("Target").ToList();
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //CI=GameObject.FindGameObjectWithTag("Card").GetComponent<CardInteraction>();

                       
            //ShootableElectronScript bullet = groupOfBalls[k].GetComponent<ShootableElectronScript>(); /

        groupOfCards = GameObject.FindGameObjectsWithTag("Card").ToList();
        if (!stopLoop)
        {
            if (cardPlayed == 3)
            {
                playAddEnabled = true;
                if (totalNumber == 10 || totalNumber == 20 || totalNumber == 30)
                {
                    Debug.Log("Condition Granted");
                    //playAdd = true;
                    stopLoop = true;
                    nextRoundTen = true;
                    Condition = true;
                }
                else
                {
                    Debug.Log("Condition Denied");

                    stopLoop = true;
                    nextRoundTen=true;
                    Condition = false;
                }

            }
        }
       
}

    void OnTriggerStay(Collider collisioninfo)
    {
        if (collisioninfo.tag == "Card")
        {
            if (groupOfCards.Contains(collisioninfo.gameObject))
            {
                CardIdentity identity = collisioninfo.GetComponent<CardIdentity>();
                CardInteraction CI=collisioninfo.GetComponent<CardInteraction>();
                BoxCollider BoxCollider=collisioninfo.GetComponent<BoxCollider>();
               
                if (identity != null&&CI.cardDrag==false&&cardPlayed!=3)
                {
                    if (cardPlayed == 0)
                    {
                        int cardValue = identity.cardData.CardValue;
                        totalNumber += cardValue;
                        cardPlayed += 1;
                        collisioninfo.gameObject.transform.position= new Vector3(-17.99f, -26.53f, -9.2f);
                        //Destroy(collisioninfo.gameObject);
                        GameObject duplicate = Instantiate(collisioninfo.gameObject, new Vector3(-18.12f, -27.272f, -9.665f), Quaternion.Euler(0f, 107.7f, 180f));

                        duplicate.transform.localScale = new Vector3(0.33f, 0.33f, 0.33f);
                        deckTesting.RegisterSpawnedCard(duplicate);
                        Debug.Log(totalNumber);
                        Destroy(BoxCollider);
                    }
                    else if (cardPlayed == 1)
                    {
                        int cardValue = identity.cardData.CardValue;
                        totalNumber += cardValue;
                        cardPlayed += 1;
                        collisioninfo.gameObject.transform.position = new Vector3(-17.47f, -26.54f, -9.2f);
                        //Destroy(collisioninfo.gameObject);
                        GameObject duplicate = Instantiate(collisioninfo.gameObject, new Vector3(-17.85f, -27.272f, -9.659f), Quaternion.Euler(0f, 78.1f, 180f));

                        duplicate.transform.localScale = new Vector3(0.33f, 0.33f, 0.33f);
                        deckTesting.RegisterSpawnedCard(duplicate);
                        Debug.Log(totalNumber);
                        Destroy(BoxCollider);
                    }
                    else if (cardPlayed == 2)
                    {
                        int cardValue = identity.cardData.CardValue;
                        totalNumber += cardValue;
                        cardPlayed += 1;
                        collisioninfo.gameObject.transform.position = new Vector3(-16.96f, -26.54f, -9.2f);
                        GameObject duplicate = Instantiate(collisioninfo.gameObject, new Vector3(-17.58f, -27.272f, -9.659f), Quaternion.Euler(0f, 88f, 180));

                        duplicate.transform.localScale = new Vector3(0.33f, 0.33f, 0.33f);
                        deckTesting.RegisterSpawnedCard(duplicate);
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

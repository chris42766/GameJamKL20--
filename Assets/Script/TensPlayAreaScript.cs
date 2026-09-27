using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using UnityEngine;

public class TensPlayAreaScript : MonoBehaviour
{
    public List<GameObject> groupOfCards;
    //public CardInteraction CI;
    private int totalNumber=0;
    private int cardPlayed=0;
    bool stopLoop=false;

    public bool playAdd = false;
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
                if (totalNumber == 10 || totalNumber == 20 || totalNumber == 30)
                {
                    Debug.Log("Condition Granted");
                    playAdd = true;
                    stopLoop = true;
                }
                else
                {
                    Debug.Log("Condition Denied");
                    stopLoop = true;
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
                CardDisplay display = collisioninfo.GetComponent<CardDisplay>();
                CardInteraction CI=collisioninfo.GetComponent<CardInteraction>();
                BoxCollider BoxCollider=collisioninfo.GetComponent<BoxCollider>();
               
                if (display != null&&CI.cardDrag==false&&cardPlayed!=3)
                {
                    if (cardPlayed == 0)
                    {
                        int cardValue = display.cardData.CardValue;
                        totalNumber += cardValue;
                        cardPlayed += 1;
                        collisioninfo.gameObject.transform.position= new Vector3(2f, 3.53f, 4.14f);
                        //Destroy(collisioninfo.gameObject);
                        Debug.Log(totalNumber);
                        Destroy(BoxCollider);
                    }
                    else if (cardPlayed == 1)
                    {
                        int cardValue = display.cardData.CardValue;
                        totalNumber += cardValue;
                        cardPlayed += 1;
                        collisioninfo.gameObject.transform.position = new Vector3(6.63f, 3.53f, 4.14f);
                        //Destroy(collisioninfo.gameObject);
                        Debug.Log(totalNumber);
                        Destroy(BoxCollider);
                    }
                    else if (cardPlayed == 2)
                    {
                        int cardValue = display.cardData.CardValue;
                        totalNumber += cardValue;
                        cardPlayed += 1;
                        collisioninfo.gameObject.transform.position = new Vector3(11.21f, 3.53f, 4.14f);
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

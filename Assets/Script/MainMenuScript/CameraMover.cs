using Unity.VisualScripting;
using UnityEngine;

public class CameraMover : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    Vector3 targetPosition;
    Vector3 targetEulerAngles;
    //Quaternion targetRotation=Quaternion.Euler(9.11f,0,0);
    Vector3 originalPosition;
    Quaternion originalRotation;
    Quaternion targetRotation ;
    //public Animator camAnimator;
    public bool isAtTarget;
    public float speed;
    float cooldown = 2.5f;

    void Start()
    {
        isAtTarget = false;
        originalPosition=transform.localPosition;
        originalRotation=transform.localRotation;
        targetRotation = Quaternion.Euler(targetEulerAngles);
    }

    // Update is called once per frame
    void Update()
    {
      
        Vector3 goalPos = isAtTarget ? targetPosition : originalPosition;
        Quaternion goalRot=isAtTarget ? targetRotation : originalRotation;


        if (isAtTarget)
        {
            if (cooldown > 0)
            {
                cooldown -= Time.deltaTime;
            }
            else if (cooldown < 0)
            {
                transform.localPosition = Vector3.Lerp(transform.localPosition, new Vector3(-0.958f, 1.672f, -3.761f), Time.deltaTime * speed);
                transform.localRotation = Quaternion.Slerp(transform.localRotation, Quaternion.Euler(9.11f, 0, 0), Time.deltaTime * speed);
            }
          //  transform.localPosition = Vector3.Lerp(transform.localPosition, new Vector3(-0.958f, 1.672f, -3.761f), Time.deltaTime * speed);
            //transform.localRotation = Quaternion.Slerp(transform.localRotation, Quaternion.Euler(9.11f, 0, 0), Time.deltaTime * speed);
        }
       
    }
   
}

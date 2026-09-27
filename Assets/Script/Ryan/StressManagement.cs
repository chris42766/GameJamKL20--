using UnityEngine;

public class StressManagement : MonoBehaviour
{
    public int stressAmount;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (stressAmount < 0)
        {
            stressAmount = 0;
        }

        if (Input.GetMouseButtonDown(1))
        {
            stressAmount += 1;
            Debug.Log("STRESSSSSSSSSSSSSSSSSSSSSSSSSSSS, MATE!");
        }

        Debug.Log("Stress is " + stressAmount + " at the moment.");
    }
}

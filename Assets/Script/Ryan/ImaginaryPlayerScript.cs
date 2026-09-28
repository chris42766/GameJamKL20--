using UnityEngine;

public class ImaginaryPlayerScript : MonoBehaviour
{
    public float stress = 100.0f;
    public float MaxStress = 100.0f;
    public StressBarScript stressBarScript;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetMouseButtonDown(1))
        {
            StressRelief(1);

            stressBarScript.fillAmount = stress / MaxStress;
            Debug.Log("fill amount: " + stressBarScript.fillAmount);
        }
        
        //addPlayAreaScript.cardPlayed = 0;
        
    }


    public void AddStress(float gain)
    {
        stress += gain;
        stress = Mathf.Max(stress, 0.0f);
    }

    public void StressRelief(float loss)
    {
        stress -= loss;
        stress = Mathf.Max(loss, 0.0f);
        Debug.Log("Phew. I'm at " + stress + " stress level.");

        stressBarScript.fillAmount = stress / MaxStress;
        Debug.Log("fill amount: " + stressBarScript.fillAmount);
        //addPlayAreaScript.cardPlayed = 0;
    }

}

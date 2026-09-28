using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHPBar : MonoBehaviour
{
    public Image fill;
    public float changeSpeed = 1.0f;


    public AddPlayAreaScript playAreaScript; //   #confuSON

    public float fillAmount { get; set; }  = 1.0f;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        fill.fillAmount = Mathf.Lerp(fill.fillAmount, fillAmount, changeSpeed * Time.deltaTime);


        //ignore those first few lines for now...

    }
}

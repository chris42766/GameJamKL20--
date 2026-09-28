using UnityEngine;

public class Levitate : MonoBehaviour
{
    [SerializeField] private float height = 0.3f;   // how far up and down
    [SerializeField] private float speed = 2f;

    private Vector3 basePos;
    private float startTime;
    void OnEnable()
    {
        basePos = transform.position;
        startTime = Time.time;
    }
    // Update is called once per frame
    void Update()
    {
        float y = Mathf.Sin((Time.time - startTime) * speed) * height;
        transform.position = basePos + Vector3.up * y;
    }
}

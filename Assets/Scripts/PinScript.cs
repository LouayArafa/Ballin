using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PinScript : MonoBehaviour
{
    public float MovementThreshold;
    public int Score;
    private Rigidbody rb;
    private GameManager gameManager;


    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        gameManager = GameManager.Instance;
    }
    private void Update()
    {
        if(rb.velocity.magnitude > MovementThreshold)
        {
            gameManager.addScore(Score);
            gameObject.GetComponent<PinScript>().enabled = false;
        }
    }
}

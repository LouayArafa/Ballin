/// this script controls the ball's behavior after it's lunches
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ballbehavior : MonoBehaviour
{

    public Rigidbody rb;
    public Transform cam;

    public float LaunchSpeed;
    public float SideSpeed;
    public float MaxSpeed;


    public Vector3 Offset;

    public bool IsControllable = true;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponentInChildren<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.AddForce(cam.transform.forward * LaunchSpeed * Time.deltaTime);

        if (IsControllable == true)
        {
            float HorizontalMovement = Input.GetAxis("Horizontal");

            rb.AddForce(cam.transform.right * HorizontalMovement * SideSpeed * Time.deltaTime);
            rb.velocity = Vector3.ClampMagnitude(rb.velocity, MaxSpeed);

            CameraFollow();
        }

       
    }



    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Limit")
        {
            IsControllable = false;
        }
        if (other.gameObject.CompareTag("Fail"))
        {
            GameManager.Instance.ResetScene();
        }
    }


    void CameraFollow()
    {
        cam.position = gameObject.transform.position + Offset;
    }

}

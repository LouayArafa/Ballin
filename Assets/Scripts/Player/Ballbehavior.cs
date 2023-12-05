/// this script controls the ball's behavior after it's lunches
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ballbehavior : MonoBehaviour
{

    #region Variables
    public Rigidbody m_rigidbody;
    public PlayerInputs inputs;
    public Transform cam;

    private Vector3 Velocity;

    public float LaunchSpeed;
    public float SideSpeed;
    public float MaxSpeed;
    #endregion

    #region Variables
    // Start is called before the first frame update
    void Start()
    {
        m_rigidbody = GetComponentInChildren<Rigidbody>();
        inputs = GetComponent<PlayerInputs>();
    }

    // Update is called once per frame
    void Update()
    {
        m_rigidbody.AddForce(cam.transform.forward * LaunchSpeed);
        m_rigidbody.AddForce(cam.transform.right * inputs.HorizontalMovement * SideSpeed);
        m_rigidbody.velocity = Vector3.ClampMagnitude(m_rigidbody.velocity, MaxSpeed);
    }
    #endregion

}

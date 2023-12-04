/// this script controls the ball's behavior after it's lunches
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ballbehavior : MonoBehaviour
{

    #region Variables
    public Rigidbody m_rigidbody;
    public PlayerInputs inputs;
    public Transform BowlingBall;

    private Vector3 Velocity;

    public float LunchSpeed;
    public float SideSpeed;
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
        m_rigidbody.AddForce(transform.TransformDirection(transform.forward) * LunchSpeed);
    }
    #endregion

}

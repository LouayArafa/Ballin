/// this script is used to register the player inputs
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputs : MonoBehaviour
{

    #region Variables
    public bool IsControllable;

    public float HorizontalMovement;
    #endregion

    #region BuiltIn Methods
    // Start is called before the first frame update
    void Start()
    {
        //IsControllable = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(IsControllable)
            HorizontalMovement = Input.GetAxis("Horizontal");
    }
    #endregion

}

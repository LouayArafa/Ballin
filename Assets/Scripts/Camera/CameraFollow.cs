///this script allow the camera to follow the player
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    #region Variables
    
    public Transform Target;
    public Vector3 Offset;
    #endregion

    #region BuiltIn Methods
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Target.position + Offset;
    }
    #endregion

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    #region Serialized Variables
    [Tooltip("Add player here")]
    [SerializeField]
    private Transform player;

    [Tooltip("Offset the camera follows the player")]
    [SerializeField]
    private Vector3 offset;
    

    #endregion



    #region MonoBehavior Callbacks
    private void Update()
    {
        transform.position = player.position - offset;
    }

    #endregion
}

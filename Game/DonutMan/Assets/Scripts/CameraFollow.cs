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

    [Tooltip("Speed the camera follows the player")]
    [SerializeField]
    private float followSpeed;
    

    #endregion



    #region MonoBehavior Callbacks
    private void Update()
    {
        transform.position = new Vector3(Mathf.Lerp(transform.position.x, player.position.x + offset.x, followSpeed), transform.position.y, transform.position.z) ;
    }

    #endregion
}

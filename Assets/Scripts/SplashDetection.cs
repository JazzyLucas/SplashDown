using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplashDetection : MonoBehaviour
{
    #region Private Fields

    [SerializeField] private GameObject jumpPoint;
    [SerializeField] private GameObject playerObject;
    private Rigidbody playerRigidbody;

    #endregion

    #region Monobehaviour Callbacks

    void Start()
    {
        playerRigidbody = playerObject.GetComponent<Rigidbody>();
        goToJumpLocation();
    }

    private void Update()
    {
        if(Input.GetKeyDown("j"))
        {
            goToJumpLocation();
        }
    }

    #endregion

    #region Unity Methods

    private void OnTriggerEnter()
    {
        goToJumpLocation();
    }

    #endregion

    #region Private Methods

    private void goToJumpLocation()
    {
        // Teleport the player to the jumpPoint
        playerObject.transform.position = jumpPoint.transform.localPosition;
        // Reset the player's rotation when they get to the jumpPoint
        playerObject.transform.eulerAngles = Vector3.zero;
        // Reset the player's velocity to 0 in all directions. Very Important!
        playerRigidbody.velocity = Vector3.zero;
        playerRigidbody.angularVelocity = Vector3.zero;
    }

    #endregion
}

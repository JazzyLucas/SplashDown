using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    #region Private Fields

    [SerializeField] private GameObject playerObject;
    private Rigidbody playerRigidbody;
    private Vector3 input = Vector3.zero;

    #endregion

    #region Monobehaviour Callbacks

    // Start is called before the first frame update
    void Start()
    {
        playerRigidbody = playerObject.GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        playerRigidbody.MovePosition(playerRigidbody.position + input * 10 * Time.fixedDeltaTime);
    }

    // Update is called once per frame
    void Update()
    {
        GetInput();
    }

    #endregion

    #region Public Methods
    #endregion

    #region Private Methods

    private void GetInput()
    {
        // Reset the vector each time we get input.
        input = Vector3.zero;
        // Using Horizontal and Vertical axes allows for use of controllers and easy control redefining with an Input Manager.
        input.x = Input.GetAxis("Horizontal");
        input.z = Input.GetAxis("Vertical");
    }

    #endregion
}

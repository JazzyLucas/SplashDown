using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SplashDetection : MonoBehaviour
{
    #region Private Fields

    [SerializeField] private GameObject jumpPoint;
    [SerializeField] private GameObject playerObject;
    [SerializeField] private TextMeshProUGUI scoreText;
    private int currentScore = -1;
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
            currentScore = 0;
        }
    }

    #endregion

    #region Unity Methods

    private void OnTriggerEnter()
    {
        goToJumpLocation();
        currentScore++;
        updateScoreText();
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
        // Update the score
        updateScoreText();
    }

    private void updateScoreText()
    {
        scoreText.text = currentScore.ToString();
    }

    #endregion
}

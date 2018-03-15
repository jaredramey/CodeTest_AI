using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Player_CharacterController : MonoBehaviour
{
    #region Variables_Private
    private Rigidbody playerBody;
    [SerializeField]
    private float moveForce = 0.0f;
    [HideInInspector]
    private bool isCrouched = false;
    #endregion Variables_Private


    // Use this for initialization
    void Start()
    {
        //Initialize variables
        playerBody = gameObject.GetComponent<Rigidbody>();

        //Input listeners
        Player_InputHandler.Instance.OnMoveForward.AddListener(Handle_OnMoveForward);
        Player_InputHandler.Instance.OnMoveLeft.AddListener(Handle_OnMoveLeft);
        Player_InputHandler.Instance.OnMoveBackward.AddListener(Handle_OnMoveBackward);
        Player_InputHandler.Instance.OnMoveRight.AddListener(Handle_OnMoveRight);
        Player_InputHandler.Instance.OnCrouch.AddListener(Handle_OnCrouch);
        Player_InputHandler.Instance.OnDropCigarette.AddListener(Handle_OnDropCigarette);
    }

    // Update is called once per frame
    void Update()
    {

    }

    #region Listener_Handles
    private void Handle_OnMoveForward()
    {
        Debug.Log("Moving forward");
        playerBody.AddForce(((Vector3.forward) * moveForce) * Player_InputHandler.Instance.vertical);
    }
    private void Handle_OnMoveLeft()
    {

    }
    private void Handle_OnMoveBackward()
    {

    }
    private void Handle_OnMoveRight()
    {

    }
    private void Handle_OnCrouch()
    {

    }
    private void Handle_OnDropCigarette()
    {

    }
    #endregion Listener_Handles
}

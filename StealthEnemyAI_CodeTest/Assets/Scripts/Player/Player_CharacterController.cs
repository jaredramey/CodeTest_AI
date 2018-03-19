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
        //Player_InputHandler.Instance.OnMoveForward.AddListener(Handle_OnMoveForward);
        //Player_InputHandler.Instance.OnMoveLeft.AddListener(Handle_OnMoveLeft);
        //Player_InputHandler.Instance.OnMoveBackward.AddListener(Handle_OnMoveBackward);
        //Player_InputHandler.Instance.OnMoveRight.AddListener(Handle_OnMoveRight);
        //Player_InputHandler.Instance.OnCrouch.AddListener(Handle_OnCrouch);
        //Player_InputHandler.Instance.OnDropCigarette.AddListener(Handle_OnDropCigarette);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 movement = new Vector3(Player_InputHandler.Instance.horizontal, 0.0f, Player_InputHandler.Instance.vertical);

        playerBody.AddForce(movement * moveForce);
    }

    #region Listener_Handles
    private void Handle_OnMoveForward()
    {
        playerBody.AddForce(((Vector3.forward) * moveForce) * Player_InputHandler.Instance.vertical);
    }
    private void Handle_OnMoveLeft()
    {
        playerBody.AddForce(((Vector3.left) * moveForce) * Player_InputHandler.Instance.horizontal);
    }
    private void Handle_OnMoveBackward()
    {
        playerBody.AddForce(((Vector3.forward) * moveForce) * Player_InputHandler.Instance.vertical);
    }
    private void Handle_OnMoveRight()
    {
        playerBody.AddForce(((Vector3.left) * moveForce) * Player_InputHandler.Instance.horizontal);
    }
    private void Handle_OnCrouch()
    {
        if (isCrouched)
        {
            isCrouched = false;
        }
        else
        {
            isCrouched = true;
        }
    }
    private void Handle_OnDropCigarette()
    {
        //TODO: Make it so player can drop a cigarette
    }
    #endregion Listener_Handles
}

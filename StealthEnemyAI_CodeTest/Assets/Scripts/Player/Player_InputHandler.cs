using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player_InputHandler : MonoBehaviour
{

    #region UnityEvent_InitArea
    [HideInInspector]
    public UnityEvent OnMoveForward = new UnityEvent();
    [HideInInspector]
    public UnityEvent OnMoveLeft = new UnityEvent();
    [HideInInspector]
    public UnityEvent OnMoveBackward = new UnityEvent();
    [HideInInspector]
    public UnityEvent OnMoveRight = new UnityEvent();
    [HideInInspector]
    public UnityEvent OnCrouch = new UnityEvent();
    [HideInInspector]
    public UnityEvent OnDropCigarette = new UnityEvent();
    #endregion UnityEvent_InitArea

    #region Variable_InitArea
    [SerializeField]
    [HideInInspector]
    public float horizontal = 0.0f, vertical = 0.0f;

    private static Player_InputHandler instance = null;

    public static Player_InputHandler Instance
    {
        get
        {
            if(instance == null)
            {
                instance = (Player_InputHandler)FindObjectOfType(typeof(Player_InputHandler));
                if (instance == null)
                {
                    instance = (new GameObject("Player_InputManager")).AddComponent<Player_InputHandler>(); ;
                }
            }
            return instance;
        }
    }
    #endregion Variable_InitArea

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        #region Player_Movement
        //Move forward
        if(Input.GetKeyDown(KeyCode.W))
        {
            OnMoveForward.Invoke();
        }
        //Move Left
        if (Input.GetKeyDown(KeyCode.A))
        {
            OnMoveLeft.Invoke();
        }
        //Move Backward
        if (Input.GetKeyDown(KeyCode.S))
        {
            OnMoveBackward.Invoke();
        }
        //Move Right
        if (Input.GetKeyDown(KeyCode.D))
        {
            OnMoveRight.Invoke();
        }
        //crouch
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            OnCrouch.Invoke();
        }
        //Drop a cigarette
        if (Input.GetKeyDown(KeyCode.F))
        {
            OnDropCigarette.Invoke();
        }
        #endregion Player_Movement
    }
}

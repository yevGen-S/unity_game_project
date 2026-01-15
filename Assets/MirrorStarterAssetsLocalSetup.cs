using UnityEngine;
using Mirror;
using UnityEngine.InputSystem;
using Cinemachine;


public class MirrorStarterAssetsLocalSetup : NetworkBehaviour
{
    [Header("Starter Assets Components")]
    public PlayerInput playerInput;
    public Behaviour starterAssetsInputs;
    public Behaviour thirdPersonController;

    public bool isLocal = false;

    [Header("Camera Settings")]
    public Transform cameraRoot; 

    public override void OnStartLocalPlayer()
    {
        if (playerInput) playerInput.enabled = true;
        if (starterAssetsInputs) starterAssetsInputs.enabled = true;
        if (thirdPersonController) thirdPersonController.enabled = true;

        CinemachineVirtualCamera vcam = GameObject.FindFirstObjectByType<CinemachineVirtualCamera>();
        
        if (vcam != null && cameraRoot != null)
        {
            vcam.Follow = cameraRoot;
            vcam.LookAt = cameraRoot;
            vcam.PreviousStateIsValid = false; 
            Debug.Log("Camera successfully attached to local player.");
        }
        else
        {
            Debug.LogWarning("Vcam or CameraRoot missing!");
        }

        isLocal = true;
    }
}

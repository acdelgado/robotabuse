using UnityEngine;

public class InputHandler : MonoBehaviour
{
    CameraControls cameraControls;
    public void Start()
    {
        cameraControls = new CameraControls();
        cameraControls.RotateCamera.Enable();
        cameraControls.MoveSelectable.Enable();

        OrbitalCameraController orbitalCam = Camera.main.transform.GetComponent<OrbitalCameraController>();
        cameraControls.RotateCamera.RotateCameraHorizontal.performed += ctx => orbitalCam?.UpdateOrbitX(cameraControls.RotateCamera.RotateCameraHorizontal.ReadValue<float>());
        cameraControls.RotateCamera.RotateCameraHorizontal.canceled += ctx => orbitalCam?.UpdateOrbitX(0);

        cameraControls.RotateCamera.RotateCameraVertical.performed += ctx => orbitalCam?.UpdateOrbitY(cameraControls.RotateCamera.RotateCameraVertical.ReadValue<float>());
        cameraControls.RotateCamera.RotateCameraVertical.canceled += ctx => orbitalCam?.UpdateOrbitY(0);

        cameraControls.MoveSelectable.HoldSelectable.performed += ctx => { cameraControls.RotateCamera.Disable(); GameManager.Instance.SetObjectHeld(true); };

        cameraControls.MoveSelectable.HoldSelectable.canceled += ctx => { cameraControls.RotateCamera.Enable(); GameManager.Instance.SetObjectHeld(false); };
    }
}

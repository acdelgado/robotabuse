using UnityEngine;

public class InputHandler : MonoBehaviour
{
    CameraControls cameraControls;
    public void Start()
    {
        cameraControls = new CameraControls();
        cameraControls.Default.Enable();

        OrbitalCameraController orbitalCam = Camera.main.transform.GetComponent<OrbitalCameraController>();
        cameraControls.Default.RotateCameraHorizontal.performed += ctx => orbitalCam?.UpdateOrbitX(cameraControls.Default.RotateCameraHorizontal.ReadValue<float>());
        cameraControls.Default.RotateCameraHorizontal.canceled += ctx => orbitalCam?.UpdateOrbitX(0);

        cameraControls.Default.RotateCameraVertical.performed += ctx => orbitalCam?.UpdateOrbitY(cameraControls.Default.RotateCameraVertical.ReadValue<float>());
        cameraControls.Default.RotateCameraVertical.canceled += ctx => orbitalCam?.UpdateOrbitY(0);
    }
}

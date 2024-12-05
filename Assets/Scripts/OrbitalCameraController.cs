using UnityEngine;

/*
The purpose of this script is to create controls for an camera that
orbits a target transform.
*/

[RequireComponent(typeof(Camera))]
public class OrbitalCameraController : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float distance;
    [SerializeField] private float rotationSpeed;

    private Vector2 orbitAngles;

    //Vector affected by inputs for moving the camera in a direction.
    //The functions to update the vector's values can be called by an input handler.
    private Vector2 inputVector;

    private void Awake()
    {
        transform.LookAt(target);
    }

    void LateUpdate()
    {
        orbitAngles = rotationSpeed * Time.unscaledDeltaTime * inputVector;
        transform.eulerAngles += new Vector3(orbitAngles.y, -orbitAngles.x, 0);

        transform.position = target.position - transform.forward * distance;
    }

    public void UpdateOrbitX(float x)
    {
        inputVector = new Vector2(x, inputVector.y);
    }

    public void UpdateOrbitY(float y)
    {
        inputVector = new Vector2(inputVector.x, y);
    }
}

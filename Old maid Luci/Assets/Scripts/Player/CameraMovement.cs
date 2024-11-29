using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    public Transform cameraPosition;

    private void Update()
    {
        transform.position = cameraPosition.position;
    }
}

using UnityEngine;

public class HeadbobController : MonoBehaviour
{
    [SerializeField] private bool enable = true;

    [SerializeField, Range(0, 0.1f)] private float amplitude = 0.015f;
    [SerializeField, Range(0, 30)] private float frequency = 10.0f;

    [SerializeField] private Transform _camera = null;
    [SerializeField] private Transform _cameraHolder = null;

    private float toggleSpeed = 3.0f;
    private Vector3 startPos;
    private Rigidbody controller;

    public float playerHeight;
    public LayerMask Ground;
    bool grounded;

    private void Awake()
    {
        controller = GetComponent<Rigidbody>();
        startPos = _camera.localPosition;
    }

    private void Update()
    {

        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, Ground);
        if (!enable) return;

        CheckMotion();
        ResetPosition();
        _camera.LookAt(FocusTarget());

    }

    private Vector3 FootStepMotion()
    {
        Vector3 pos = Vector3.zero;
        pos.y += Mathf.Sin(Time.time * frequency) * amplitude;
        pos.x += Mathf.Cos(Time.time * frequency / 2) * amplitude;
        return pos;
    }

    private void CheckMotion()
    {
        float speed = new Vector3(controller.linearVelocity.x, 0, controller.linearVelocity.z).magnitude;

        if (speed < toggleSpeed) return;
        if (!controller == grounded) return;

        PlayMotion(FootStepMotion());
    }

    private void PlayMotion(Vector3 motion)
    {
        _camera.localPosition += motion;
    }

    private Vector3 FocusTarget()
    {
        Vector3 pos = new Vector3(transform.position.x, transform.position.y * _cameraHolder.localPosition.y, transform.position.z);
        pos += _cameraHolder.forward * 15.0f;
        return pos;
    }

    private void ResetPosition()
    {
        if (_camera.localPosition == startPos) return;
        _camera.localPosition = Vector3.Lerp(_camera.localPosition, startPos, 1 * Time.deltaTime);
    }


    

    

}

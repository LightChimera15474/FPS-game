using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private float _xSensivity = 30f;
    [SerializeField] private float _ySensivity = 28f;
    [SerializeField] private float _minAngle = -70f;
    [SerializeField] private float _maxAngle = 70f;

    private float _xRotation = 0;
    private Transform _transform;

    private void Start()
    {
        _transform = GetComponent<Transform>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        Look();
    }

    public void Look()
    {
        var mouseX = Input.GetAxis("Mouse X");
        var mouseY = Input.GetAxis("Mouse Y");

        _xRotation -= mouseY  * Time.deltaTime * _ySensivity;
        _xRotation = Mathf.Clamp(_xRotation, _minAngle, _maxAngle);
        _camera.transform.localRotation = Quaternion.AngleAxis(_xRotation, Vector3.right);

        _transform.Rotate(Vector3.up, mouseX * Time.deltaTime * _xSensivity);
    }
}

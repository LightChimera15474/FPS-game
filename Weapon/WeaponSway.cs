using UnityEngine;

public class WeaponSway : MonoBehaviour
{
    [SerializeField] private float _swaySpeed;
    [SerializeField] private float _sensitivity;
    [SerializeField] private bool _useSway = false;

    private void Update()
    {
        Sway();
    }

    public void Sway()
    {
        if (_useSway)
        {
            var x = Input.GetAxis("Mouse X") * _sensitivity;
            var y = Input.GetAxis("Mouse Y") * _sensitivity;

            var xRotation = Quaternion.AngleAxis(-y, Vector3.right);
            var yRotation = Quaternion.AngleAxis(x, Vector3.up);

            var targetRotation = xRotation * yRotation;

            transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotation, _swaySpeed * Time.deltaTime);
        }
    }
}

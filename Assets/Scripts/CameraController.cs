using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Player _player;

    private Vector3 _targetPosition;
    private float _cameraAxisZ = -10f;

    private void Update()
    {
        _targetPosition = _player.transform.position;
        _targetPosition.z = _cameraAxisZ; 
        transform.position = Vector3.Lerp(transform.position, _targetPosition, Time.deltaTime);
    }
}
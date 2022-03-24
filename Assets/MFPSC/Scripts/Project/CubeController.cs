using UnityEngine;

public class CubeController : MonoBehaviour
{
    private PlayerController _playerController;

    private void Start()
    {
        _playerController = GameObject.FindWithTag("Player").gameObject.GetComponent<PlayerController>();
    }

    private void OnTriggerEnter (Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            _playerController.CountCube(gameObject);
        }
    }
    
}

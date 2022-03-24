using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class EnamyController : MonoBehaviour
{
    [SerializeField] private int _damage;
    [SerializeField] private GameObject _cube;
    
    [Range(1, 100)] public int _hpEnamy;

    private GameObject _player;
    private NavMeshAgent _agent;
    private bool _waitTime;
    private PlayerDamage _playerDamage;

    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _agent.updateRotation = false;
        _agent.updateUpAxis = false;
        _player = GameObject.FindWithTag("Player");
        _waitTime = false;
        _playerDamage = _player.GetComponent<PlayerDamage>();
       
    }

    void Update()
    {
        _agent.SetDestination(_player.transform.position);
    }

    private void OnTriggerStay (Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (!_waitTime)
            {
                _waitTime = true;
                StartCoroutine(Hit());
            }
        }
    }

    IEnumerator Hit()
    {
        _playerDamage.HitDamage(_damage);
        yield return new WaitForSeconds(1f);
        _waitTime = false;
    }
    
    public void HitDamageEnemy(int damage)
    {
        _hpEnamy -= damage;
        if (_hpEnamy < 1)
        {
            SpawnCube();
           Destroy(gameObject);
        }
    }

    public void SpawnCube()
    {
        var cube = Instantiate(_cube, transform.position, Quaternion.identity);
        var randomColor = Random.Range(0, 3);
        switch (randomColor)
        {
            case 0 :
                cube.GetComponent<MeshRenderer>().material.color = Color.red;
                break;
            case 1 :
                cube.GetComponent<MeshRenderer>().material.color = Color.green;
                break;
            case 2 :
                cube.GetComponent<MeshRenderer>().material.color = Color.yellow;
                break;
            default:
                cube.GetComponent<MeshRenderer>().material.color = Color.gray;
                break;
        }
        
    }
}

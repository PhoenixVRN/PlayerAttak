using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] GameObject _bullet;
    [SerializeField] float _bulletSpeed;
    
    public Color colorBullet;
    
    private AudioSource _audioSource;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void Fire()
    {
        _audioSource.Play();
        var newBullet = Instantiate(_bullet, transform.position, transform.rotation);
        
        newBullet.GetComponent<MeshRenderer>().material.color = colorBullet;
        newBullet.GetComponent<Rigidbody>().velocity = transform.forward * _bulletSpeed;
    }
}

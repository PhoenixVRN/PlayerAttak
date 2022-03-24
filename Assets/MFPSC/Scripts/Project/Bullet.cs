using UnityEngine;

public class Bullet : MonoBehaviour
{
   [Range(1, 10)][SerializeField] private int _damageBullet;
   [SerializeField] private float _liveTimeBullet;
   

   private void Update()
   {
      LiveBullet();
   }

   private void OnCollisionEnter(Collision other)
   {
      if (other.gameObject.tag == "Enamy")
      {
         other.gameObject.GetComponent<EnamyController>().HitDamageEnemy(_damageBullet);
      }
      DestroyBullet();
   }

   private void LiveBullet()
   {
      _liveTimeBullet -= Time.deltaTime;
      if (_liveTimeBullet < 0) DestroyBullet();
   }

   private void DestroyBullet()
   {
      Destroy(gameObject);
   }
}

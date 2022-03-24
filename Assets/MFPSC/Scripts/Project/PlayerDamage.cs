using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerDamage : MonoBehaviour
{
   [Range(1, 100)] public int _hp;
   
   public Text textHP;
   public void HitDamage(int damage)
   {
      _hp -= damage;
      if (_hp < 1)
      {
         _hp = 0;
         textHP.text = _hp.ToString();
         SceneManager.LoadScene("DemoScene");
      }
      else textHP.text = _hp.ToString();
   }
}

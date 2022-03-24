using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
   [SerializeField] private AudioSource _audioSourceCube;
   [HideInInspector] public int countRedCubes,
                                countGreenCubes,
                                countYellowCubes;

   public Text textRedCube,
               textGreenCube,
               textYellowCube;

   public Gun _gun;
   
   private void Start()
   {
      countRedCubes = 0;
      countGreenCubes = 0;
      countYellowCubes = 0;
   }

   public void CountCube( GameObject other)
   {
       _audioSourceCube.Play();
       var color = other.gameObject.GetComponent<MeshRenderer>().material.color;
         _gun.colorBullet = color;
         
         if (color == Color.red)
         {
            countRedCubes++;
            textRedCube.text = countRedCubes.ToString();
         }

         if (color == Color.green)
         {
            countGreenCubes++;
            textGreenCube.text = countGreenCubes.ToString();
         }

         if (color == Color.yellow)
         {
            countYellowCubes++;
            textYellowCube.text = countYellowCubes.ToString();
         }

         Destroy(other.gameObject);
      
      
   }
}

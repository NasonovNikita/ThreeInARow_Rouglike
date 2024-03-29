using System.Collections.Generic;
using Battle.Units.Enemies;
using UnityEngine;

namespace Battle.Units
{
    public class EnemyPlacement : MonoBehaviour
    {
        public GameObject[] points;
    
        public List<Enemy> enemiesToPlace;
   
    
        public void Place()
        {
            for (int i = 0; i < enemiesToPlace.Count; i++)
            {
                Enemy enemy = enemiesToPlace[i];
                enemy.transform.position = points[i].transform.position;
            }
        }
    }
}

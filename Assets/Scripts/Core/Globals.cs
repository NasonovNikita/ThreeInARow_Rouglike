using UnityEngine;

namespace Core
{
    public class Globals : MonoBehaviour
    {
        public static Globals instance;

        public bool randomSeed;

        public int seed;

        public float volume;

        public float difficulty; // It must be float, not int

        public bool altBattleUI;
    
        public void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
            else
            {
                Destroy(gameObject);
            }
        
            DontDestroyOnLoad(gameObject);
        }
    }
}
using System.Collections;
using UnityEngine;

public class CoroutinesContainer : MonoBehaviour
{
    public static CoroutinesContainer instance;
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

    public void Coroutine(IEnumerator routine)
    {
        StartCoroutine(routine);
    }
}

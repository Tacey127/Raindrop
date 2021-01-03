using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObjectOnDestroy : MonoBehaviour
{
    [SerializeField] GameObject spawningObject;

    bool isQuitting = false;

    private void OnApplicationQuit()
    {
        isQuitting = true;   
    }

    private void OnDestroy()
    {
        if(!isQuitting)
        {
            Instantiate(spawningObject, transform.position, Quaternion.identity);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PFXDestroyPostLoop : MonoBehaviour
{
    [SerializeField]ParticleSystem particleSyste;

    [SerializeField] bool selfDestructOnDuration = false;

    private void Start()
    {
        if(selfDestructOnDuration)
        {
            StartCoroutine(DestroyFromDuration());
            Debug.Log(particleSyste.main.duration);
        }
    }

    IEnumerator DestroyFromDuration()
    {
        yield return new WaitForSeconds(particleSyste.main.duration);
        Destroy(gameObject);
    }


}

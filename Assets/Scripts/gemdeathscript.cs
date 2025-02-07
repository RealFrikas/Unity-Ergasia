using StarterAssets;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;



public class gem1script : MonoBehaviour
{




    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }
}

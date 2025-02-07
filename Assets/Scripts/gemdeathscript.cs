using StarterAssets;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;



public class gem1script : MonoBehaviour
{
    public FirstPersonController playerscript;
    public int gemid;

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        switch(gemid)
        {
            //find powerups
            case 1:
                break;
            case 2:
                break;
            case 3:
                break;
            case 4:
                break;
            case 5:
                break;
        }
        playerscript.MoveSpeed = 8.0f;
    }
}

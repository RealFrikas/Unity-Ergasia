using StarterAssets;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;



public class gem1script : MonoBehaviour
{
    public FirstPersonController playerscript;
    public LogicScript logic;
    public int gemid;

    private void OnTriggerEnter(Collider other)
    {
        logic.Gemcollected();
        Destroy(gameObject);
        switch(gemid)
        {
            //find powerups
            case 1:
                Speedup();
                break;
            case 2:
                Jumpup();
                break;
            case 3:
                Speedup();
                break;
            case 4:
                //It definetely did something!
                break;
            case 5:
                Jumpup();
                break;
        }
    }

    public void Speedup()
    {
        playerscript.MoveSpeed += 2.0f;
        playerscript.SprintSpeed += 2.0f;
    }

        public void Jumpup()
    {
        playerscript.JumpHeight += 3.0f;
    }
}

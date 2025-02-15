using UnityEngine;

public class LogicScript : MonoBehaviour
{
    private int gemcount = 0;
    public bool endgame = false;

    public void Gemcollected()
    {
        gemcount++;
        if(gemcount == 5)
        {
            endgame = true;
        }
    }
}

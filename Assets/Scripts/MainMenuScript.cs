using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{

    public void Play () 
    {
        SceneManager.LoadSceneAsync(1);
    }

        public void Quit ()
    {
        Application.Quit();
    }
}

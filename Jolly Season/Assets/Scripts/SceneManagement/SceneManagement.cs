using UnityEngine.SceneManagement;
using UnityEngine;



public class SceneManagement : MonoBehaviour
{
    private int activeSceneIndex;
    private void OnEnable()
    {
        Events.OnSantaHouseEntered += LoadSceneA;
        Events.OnSantaHouseExited += LoadSceneB;
    }
    private void OnDisable()
    {
        Events.OnSantaHouseEntered -= LoadSceneA;
        Events.OnSantaHouseExited -= LoadSceneB;
    }
    public void LoadSceneA()
    {
        SceneManager.LoadScene("A");
    }

     public void LoadSceneB()
    {
        SceneManager.LoadScene("B");
    }

    public void LoadSceneC()
    {
        SceneManager.LoadScene("C");
    }

    public int GetCurrentScene()
    {
        activeSceneIndex = SceneManager.GetActiveScene().buildIndex;    
        return activeSceneIndex;    
    }
}
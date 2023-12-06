using UnityEngine.SceneManagement;
using UnityEngine;



public class SceneManagement : MonoBehaviour
{
    private void OnEnable()
    {
        Actions.OnSantaHouseEntered += LoadSceneA;
        Actions.OnSantaHouseExited += LoadSceneB;
    }
    private void OnDisable()
    {
        Actions.OnSantaHouseEntered -= LoadSceneA;
        Actions.OnSantaHouseExited -= LoadSceneB;
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
}
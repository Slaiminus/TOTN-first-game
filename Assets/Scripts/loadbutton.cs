using UnityEngine;
using UnityEngine.SceneManagement;

public class loadbutton: MonoBehaviour
{
    [SerializeField] public string targetsc;
    public void loadtarget()
    {
        SceneManager.LoadSceneAsync(targetsc, LoadSceneMode.Single);
    }
}

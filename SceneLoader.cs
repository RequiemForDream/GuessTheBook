using UnityEngine.SceneManagement;

namespace Utils
{
    public class SceneLoader
    {
        public static void LoadSceneByBuildIndex(int buildIndex)
        {
            SceneManager.LoadScene(buildIndex);
        }
    }
}

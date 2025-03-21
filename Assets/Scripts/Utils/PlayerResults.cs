using UnityEngine;

namespace Utils
{
    public class PlayerResults : MonoBehaviour
    {
        private const string Key = "Level_{0}_{1}";

        public void Save(int finalId, int idScene)
        {
            PlayerPrefs.SetInt(string.Format(Key, idScene, finalId), 1);
            PlayerPrefs.Save();
        }

        public bool CheckFinal(int finalId, int idScene) => PlayerPrefs.GetInt(string.Format(Key, idScene, finalId), 0) != 0;
    }
}
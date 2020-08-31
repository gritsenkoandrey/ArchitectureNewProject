using UnityEngine;


namespace Assets.Scripts.Managers
{
    [CreateAssetMenu(fileName = "ManagerEvents", menuName = "Managers/ManagerEvents")]
    public class ManagerEvents : ManagerBase
    {
        public GameObject prefab;

        public void CreatePrefab(Vector3 pos)
        {
            Instantiate(prefab, pos, Quaternion.identity);
        }
    }
}
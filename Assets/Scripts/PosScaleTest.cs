using UnityEngine;

public class PosScaleTest : MonoBehaviour
{
    [SerializeField] private GameObject cube10;
    [SerializeField] private GameObject cube5;
    [SerializeField] private GameObject cube1;

    void Start()
    {
        Log(cube10.transform);
        Log(cube5.transform);
        Log(cube1.transform);
    }

    private void Log(Transform trn)
    {
        Debug.Log($"-- {trn.gameObject.name} --");   
        Debug.Log($"World(pos, scale): {trn.position.z:F1}, {trn.lossyScale.z:F1}");   
        Debug.Log($"Local(pos, scale): {trn.localPosition.z:F1}, {trn.localScale.z:F1}");   
    }
}

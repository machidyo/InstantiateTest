using UnityEngine;

public class InstantiateTest: MonoBehaviour
{
    [SerializeField] private GameObject parent;
    [SerializeField] private GameObject child;

    private Vector3 worldPos = new (1, 1, 1);
    private Quaternion worldRot = Quaternion.Euler(0, 45, 15);

    void Start()
    {
        InstantiateSimple();
        InstantiateWithPositionAndRotation();
        InstantiateWithParent();
        
        InstantiateWithParentInWorldSpace();
        
        InstantiateWithAllOptions();
        
        InstantiateWithParentAndSetLocalValue();
    }

    private void InstantiateSimple()
    {
        var obj = Instantiate(child);
        obj.name = "Simple";

        obj.transform.localPosition = worldPos;
        obj.transform.localRotation = worldRot;

        obj.transform.parent = parent.transform;
        obj.transform.localScale *= parent.transform.localScale.x;
    }

    private void InstantiateWithPositionAndRotation()
    {
        var obj = Instantiate(child, worldPos, worldRot);
        obj.name = "PositionAndRotation";

        obj.transform.parent = parent.transform;
        obj.transform.localScale *= parent.transform.localScale.x;
    }

    private void InstantiateWithParent()
    {
        var obj = Instantiate(child, parent.transform, false);
        obj.name = "Parent";

        obj.transform.position = worldPos;
        obj.transform.rotation = worldRot;
    }
    
    private void InstantiateWithParentInWorldSpace()
    {
        var obj = Instantiate(child, parent.transform, true);
        obj.name = "ParentInWorldSpace";

        obj.transform.position = worldPos;
        obj.transform.rotation = worldRot;
        obj.transform.localScale *= parent.transform.localScale.x;
    }

    private void InstantiateWithAllOptions()
    {
        var obj = Instantiate(child, worldPos, worldRot, parent.transform);
        obj.name = "AllOptions";
    }
    
    private void InstantiateWithParentAndSetLocalValue()
    {
        var obj = Instantiate(child, parent.transform);
        obj.name = "ParentWithLocalValue";

        // よく使うので一回pTrnの変数におく
        var pTrn = parent.transform;
        // Instantiateした時点でparentの位置に設定されているので、残りの移動に必要なworldPosとparentの位置の差分を取得する
        var diff = worldPos - pTrn.position;
        // ワールド座標での差分を、localに適用するためparentのスケールで調整する
        var scaledLocalPos = diff / pTrn.lossyScale.x;
        // parentが回転してしまっている分を戻して、localPositionに設定する
        obj.transform.localPosition = Quaternion.Inverse(pTrn.rotation) * scaledLocalPos;

        // parentが回転してしまっている分を戻して、localRotationに設定する
        obj.transform.localRotation = Quaternion.Inverse(pTrn.rotation) * worldRot;
    }
}

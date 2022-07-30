using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Wood : MonoBehaviour
{
    [SerializeField] private SkinnedMeshRenderer skinnedMeshRenderer;
    [SerializeField] private Transform woodTransform;
    [SerializeField] private Vector3 rotationVector;
    [SerializeField] private float rotationDuration;
    

    private void Start()
    {
        woodTransform
            .DOLocalRotate(rotationVector, rotationDuration, RotateMode.FastBeyond360)
            .SetLoops(-1, LoopType.Restart)
            .SetEase(Ease.Linear);
    }
    public void Hit(int keyIndex,float damage)
    {
        float newWeight = skinnedMeshRenderer.GetBlendShapeWeight(keyIndex) + damage + 2.6f;
        Debug.Log(skinnedMeshRenderer.GetBlendShapeWeight(keyIndex));
        if (skinnedMeshRenderer.GetBlendShapeWeight(keyIndex) <= 100)
        {

            skinnedMeshRenderer.SetBlendShapeWeight(keyIndex, newWeight);
        }
    }
}

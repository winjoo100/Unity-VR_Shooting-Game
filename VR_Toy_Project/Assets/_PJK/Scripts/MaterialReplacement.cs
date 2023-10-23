using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialReplacement : MonoBehaviour
{
    public Material newMaterial; // 새로운 마테리얼을 설정할 수 있도록 인스펙터에서 할당

    void Start()
    {
        // 모든 렌더러(면)에 새로운 마테리얼을 할당
        Renderer[] renderers = GetComponentsInChildren<Renderer>();
        foreach (Renderer renderer in renderers)
        {
            renderer.material = newMaterial;
        }
    }
}

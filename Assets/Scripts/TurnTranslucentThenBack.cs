using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnTranslucentThenBack : MonoBehaviour
{
    public Material translucentMaterial;
    public Dictionary<MeshRenderer, Material[]> materialDictionary = new Dictionary<MeshRenderer, Material[]>();

    public void Start()
    {
        foreach (MeshRenderer childObjectMeshRenderer in GetComponentsInChildren<MeshRenderer>())
        {
            materialDictionary.Add(childObjectMeshRenderer, childObjectMeshRenderer.materials);
        }
    }

    public void TurnTranslucent()
    {
        foreach(MeshRenderer childObjectMeshRenderer in GetComponentsInChildren<MeshRenderer>())
        {
            int length = childObjectMeshRenderer.materials.Length;
            Material[] materialArray = new Material[length];
            for (int i = 0; i < length; i++)
            {
                materialArray[i] = translucentMaterial;
            }
            childObjectMeshRenderer.materials = materialArray;
        }
    }

    public void TurnBack()
    {
        foreach (MeshRenderer childObjectMeshRenderer in  materialDictionary.Keys)
        {
            childObjectMeshRenderer.materials = materialDictionary[childObjectMeshRenderer];
        }
    }
}

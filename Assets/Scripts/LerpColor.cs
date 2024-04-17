using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpColor : MonoBehaviour
{
    MeshRenderer CubeMeshRenderer;
    [SerializeField]
    [Range(0f, 1f)] float lerptime;
    [SerializeField] Color mycolor;
  
    void Start()
    {
        CubeMeshRenderer = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        CubeMeshRenderer.material.color = Color.Lerp(CubeMeshRenderer.material.color, Color.red, lerptime);
    }
}

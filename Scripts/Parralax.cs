using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parralax : MonoBehaviour
{
    private MeshRenderer MeshRenderer;

    public float textureOffsetSpeed = 0.05f; // to change background parralax speed

    private void Awake()
    {
        MeshRenderer = GetComponent<MeshRenderer>();
    }
    private void Update()
    {
        MeshRenderer.material.mainTextureOffset += new Vector2(textureOffsetSpeed*Time.deltaTime, 0);
    }
}

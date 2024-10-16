using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockTexture : MonoBehaviour
{
    MeshFilter blockMesh;
    Mesh mesh;


    // Start is called before the first frame update
    void Start()
    {
        blockMesh = GetComponent<MeshFilter>();
        mesh = blockMesh.mesh;
        Vector2[] uvMap = mesh.uv;

        //front
        uvMap[0] = new Vector2(0, 0);
        uvMap[1] = new Vector2(0.333f, 0);
        uvMap[2] = new Vector2(0, 0.333f);
        uvMap[3] = new Vector2(0.333f, 0.333f);

        //top
        uvMap[4] = new Vector2(0.334f, 0.333f);
        uvMap[5] = new Vector2(0.666f, 0.333f);
        uvMap[8] = new Vector2(0.334f, 0);
        uvMap[9] = new Vector2(0.666f, 0);

        //bottom
        uvMap[12] = new Vector2(0, 0.334f);
        uvMap[13] = new Vector2(0, 0.666f);
        uvMap[14] = new Vector2(0.333f, 0.666f);
        uvMap[15] = new Vector2(0.333f, 0.334f);

        //left
        uvMap[16] = new Vector2(0.334f, 0.334f);
        uvMap[17] = new Vector2(0.334f, 0.666f);
        uvMap[18] = new Vector2(0.666f, 0.666f);
        uvMap[19] = new Vector2(0.666f, 0.334f);

        //right
        uvMap[20] = new Vector2(0.667f, 0.334f);
        uvMap[21] = new Vector2(0.667f, 0.666f);
        uvMap[22] = new Vector2(1, 0.666f);
        uvMap[23] = new Vector2(1, 0.334f);

        mesh.uv = uvMap;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

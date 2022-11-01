using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MeshData
{
    public List<Vector3> vertList = new List<Vector3>();
    public List<BoneWeight> weights = new List<BoneWeight>();
    public List<Vector2> uvs = new List<Vector2>();
    public List<Vector3> normals = new List<Vector3>();

    public Dictionary<int, int> vert_map = new Dictionary<int, int>();

    public Mesh createMesh()
    {
        Mesh mesh = new Mesh();
        mesh.vertices = vertList.ToArray();
        mesh.normals = normals.ToArray();
        mesh.uv = uvs.ToArray();
        if (weights.Count == vertList.Count)
            mesh.boneWeights = weights.ToArray();
        return mesh;
    }

    public int AddPoint(int i, Mesh srcMesh)
    {
        vert_map.Add(i, vertList.Count);
        vertList.Add(srcMesh.vertices[i]);
        normals.Add(srcMesh.normals[i]);
        uvs.Add(srcMesh.uv[i]);
        weights.Add(i < srcMesh.boneWeights.Length ? srcMesh.boneWeights[i] : new BoneWeight());
        return vert_map.Count - 1;
    }


    public void RecreateTriangles(Mesh srcMesh, Mesh newMesh)
    {
        newMesh.subMeshCount = srcMesh.subMeshCount;
        for (int l = 0; l < srcMesh.subMeshCount; l++)
        {
            List<int> triList = new List<int>();
            int[] trisrc = srcMesh.GetTriangles(l);
            for (int i = 0; i < trisrc.Length; i += 3)
            {
                if (vert_map.ContainsKey(trisrc[i]) && vert_map.ContainsKey(trisrc[i + 1]) && vert_map.ContainsKey(trisrc[i + 2]))
                {
                    triList.Add(vert_map[trisrc[i]]);
                    triList.Add(vert_map[trisrc[i + 1]]);
                    triList.Add(vert_map[trisrc[i + 2]]);
                }
            }

            newMesh.SetTriangles(triList.ToArray(), l);
        }
    }

    public Mesh createMesh(Mesh srcMesh)
    {
        Mesh mesh = createMesh();
        mesh.bindposes = srcMesh.bindposes;
        RecreateTriangles(srcMesh, mesh);
        return mesh;
    }
}

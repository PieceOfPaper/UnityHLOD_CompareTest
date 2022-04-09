using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabGenerator : MonoBehaviour
{
    [SerializeField] GameObject m_ObjPrefab;
    [SerializeField] Vector2Int m_Size = new Vector2Int(10, 10);
    [SerializeField] bool m_IsStatic = false;
    [SerializeField] List<GameObject> m_GeneratedList = new List<GameObject>();


#if UNITY_EDITOR
    [ContextMenu("Generate")]
    void Generate()
    {
        ClearGeneratedPrefabs();

        for (int x = 0; x < m_Size.x; x ++)
        { 
            for (int y = 0; y < m_Size.y; y ++)
            {
                var newPrefab = UnityEditor.PrefabUtility.InstantiatePrefab(m_ObjPrefab) as GameObject;
                newPrefab.name = $"{newPrefab.name} ({m_GeneratedList.Count})";
                newPrefab.transform.SetParent(transform);
                newPrefab.transform.position = new Vector3(x, 0, y);
                newPrefab.transform.SetAsLastSibling();
                newPrefab.isStatic = m_IsStatic;
                m_GeneratedList.Add(newPrefab);
            }
        }
    }

    [ContextMenu("Clear Generated Prefabs")]
    void ClearGeneratedPrefabs()
    {
        for (int i = 0; i < m_GeneratedList.Count; i ++)
        {
            if (m_GeneratedList[i] == null) continue;
            DestroyImmediate(m_GeneratedList[i]);
        }
        m_GeneratedList.Clear();
    }
#endif
}

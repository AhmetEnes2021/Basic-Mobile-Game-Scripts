#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(GridScript))]
public class GridScriptDrawer : Editor
{
    //Editör üzerinden Grid oluþturmak için kullanýlýyor

    public override void OnInspectorGUI()
    {
        GridScript GS = (GridScript)target;

        if (GUILayout.Button("Generate Grid"))
        {
            if (GS.CellPrefab != null && GS.GemPrefab.Count > 0)
            {
                CreateGrid(GS);
            }
            else if (GS.GemPrefab.Count == 0)
            {
                EditorUtility.DisplayDialog("Prefab Error", "Hücrelerde Oluþacak Gemlerin Prefablarý Eklenmeli.", "Close");
            }
            else if (GS.CellPrefab == null)
            {
                EditorUtility.DisplayDialog("Prefab Error", "Grid Hücreleri Ýçin Prefab Koymak Zorunludur.", "Close");
            }

        }
        base.OnInspectorGUI();
    }

    private void CreateGrid(GridScript _GS)
    {
        while (_GS.CellList.Count > 0)
        {
            DestroyImmediate(_GS.CellList[_GS.CellList.Count - 1]);
            _GS.CellList.Remove(_GS.CellList[_GS.CellList.Count - 1]);
        }
        for (int i = 0; i < Mathf.Abs(_GS.GridLength); i++)
        {
            for (int k = 0; k < Mathf.Abs(_GS.GridWidth); k++)
            {
                GameObject NewCell = Instantiate(_GS.CellPrefab,
                new Vector3(_GS.GridCootdinate.x +
                (k * (_GS.CellPrefab.transform.localScale.x + _GS.CellToCellDistance)),
                _GS.GridCootdinate.y,
                _GS.GridCootdinate.z + 1f +
                (i * (_GS.CellPrefab.transform.localScale.z + _GS.CellToCellDistance)))
                , Quaternion.identity);

                NewCell.name = "Cell : (" + (k + 1).ToString() + "," + (i + 1).ToString() + ")";
                NewCell.transform.SetParent(_GS.transform);
                _GS.GetComponent<GridScript>().CellList.Add(NewCell);
            }
        }
    }
}
#endif
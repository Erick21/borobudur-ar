using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class Aligner : EditorWindow {
    string ObjectBaseName = "New_object_";
    int ObjectID = 1;
    GameObject ObjectSource;

    [MenuItem("Asep tools/Most used/Add && align")]
    public static void ShowWindow() {
        GetWindow(typeof(Aligner));
    }

    private void OnGUI() {
        //GUILayout.Label("Select object(s) and click 'Add & align'");

        ObjectBaseName = EditorGUILayout.TextField("Base name", ObjectBaseName);
        ObjectID = EditorGUILayout.IntField("New object ID", ObjectID);
        ObjectSource = EditorGUILayout.ObjectField("Source object", ObjectSource, typeof(GameObject), false) as GameObject;

        if (GUILayout.Button("Add & align")) {
            AddNewObject();
        }
    }

    //Fungsi untuk mengubah ID menjadi 3 digit
    private string UDigit(int iNumber) {
        string sTemp = iNumber.ToString();
        if (iNumber < 10) {
            sTemp = "0" + sTemp;
        }
         if (iNumber < 100) {
            sTemp = "0" + sTemp;
        }
        return sTemp;
    }

    private void AddNewObject() {
        if (ObjectSource == null) {
            return;
        }
        if (ObjectBaseName == string.Empty) {
            return;
        }

        //Instance objek ke tiap posisi target
        if (Selection.transforms.Length > 0) {
            foreach (Transform tTransform in Selection.transforms) {
                //GameObject newObject = Selection.activeObject as GameObject;
                //PrefabUtility.IsPartOfPrefabAsset(newObject);
                //GameObject newObject = PrefabUtility.InstantiatePrefab(ObjectSource);
                //PrefabUtility.IsPartOfPrefabAsset(newObject);
                //newObject.transform.rotation = tTransform.transform.rotation;
                //newObject.transform.position = tTransform.transform.position;
                //newObject.transform.localScale = tTransform.transform.localScale;
                //newObject.name = ObjectBaseName + UDigit(ObjectID);
                //ObjectID = ObjectID + 1;
            }
            bool bAccepted = EditorUtility.DisplayDialog("Place Object on Selection", Selection.transforms.Length + " Object added", "OK", "");
        }
    }
}

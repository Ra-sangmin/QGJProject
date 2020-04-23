using UnityEngine;
using UnityEditor;
using System.IO;
using UnityQuickSheet;

///
/// !!! Machine generated code !!!
/// 
public partial class GoogleDataAssetUtility
{
    [MenuItem("Assets/Create/Google/MainAct")]
    public static void CreateMainActAssetFile()
    {
        MainAct asset = CustomAssetUtility.CreateAsset<MainAct>();
        asset.SheetName = "2020 QGJ_Datasheet";
        asset.WorksheetName = "MainAct";
        EditorUtility.SetDirty(asset);        
    }
    
}
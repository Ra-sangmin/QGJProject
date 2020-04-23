using UnityEngine;
using UnityEditor;
using System.IO;
using UnityQuickSheet;

///
/// !!! Machine generated code !!!
/// 
public partial class GoogleDataAssetUtility
{
    [MenuItem("Assets/Create/Google/OP_ED")]
    public static void CreateOP_EDAssetFile()
    {
        OP_ED asset = CustomAssetUtility.CreateAsset<OP_ED>();
        asset.SheetName = "2020 QGJ_Datasheet";
        asset.WorksheetName = "OP_ED";
        EditorUtility.SetDirty(asset);        
    }
    
}
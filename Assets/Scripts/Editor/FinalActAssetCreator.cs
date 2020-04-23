using UnityEngine;
using UnityEditor;
using System.IO;
using UnityQuickSheet;

///
/// !!! Machine generated code !!!
/// 
public partial class GoogleDataAssetUtility
{
    [MenuItem("Assets/Create/Google/FinalAct")]
    public static void CreateFinalActAssetFile()
    {
        FinalAct asset = CustomAssetUtility.CreateAsset<FinalAct>();
        asset.SheetName = "2020 QGJ_Datasheet";
        asset.WorksheetName = "FinalAct";
        EditorUtility.SetDirty(asset);        
    }
    
}
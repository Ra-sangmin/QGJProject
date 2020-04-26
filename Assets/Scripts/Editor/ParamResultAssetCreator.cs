using UnityEngine;
using UnityEditor;
using System.IO;
using UnityQuickSheet;

///
/// !!! Machine generated code !!!
/// 
public partial class GoogleDataAssetUtility
{
    [MenuItem("Assets/Create/Google/ParamResult")]
    public static void CreateParamResultAssetFile()
    {
        ParamResult asset = CustomAssetUtility.CreateAsset<ParamResult>();
        asset.SheetName = "2020 QGJ_Datasheet";
        asset.WorksheetName = "ParamResult";
        EditorUtility.SetDirty(asset);        
    }
    
}
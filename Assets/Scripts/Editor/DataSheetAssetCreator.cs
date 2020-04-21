using UnityEngine;
using UnityEditor;
using System.IO;
using UnityQuickSheet;

///
/// !!! Machine generated code !!!
/// 
public partial class GoogleDataAssetUtility
{
    [MenuItem("Assets/Create/Google/DataSheet")]
    public static void CreateDataSheetAssetFile()
    {
        DataSheet asset = CustomAssetUtility.CreateAsset<DataSheet>();
        asset.SheetName = "2020 QGJ_Datasheet";
        asset.WorksheetName = "DataSheet";
        EditorUtility.SetDirty(asset);        
    }
    
}
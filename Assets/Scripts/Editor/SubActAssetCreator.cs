using UnityEngine;
using UnityEditor;
using System.IO;
using UnityQuickSheet;

///
/// !!! Machine generated code !!!
/// 
public partial class GoogleDataAssetUtility
{
    [MenuItem("Assets/Create/Google/SubAct")]
    public static void CreateSubActAssetFile()
    {
        SubAct asset = CustomAssetUtility.CreateAsset<SubAct>();
        asset.SheetName = "2020 QGJ_Datasheet";
        asset.WorksheetName = "SubAct";
        EditorUtility.SetDirty(asset);        
    }
    
}
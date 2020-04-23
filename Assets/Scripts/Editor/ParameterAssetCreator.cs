using UnityEngine;
using UnityEditor;
using System.IO;
using UnityQuickSheet;

///
/// !!! Machine generated code !!!
/// 
public partial class GoogleDataAssetUtility
{
    [MenuItem("Assets/Create/Google/Parameter")]
    public static void CreateParameterAssetFile()
    {
        Parameter asset = CustomAssetUtility.CreateAsset<Parameter>();
        asset.SheetName = "2020 QGJ_Datasheet";
        asset.WorksheetName = "Parameter";
        EditorUtility.SetDirty(asset);        
    }
    
}
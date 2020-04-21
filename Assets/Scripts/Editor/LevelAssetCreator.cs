using UnityEngine;
using UnityEditor;
using System.IO;
using UnityQuickSheet;

///
/// !!! Machine generated code !!!
/// 
public partial class GoogleDataAssetUtility
{
    [MenuItem("Assets/Create/Google/Level")]
    public static void CreateLevelAssetFile()
    {
        Level asset = CustomAssetUtility.CreateAsset<Level>();
        asset.SheetName = "MySpreadSheet";
        asset.WorksheetName = "Level";
        EditorUtility.SetDirty(asset);        
    }
    
}
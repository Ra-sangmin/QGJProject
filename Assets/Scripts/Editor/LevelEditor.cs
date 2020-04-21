using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;
using System.Text;

using GDataDB;
using GDataDB.Linq;

using UnityQuickSheet;

///
/// !!! Machine generated code !!!
///
[CustomEditor(typeof(Level))]
public class LevelEditor : BaseGoogleEditor<Level>
{	    
    public override bool Load()
    {        
        Level targetData = target as Level;
        
        var client = new DatabaseClient("", "");
        string error = string.Empty;
        var db = client.GetDatabase(targetData.SheetName, ref error);	
        var table = db.GetTable<LevelData>(targetData.WorksheetName) ?? db.CreateTable<LevelData>(targetData.WorksheetName);
        
        List<LevelData> myDataList = new List<LevelData>();
        
        var all = table.FindAll();
        foreach(var elem in all)
        {
            LevelData data = new LevelData();
            
            data = Cloner.DeepCopy<LevelData>(elem.Element);
            myDataList.Add(data);
        }
                
        targetData.dataArray = myDataList.ToArray();
        
        EditorUtility.SetDirty(targetData);
        AssetDatabase.SaveAssets();
        
        return true;
    }
}

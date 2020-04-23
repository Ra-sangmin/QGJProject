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
[CustomEditor(typeof(MainAct))]
public class MainActEditor : BaseGoogleEditor<MainAct>
{	    
    public override bool Load()
    {        
        MainAct targetData = target as MainAct;
        
        var client = new DatabaseClient("", "");
        string error = string.Empty;
        var db = client.GetDatabase(targetData.SheetName, ref error);	
        var table = db.GetTable<MainActData>(targetData.WorksheetName) ?? db.CreateTable<MainActData>(targetData.WorksheetName);
        
        List<MainActData> myDataList = new List<MainActData>();
        
        var all = table.FindAll();
        foreach(var elem in all)
        {
            MainActData data = new MainActData();
            
            data = Cloner.DeepCopy<MainActData>(elem.Element);
            myDataList.Add(data);
        }
                
        targetData.dataArray = myDataList.ToArray();
        
        EditorUtility.SetDirty(targetData);
        AssetDatabase.SaveAssets();
        
        return true;
    }
}

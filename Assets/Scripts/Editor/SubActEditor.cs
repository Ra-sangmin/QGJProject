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
[CustomEditor(typeof(SubAct))]
public class SubActEditor : BaseGoogleEditor<SubAct>
{	    
    public override bool Load()
    {        
        SubAct targetData = target as SubAct;
        
        var client = new DatabaseClient("", "");
        string error = string.Empty;
        var db = client.GetDatabase(targetData.SheetName, ref error);	
        var table = db.GetTable<SubActData>(targetData.WorksheetName) ?? db.CreateTable<SubActData>(targetData.WorksheetName);
        
        List<SubActData> myDataList = new List<SubActData>();
        
        var all = table.FindAll();
        foreach(var elem in all)
        {
            SubActData data = new SubActData();
            
            data = Cloner.DeepCopy<SubActData>(elem.Element);
            myDataList.Add(data);
        }
                
        targetData.dataArray = myDataList.ToArray();
        
        EditorUtility.SetDirty(targetData);
        AssetDatabase.SaveAssets();
        
        return true;
    }
}

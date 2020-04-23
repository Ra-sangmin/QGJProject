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
[CustomEditor(typeof(FinalAct))]
public class FinalActEditor : BaseGoogleEditor<FinalAct>
{	    
    public override bool Load()
    {        
        FinalAct targetData = target as FinalAct;
        
        var client = new DatabaseClient("", "");
        string error = string.Empty;
        var db = client.GetDatabase(targetData.SheetName, ref error);	
        var table = db.GetTable<FinalActData>(targetData.WorksheetName) ?? db.CreateTable<FinalActData>(targetData.WorksheetName);
        
        List<FinalActData> myDataList = new List<FinalActData>();
        
        var all = table.FindAll();
        foreach(var elem in all)
        {
            FinalActData data = new FinalActData();
            
            data = Cloner.DeepCopy<FinalActData>(elem.Element);
            myDataList.Add(data);
        }
                
        targetData.dataArray = myDataList.ToArray();
        
        EditorUtility.SetDirty(targetData);
        AssetDatabase.SaveAssets();
        
        return true;
    }
}

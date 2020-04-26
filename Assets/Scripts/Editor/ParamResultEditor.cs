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
[CustomEditor(typeof(ParamResult))]
public class ParamResultEditor : BaseGoogleEditor<ParamResult>
{	    
    public override bool Load()
    {        
        ParamResult targetData = target as ParamResult;
        
        var client = new DatabaseClient("", "");
        string error = string.Empty;
        var db = client.GetDatabase(targetData.SheetName, ref error);	
        var table = db.GetTable<ParamResultData>(targetData.WorksheetName) ?? db.CreateTable<ParamResultData>(targetData.WorksheetName);
        
        List<ParamResultData> myDataList = new List<ParamResultData>();
        
        var all = table.FindAll();
        foreach(var elem in all)
        {
            ParamResultData data = new ParamResultData();
            
            data = Cloner.DeepCopy<ParamResultData>(elem.Element);
            myDataList.Add(data);
        }
                
        targetData.dataArray = myDataList.ToArray();
        
        EditorUtility.SetDirty(targetData);
        AssetDatabase.SaveAssets();
        
        return true;
    }
}

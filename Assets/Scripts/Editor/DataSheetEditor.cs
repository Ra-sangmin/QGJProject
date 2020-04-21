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
[CustomEditor(typeof(DataSheet))]
public class DataSheetEditor : BaseGoogleEditor<DataSheet>
{	    
    public override bool Load()
    {        
        DataSheet targetData = target as DataSheet;
        
        var client = new DatabaseClient("", "");
        string error = string.Empty;
        var db = client.GetDatabase(targetData.SheetName, ref error);	
        var table = db.GetTable<DataSheetData>(targetData.WorksheetName) ?? db.CreateTable<DataSheetData>(targetData.WorksheetName);
        
        List<DataSheetData> myDataList = new List<DataSheetData>();
        
        var all = table.FindAll();
        foreach(var elem in all)
        {
            DataSheetData data = new DataSheetData();
            
            data = Cloner.DeepCopy<DataSheetData>(elem.Element);
            myDataList.Add(data);
        }
                
        targetData.dataArray = myDataList.ToArray();
        
        EditorUtility.SetDirty(targetData);
        AssetDatabase.SaveAssets();
        
        return true;
    }
}

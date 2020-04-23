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
[CustomEditor(typeof(OP_ED))]
public class OP_EDEditor : BaseGoogleEditor<OP_ED>
{	    
    public override bool Load()
    {        
        OP_ED targetData = target as OP_ED;
        
        var client = new DatabaseClient("", "");
        string error = string.Empty;
        var db = client.GetDatabase(targetData.SheetName, ref error);	
        var table = db.GetTable<OP_EDData>(targetData.WorksheetName) ?? db.CreateTable<OP_EDData>(targetData.WorksheetName);
        
        List<OP_EDData> myDataList = new List<OP_EDData>();
        
        var all = table.FindAll();
        foreach(var elem in all)
        {
            OP_EDData data = new OP_EDData();
            
            data = Cloner.DeepCopy<OP_EDData>(elem.Element);
            myDataList.Add(data);
        }
                
        targetData.dataArray = myDataList.ToArray();
        
        EditorUtility.SetDirty(targetData);
        AssetDatabase.SaveAssets();
        
        return true;
    }
}

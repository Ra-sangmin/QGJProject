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
[CustomEditor(typeof(Parameter))]
public class ParameterEditor : BaseGoogleEditor<Parameter>
{	    
    public override bool Load()
    {        
        Parameter targetData = target as Parameter;
        
        var client = new DatabaseClient("", "");
        string error = string.Empty;
        var db = client.GetDatabase(targetData.SheetName, ref error);	
        var table = db.GetTable<ParameterData>(targetData.WorksheetName) ?? db.CreateTable<ParameterData>(targetData.WorksheetName);
        
        List<ParameterData> myDataList = new List<ParameterData>();
        
        var all = table.FindAll();
        foreach(var elem in all)
        {
            ParameterData data = new ParameterData();
            
            data = Cloner.DeepCopy<ParameterData>(elem.Element);
            myDataList.Add(data);
        }
                
        targetData.dataArray = myDataList.ToArray();
        
        EditorUtility.SetDirty(targetData);
        AssetDatabase.SaveAssets();
        
        return true;
    }
}

using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace GodJunie.QGJ2020 {
    public class DataManager : MonoBehaviour {
        #region Instance
        protected static DataManager sInstance = null;

        public static DataManager Instance {
            get {
                if(sInstance == null) {
                    sInstance = FindObjectOfType(typeof(DataManager)) as DataManager;

                    if(sInstance == null) {
                        Debug.Log("Nothing" + sInstance.ToString());
                        return null;
                    }
                }
                return sInstance;
            }
        }
        #endregion

        [SerializeField] private DataSheet datasheetTable;
        private List<DataSheetData> dataList;

        private void Awake() {
            dataList = datasheetTable.dataArray.ToList();
        }

        // Start is called before the first frame update
        void Start() {

        }

        // Update is called once per frame
        void Update() {

        }

        public DataSheetData GetData(string id) {
            return dataList.Find(i => i.Ed == id);
        }

        public DataSheetData GetData(int index) {
            return dataList[index];
        }
    }
}
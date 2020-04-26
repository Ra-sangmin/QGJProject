using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace GodJunie.QGJ2020 {
    /// <summary>
    /// https://docs.google.com/spreadsheets/d/1dFd7pRsrA5yItSj5KlWvYKywTz95z8T-x9MlVgvePPY/edit?usp=sharing
    /// </summary>
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

        [SerializeField] private Parameter parameter;
        public List<ParameterData> ParameterDataList;

        [SerializeField] private OP_ED op_ED;
        private List<OP_EDData> op_EDDataList;

        [SerializeField] private MainAct mainAct;
        public List<MainActData> mainActDataList;

        [SerializeField] private SubAct subAct;
        private List<SubActData> subActDataList;

        [SerializeField] private FinalAct finalAct;
        private List<FinalActData> finalActDataList;

        [SerializeField] private ParamResult paramResult;
        private List<ParamResultData> paramResultList;

        private void Awake() {

            ParameterDataList = parameter.dataArray.ToList();
            op_EDDataList = op_ED.dataArray.ToList();

            mainActDataList = mainAct.dataArray.ToList();
            subActDataList = subAct.dataArray.ToList();
            finalActDataList = finalAct.dataArray.ToList();
            paramResultList = paramResult.dataArray.ToList();
        }

        // Start is called before the first frame update
        void Start() {
        }

        // Update is called once per frame
        void Update() {

        }

        public MainActData GetMainData(int id) {
            return mainActDataList.Find(i => i.Id == id);
        }

        public SubActData GetSubData(int id)
        {
            return subActDataList.Find(i => i.Id == id);
        }

        public FinalActData GetFinalData(int id)
        {
            return finalActDataList.Find(i => i.Id == id);
        }

        public ParamResultData GetParamResultData(int id)
        {
            return paramResultList.Find(i => i.Id == id);
        }

        public OP_EDData GetOP_EDData(string id)
        {
            return op_EDDataList.Find(i => i.Id == id);
        }
    }
}

public enum StoryStateEnum
{
    Start,
    Main,
    Sub,
    Final,
    Finish,
    Ending
}
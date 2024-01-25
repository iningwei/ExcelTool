using UnityEngine;
using System;
using System.Text;
using System.Collections.Generic;

namespace ZGame.ZTable{
	public class LanguageDataReader{
		private Dictionary<int,LanguageData> entityMap = new Dictionary<int,LanguageData>();

		static LanguageDataReader instance=null;
		public static LanguageDataReader Instance{
			get{
				if(instance==null){
					instance=new LanguageDataReader();
					instance.Load();
				}
				return instance;
			}
		}

		void Load(){
			Action<string> onTableLoad=(txt)=>{
				string[] lines=txt.Split(new string[]{"\r\n"},System.StringSplitOptions.RemoveEmptyEntries);
				int count=lines.Length;
				if(count<0){
					return;
				}
				for(int i=0;i<count;i++){
					string line=lines[i];
					if(string.IsNullOrEmpty(line)){
						Debug.LogError("data error, line "+i+" is null");
						continue;
					}
					string[] vals=line.Split("@~ExcelTool!@");
					int key=int.Parse(vals[0].Trim());
					if(entityMap.ContainsKey(key)){
						Debug.LogError("error,already exist key: "+key+" in LanguageData,line content:"+line);
						continue;
					}
					var entity=new LanguageData();
					entity.ID=int.Parse(vals[0].Trim());
					entity.EN=vals[1];
					entity.CN=vals[2];
					entity.TC=vals[3];
					entityMap[key]=entity;
				}
			};

			string fileName=LanguageData.FileName;
			try{
				FileMgr.ReadFile(fileName,onTableLoad);
			}
			catch(System.Exception ex){
				Debug.LogError("error while read:"+fileName+ ", ex:" + ex.ToString());
			}
		}

		/// <summary>
		/// get data by primary key
		/// </summary>
		public LanguageData GetEntity(int key){
			LanguageData data;
			if(entityMap.TryGetValue(key,out data)){
				return data;
			}
			else{
				Debug.LogError("no entity with key:"+key+" in LanguageData");
				return default(LanguageData);
			}
		}
		/// <summary>
		/// get all datas
		/// </summary>
		public Dictionary<int,LanguageData> GetEntityMap(){
			return this.entityMap;
		}
	}
}
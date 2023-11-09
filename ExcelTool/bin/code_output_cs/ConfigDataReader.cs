using UnityEngine;
using System;
using System.Text;
using System.Collections.Generic;

namespace ZGame.ZTable{
	public class ConfigDataReader{
		private Dictionary<int,ConfigData> entityMap = new Dictionary<int,ConfigData>();

		static ConfigDataReader instance=null;
		public static ConfigDataReader Instance{
			get{
				if(instance==null){
					instance=new ConfigDataReader();
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
					string[] vals=line.Split('\t');
					int key=int.Parse(vals[0].Trim());
					if(entityMap.ContainsKey(key)){
						Debug.LogError("error,already exist key: "+key+" in ConfigData,line content:"+line);
						continue;
					}
					var entity=new ConfigData();
					entity.ID=int.Parse(vals[0].Trim());
					entity.Value=vals[1];
					entityMap[key]=entity;
				}
			};

			string fileName=ConfigData.FileName;
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
		public ConfigData GetEntity(int key){
			ConfigData data;
			if(entityMap.TryGetValue(key,out data)){
				return data;
			}
			else{
				Debug.LogError("no entity with key:"+key+" in ConfigData");
				return default(ConfigData);
			}
		}
		/// <summary>
		/// get all datas
		/// </summary>
		public Dictionary<int,ConfigData> GetEntityMap(){
			return this.entityMap;
		}
	}
}
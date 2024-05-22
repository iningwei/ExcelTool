using UnityEngine;
using System;
using System.Text;
using System.Collections.Generic;

namespace ZGame.ZTable{
	public class InitialSaleDataReader{
		private Dictionary<long,InitialSaleData> entityMap = new Dictionary<long,InitialSaleData>();

		static InitialSaleDataReader instance=null;
		public static InitialSaleDataReader Instance{
			get{
				if(instance==null){
					instance=new InitialSaleDataReader();
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
						Debug.LogError("error,already exist key: "+key+" in InitialSaleData,line content:"+line);
						continue;
					}
					var entity=new InitialSaleData();
					entity.ID=long.Parse(vals[0].Trim());
					entity.itemId=long.Parse(vals[1].Trim());
					entity.price=float.Parse(vals[2].Trim());
					entity.listOnStore=bool.Parse(vals[3].Trim());
					entity.storePayCode=vals[4];
					entity.storePrice=float.Parse(vals[5].Trim());
					entity.limitDatePart=vals[6];
					entity.limitDayTimePart=vals[7];
					entity.limitNumRole=int.Parse(vals[8].Trim());
					entityMap[key]=entity;
				}
			};

			string fileName=InitialSaleData.FileName;
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
		public InitialSaleData GetEntity(long key){
			InitialSaleData data;
			if(entityMap.TryGetValue(key,out data)){
				return data;
			}
			else{
				Debug.LogError("no entity with key:"+key+" in InitialSaleData");
				return default(InitialSaleData);
			}
		}
		/// <summary>
		/// get all datas
		/// </summary>
		public Dictionary<long,InitialSaleData> GetEntityMap(){
			return this.entityMap;
		}
	}
}
using UnityEngine;
using System;
using System.Text;
using System.Collections.Generic;

namespace ZGame.ZTable{
	public class itemReader{
		private Dictionary<int,item> entityMap = new Dictionary<int,item>();

		static itemReader instance=null;
		public static itemReader Instance{
			get{
				if(instance==null){
					instance=new itemReader();
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
						Debug.LogError("error,already exist key: "+key+" in item,line content:"+line);
						continue;
					}
					var entity=new item();
					entity.ID=int.Parse(vals[0].Trim());
					entity.durable=uint.Parse(vals[1].Trim());
					entity.type=int.Parse(vals[2].Trim());
					entity.kind=int.Parse(vals[3].Trim());
					entity.list=int.Parse(vals[4].Trim());
					entity.update=int.Parse(vals[5].Trim());
					entity.down=vals[6].Split(',').ToIntArray();
					entity.up=vals[7].Split(',').ToIntArray();
					entity.level=int.Parse(vals[8].Trim());
					entity.star=int.Parse(vals[9].Trim());
					entity.NFT=int.Parse(vals[10].Trim());
					entity.time=int.Parse(vals[11].Trim());
					entity.drop=int.Parse(vals[12].Trim());
					entity.merge=int.Parse(vals[13].Trim());
					entity.quanitityType=int.Parse(vals[14].Trim());
					entity.quanititylimit=int.Parse(vals[15].Trim());
					entityMap[key]=entity;
				}
			};

			string fileName=item.FileName;
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
		public item GetEntity(int key){
			item data;
			if(entityMap.TryGetValue(key,out data)){
				return data;
			}
			else{
				Debug.LogError("no entity with key:"+key+" in item");
				return default(item);
			}
		}
		/// <summary>
		/// get all datas
		/// </summary>
		public Dictionary<int,item> GetEntityMap(){
			return this.entityMap;
		}
	}
}